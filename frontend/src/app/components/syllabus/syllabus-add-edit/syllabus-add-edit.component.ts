import {Component, OnInit} from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {ActivatedRoute, Router} from "@angular/router";
import {HttpService} from "../../../shared/services/http.service";
import {ToastrService} from "ngx-toastr";

@Component({
  selector: 'app-syllabus-add-edit',
  templateUrl: './syllabus-add-edit.component.html',
  styleUrls: ['./syllabus-add-edit.component.scss']
})
export class SyllabusAddEditComponent implements OnInit {
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
      credits: new FormControl(''),
      totalHours: new FormControl(),
      classroomHours: new FormControl(),
      lectureHours: new FormControl(),
      labHours: new FormControl(),
      practicalHours: new FormControl(),
      courseProjects: new FormControl(),
      courseWork: new FormControl(),
      rgr: new FormControl(),
      r: new FormControl(),
      formOfControl: new FormControl(''),
      semester: new FormControl(),
    });

    if (!this.isAddMode) {
      this.http.get(`syllabuses/${this.id}`).subscribe(data => this.form.patchValue(data));
    }
  }

  goBack(): void {
    this.router.navigate(['syllabus']);
  }

  create(): any {
    if (this.form.valid) {
      this.http.post('syllabuses', this.form.value).subscribe({
        error: err => this.toastr.error(err.message),
        complete: () => {
          this.toastr.success('', 'Успішно створено');
          this.router.navigate(['syllabus']);
        }
      });
    }
  }

  edit(): any {
    if (this.form.valid) {
      this.http.put(`syllabuses/${this.id}`, {...this.form.value, id: this.id}).subscribe({
        error: err => this.toastr.error(err.message),
        complete: () => {
          this.toastr.success('', 'Успішно редаговано');
          this.router.navigate(['syllabus']);
        }
      });
    }
  }

  getErrorMessage() {
    return "Це поле обов'якзкове";
  }
}
