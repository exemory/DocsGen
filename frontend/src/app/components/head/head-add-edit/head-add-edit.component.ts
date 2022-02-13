import {Component, OnInit} from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {ActivatedRoute, Router} from "@angular/router";
import {HttpService} from "../../../shared/services/http.service";
import {ToastrService} from "ngx-toastr";

@Component({
  selector: 'app-head-add-edit',
  templateUrl: './head-add-edit.component.html',
  styleUrls: ['./head-add-edit.component.scss']
})
export class HeadAddEditComponent implements OnInit {
  id: string | any;
  isAddMode: boolean | any;
  form: FormGroup | any;

  constructor(private router: Router, private route: ActivatedRoute,
              private http: HttpService, private toastr: ToastrService) {
  }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];
    this.isAddMode = !this.id;

    this.form = new FormGroup({
      name: new FormControl('', [Validators.required]),
      surname: new FormControl('', [Validators.required]),
      patronymic: new FormControl('', [Validators.required]),
      academicDegree: new FormControl(''),
      academicRank: new FormControl('', [Validators.required]),
      email: new FormControl(''),
      phone: new FormControl('')
    });

    if (!this.isAddMode) {
      this.http.get(`heads-of-smc/${this.id}`).subscribe(data => this.form.patchValue(data));
    }
  }

  goBack(): void {
    this.router.navigate(['head']);
  }

  create(): any {
    if (this.form.valid) {
      this.http.post('heads-of-smc', this.form.value).subscribe({
        error: err => this.toastr.error(err.message),
        complete: () => {
          this.toastr.success('', 'Успішно створено');
          this.router.navigate(['head']);
        }
      });
    }
  }

  edit(): any {
    if (!this.form.invalid) {
      this.http.put(`heads-of-smc/${this.id}`, {...this.form.value, id: this.id}).subscribe({
        error: err => this.toastr.error(err.message),
        complete: () => {
          this.toastr.success('', 'Успішно редаговано');
          this.router.navigate(['head']);
        }
      });
    }
  }

  getErrorMessage() {
    return "Це поле обов'якзкове";
  }
}
