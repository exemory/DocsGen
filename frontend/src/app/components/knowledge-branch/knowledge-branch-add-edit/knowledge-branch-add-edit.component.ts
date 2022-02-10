import {Component, OnInit} from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {ActivatedRoute, Router} from "@angular/router";
import {HttpService} from "../../../shared/services/http.service";
import {ToastrService} from "ngx-toastr";

@Component({
  selector: 'app-knowledge-branch-add-edit',
  templateUrl: './knowledge-branch-add-edit.component.html',
  styleUrls: ['./knowledge-branch-add-edit.component.scss']
})
export class KnowledgeBranchAddEditComponent implements OnInit {
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
      code: new FormControl('', [Validators.required]),
      name: new FormControl('', [Validators.required])
    });

    if (!this.isAddMode) {
      this.http.get(`knowledge-branches/${this.id}`).subscribe(data => this.form.patchValue(data));
    }
  }

  goBack(): void {
    this.router.navigate(['knowledge-branch']);
  }

  create(): any {
    if (!this.form.invalid) {
      this.http.post('knowledge-branches', {
        code: this.form.controls['code'].value,
        name: this.form.controls['name'].value
      }).subscribe({
        next: data => null,
        error: err => this.toastr.error(err.message),
        complete: () => {
          this.toastr.success('', 'Успішно створено');
          this.router.navigate(['knowledge-branch']);
        }
      });
    }
  }

  edit(): any {
    if (!this.form.invalid) {
      this.http.put(`knowledge-branches/${this.id}`, {
        id: this.id,
        code: this.form.controls['code'].value,
        name: this.form.controls['name'].value
      }).subscribe({
        next: data => null,
        error: err => this.toastr.error(err.message),
        complete: () => {
          this.toastr.success('', 'Успішно редаговано');
          this.router.navigate(['knowledge-branch']);
        }
      });
    }
  }
}
