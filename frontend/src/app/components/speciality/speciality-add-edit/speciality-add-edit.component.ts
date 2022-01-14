import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {ActivatedRoute, Router} from '@angular/router';

@Component({
  selector: 'app-speciality-add-edit',
  templateUrl: './speciality-add-edit.component.html',
  styleUrls: ['./speciality-add-edit.component.scss']
})
export class SpecialityAddEditComponent implements OnInit {
  id: string;
  isAddMode: boolean;
  form: FormGroup;

  constructor(private router: Router, private route: ActivatedRoute) {
  }

  ngOnInit(): void {
    this.id = this.route.snapshot.params.id;
    this.isAddMode = !this.id;

    this.form = new FormGroup({
      code: new FormControl('', [Validators.required]),
      name: new FormControl('', [Validators.required]),
      knowledgeBranch: new FormControl('', [Validators.required]),
      headOfSMC: new FormControl('', [Validators.required]),
      guarantor: new FormControl('', [Validators.required])
    });
  }

  goBack(): void {
    this.router.navigate(['speciality']);
  }

  create(): any {
    if (this.form.invalid) {
      return;
    }

    this.form.reset();
  }

  edit(): any {
    if (this.form.invalid) {
      return;
    }

    this.form.reset();
  }
}
