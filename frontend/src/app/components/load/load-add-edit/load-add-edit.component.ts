import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {ActivatedRoute, Router} from "@angular/router";
import {HttpService} from "../../../shared/services/http.service";
import {ToastrService} from "ngx-toastr";
import {KnowledgeBranch} from "../../../shared/interfaces/knowledge-branch";
import {Guarantor} from "../../../shared/interfaces/guarantor";
import {HeadOfSMC} from "../../../shared/interfaces/headOfSMC";
import {Teacher} from "../../../shared/interfaces/teacher";
import {Subject} from "../../../shared/interfaces/subject";
import {Specialty} from "../../../shared/interfaces/specialty";

@Component({
  selector: 'app-load-add-edit',
  templateUrl: './load-add-edit.component.html',
  styleUrls: ['./load-add-edit.component.scss']
})
export class LoadAddEditComponent implements OnInit {
  id: string | any;
  isAddMode: boolean | any;
  form: FormGroup | any;
  teachers: Teacher[] = [];
  subjects: Subject[] = [];
  specialties: Specialty[] = [];
  syllabuses: Specialty[] = [];

  constructor(private router: Router, private route: ActivatedRoute,
              private http: HttpService, private toastr: ToastrService) {
  }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];
    this.isAddMode = !this.id;

    this.form = new FormGroup({
      type: new FormControl(null, [Validators.required]),
      year: new FormControl( null, [Validators.required, Validators.min(1), Validators.max(6)]),
      teacherId: new FormControl(),
      subjectId: new FormControl(),
      specialtyId: new FormControl(),
      syllabusId: new FormControl()
    });

    if (!this.isAddMode) {
      this.http.get(`teacher-loads/${this.id}`).subscribe(data => this.form.patchValue(data));
    }

    this.http.get('teachers').subscribe(data => this.teachers = data);
    this.http.get('subjects').subscribe(data => this.subjects = data);
    this.http.get('specialties').subscribe(data => this.specialties = data);
    this.http.get('syllabuses').subscribe(data => this.syllabuses = data);
  }

  goBack(): void {
    this.router.navigate(['load']);
  }

  create(): any {
    console.log(this.form)
    if (!this.form.invalid) {
      this.http.post('teacher-loads', {
        type: this.form.controls['type'].value,
        year: this.form.controls['year'].value,
        teacherId: this.form.controls['teacherId'].value,
        subjectId: this.form.controls['subjectId'].value,
        specialtyId: this.form.controls['specialtyId'].value,
        syllabusId: this.form.controls['syllabusId'].value
      }).subscribe({
        next: data => null,
        error: err => this.toastr.error(err.message),
        complete: () => {
          this.toastr.success('', 'Успішно створено');
          this.router.navigate(['load']);
        }
      });
    }
  }

  edit(): any {
    if (!this.form.invalid) {
      this.http.put(`teacher-loads/${this.id}`, {
        id: this.id,
        type: this.form.controls['type'].value,
        year: this.form.controls['year'].value,
        teacherId: this.form.controls['teacherId'].value,
        subjectId: this.form.controls['subjectId'].value,
        specialtyId: this.form.controls['specialtyId'].value,
        syllabusId: this.form.controls['syllabusId'].value
      }).subscribe({
        next: data => null,
        error: err => this.toastr.error(err.message),
        complete: () => {
          this.toastr.success('', 'Успішно редаговано');
          this.router.navigate(['load']);
        }
      });
    }
  }
}
