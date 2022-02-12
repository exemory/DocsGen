import {Component, OnInit} from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {ActivatedRoute, Router} from "@angular/router";
import {HttpService} from "../../../shared/services/http.service";
import {ToastrService} from "ngx-toastr";
import {KnowledgeBranch} from "../../../shared/interfaces/knowledge-branch";
import {Guarantor} from "../../../shared/interfaces/guarantor";
import {HeadOfSMC} from "../../../shared/interfaces/headOfSMC";


@Component({
  selector: 'app-speciality-add-edit',
  templateUrl: './speciality-add-edit.component.html',
  styleUrls: ['./speciality-add-edit.component.scss']
})
export class SpecialityAddEditComponent implements OnInit {
  id: string | any;
  isAddMode: boolean | any;
  form: FormGroup | any;
  knowledgeBranches: KnowledgeBranch[] = [];
  guarantors: Guarantor[] = [];
  headsOfSMC: HeadOfSMC[] = [];


  constructor(private router: Router, private route: ActivatedRoute,
              private http: HttpService, private toastr: ToastrService) {
  }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];
    this.isAddMode = !this.id;

    this.form = new FormGroup({
      code: new FormControl('', [Validators.required]),
      name: new FormControl('', [Validators.required]),
      knowledgeBranchId: new FormControl(null, [Validators.required]),
      headOfSmcId: new FormControl(null, [Validators.required]),
      guarantorId: new FormControl(null, [Validators.required])
    });

    if (!this.isAddMode) {
      this.http.get(`specialties/${this.id}`).subscribe(data => this.form.patchValue(data));
    }

    this.http.get('knowledge-branches').subscribe(data => this.knowledgeBranches = data);
    this.http.get('heads-of-smc').subscribe(data => this.headsOfSMC = data);
    this.http.get('guarantors').subscribe(data => this.guarantors = data);
  }

  create(): any {
    if (this.form.valid) {
      this.http.post('specialties', this.form.value).subscribe({
        error: err => {
          if (err.status === 409) {
            this.toastr.error('Спеціальність з таким шифром або гарантом вже існує!')
          } else this.toastr.error(err.message);
        },
        complete: () => {
          this.toastr.success('', 'Успішно створено');
          this.router.navigate(['speciality']);
        }
      });
    }
  }

  edit(): any {
    if (this.form.valid) {
      this.http.put(`specialties/${this.id}`, {...this.form.value, id: this.id}).subscribe({
        error: err => {
          if (err.status === 409) {
            this.toastr.error('Спеціальність з таким шифром або гарантом вже існує!')
          } else this.toastr.error(err.message);
        },
        complete: () => {
          this.toastr.success('', 'Успішно редаговано');
          this.router.navigate(['speciality']);
        }
      });
    }
  }

  goBack(): void {
    this.router.navigate(['speciality']);
  }

  getErrorMessage() {
    return "Це поле обов'якзкове";
  }
}
