import {Component, OnInit} from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {ActivatedRoute, Router} from "@angular/router";
import {HttpService} from "../../../shared/services/http.service";
import {ToastrService} from "ngx-toastr";

@Component({
  selector: 'app-subject-add-edit',
  templateUrl: './subject-add-edit.component.html',
  styleUrls: ['./subject-add-edit.component.scss']
})
export class SubjectAddEditComponent implements OnInit {
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
      name: new FormControl('', [Validators.required])
    });

    if (!this.isAddMode) {
      this.http.get(`subjects/${this.id}`).subscribe(data => this.form.patchValue(data));
    }
  }

  goBack(): void {
    this.router.navigate(['subject']);
  }

  create(): any {
    if (this.form.valid) {
      this.http.post('subjects', this.form.value).subscribe({
        error: err => {
          if (err.status === 409) {
            this.toastr.error('Данний предмет вже існує!');
          } else this.toastr.error(err.message);
        },
        complete: () => {
          this.toastr.success('', 'Успішно створено');
          this.router.navigate(['subject']);
        }
      });
    }
  }

  edit(): any {
    if (this.form.valid) {
      this.http.put(`subjects/${this.id}`, {...this.form.value, id: this.id}).subscribe({
        error: err => {
          if (err.status === 409) {
            this.toastr.error('Предмет з такаю назвою вже існує!');
          } else this.toastr.error(err.message);
        },
        complete: () => {
          this.toastr.success('', 'Успішно редаговано');
          this.router.navigate(['subject']);
        }
      });
    }
  }

  getErrorMessage() {
    return "Це поле обов'якзкове";
  }
}
