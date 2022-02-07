import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {HttpService} from '../../../shared/services/http.service';

@Component({
  selector: 'app-knowledge-branch-add-edit',
  templateUrl: './knowledge-branch-add-edit.component.html',
  styleUrls: ['./knowledge-branch-add-edit.component.scss']
})
export class KnowledgeBranchAddEditComponent implements OnInit {
  id: string;
  isAddMode: boolean;
  form: FormGroup;

  constructor(private router: Router, private route: ActivatedRoute, private http: HttpService) {
  }

  ngOnInit(): void {
    this.id = this.route.snapshot.params.id;
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
    this.router.navigate(['knowledgebranch']);
  }

  create(): any {
    if (!this.form.invalid) {
      this.http.post('knowledge-branches', {
        code: this.form.controls.code.value,
        name: this.form.controls.name.value
      }).subscribe(data => console.log('Data: ', data));

      this.form.reset();
    }
  }

  edit(): any {
    if (!this.form.invalid) {
      this.http.put(`knowledge-branches/${this.id}`, {
        id: this.id,
        code: this.form.controls.code.value,
        name: this.form.controls.name.value
      }).subscribe(data => console.log('Data: ', data));

      this.form.reset();
    }
  }
}
