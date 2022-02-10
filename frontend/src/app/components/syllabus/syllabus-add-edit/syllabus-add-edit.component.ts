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
    if (!this.form.invalid) {
      this.http.post('syllabuses', {
        credits: this.form.controls['credits'].value,
        totalHours: this.form.controls['totalHours'].value,
        classroomHours: this.form.controls['classroomHours'].value,
        lectureHours: this.form.controls['lectureHours'].value,
        labHours: this.form.controls['labHours'].value,
        practicalHours: this.form.controls['practicalHours'].value,
        courseProjects: this.form.controls['courseProjects'].value,
        courseWork: this.form.controls['courseWork'].value,
        rgr: this.form.controls['rgr'].value,
        r: this.form.controls['r'].value,
        formOfControl: this.form.controls['formOfControl'].value,
        semester: this.form.controls['semester'].value
      }).subscribe({
        next: data => null,
        error: err => this.toastr.error(err.message),
        complete: () => {
          this.toastr.success('', 'Успішно створено');
          this.router.navigate(['syllabus']);
        }
      });
    }
  }

  edit(): any {
    if (!this.form.invalid) {
      this.http.put(`syllabuses/${this.id}`, {
        id: this.id,
        credits: this.form.controls['credits'].value,
        totalHours: this.form.controls['totalHours'].value,
        classroomHours: this.form.controls['classroomHours'].value,
        lectureHours: this.form.controls['lectureHours'].value,
        labHours: this.form.controls['labHours'].value,
        practicalHours: this.form.controls['practicalHours'].value,
        courseProjects: this.form.controls['courseProjects'].value,
        courseWork: this.form.controls['courseWork'].value,
        rgr: this.form.controls['rgr'].value,
        r: this.form.controls['r'].value,
        formOfControl: this.form.controls['formOfControl'].value,
        semester: this.form.controls['semester'].value
      }).subscribe({
        next: data => null,
        error: err => this.toastr.error(err.message),
        complete: () => {
          this.toastr.success('', 'Успішно редаговано');
          this.router.navigate(['syllabus']);
        }
      });
    }
  }
}
