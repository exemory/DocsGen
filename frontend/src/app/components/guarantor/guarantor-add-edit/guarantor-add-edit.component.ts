import {Component, OnInit} from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {ActivatedRoute, Router} from "@angular/router";
import {HttpService} from "../../../shared/services/http.service";
import {ToastrService} from "ngx-toastr";

@Component({
  selector: 'app-guarantor-add-edit',
  templateUrl: './guarantor-add-edit.component.html',
  styleUrls: ['./guarantor-add-edit.component.scss']
})
export class GuarantorAddEditComponent implements OnInit {
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
      this.http.get(`guarantors/${this.id}`).subscribe(data => this.form.patchValue(data));
    }
  }

  goBack(): void {
    this.router.navigate(['guarantor']);
  }

  create(): any {
    if (!this.form.invalid) {
      this.http.post('guarantors', {
        name: this.form.controls['name'].value,
        surname: this.form.controls['surname'].value,
        patronymic: this.form.controls['patronymic'].value,
        academicDegree: this.form.controls['academicDegree'].value,
        academicRank: this.form.controls['academicRank'].value,
        email: this.form.controls['email'].value,
        phone: this.form.controls['phone'].value
      }).subscribe({
        next: data => null,
        error: err => this.toastr.error(err.message),
        complete: () => {
          this.toastr.success('', 'Успішно створено');
          this.router.navigate(['guarantor']);
        }
      });
    }
  }

  edit(): any {
    if (!this.form.invalid) {
      this.http.put(`guarantors/${this.id}`, {
        id: this.id,
        name: this.form.controls['name'].value,
        surname: this.form.controls['surname'].value,
        patronymic: this.form.controls['patronymic'].value,
        academicDegree: this.form.controls['academicDegree'].value,
        academicRank: this.form.controls['academicRank'].value,
        email: this.form.controls['email'].value,
        phone: this.form.controls['phone'].value
      }).subscribe({
        next: data => null,
        error: err => this.toastr.error(err.message),
        complete: () => {
          this.toastr.success('', 'Успішно редаговано');
          this.router.navigate(['guarantor']);
        }
      });
    }
  }
}
