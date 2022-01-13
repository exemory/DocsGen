import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {FormControl, FormGroup, Validators} from '@angular/forms';

@Component({
  selector: 'app-knowledge-branch-add-edit',
  templateUrl: './knowledge-branch-add-edit.component.html',
  styleUrls: ['./knowledge-branch-add-edit.component.scss']
})
export class KnowledgeBranchAddEditComponent implements OnInit {
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
      name: new FormControl('', [Validators.required])
    });
  }

  goBack(): void {
    this.router.navigate(['knowledgebranch']);
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
