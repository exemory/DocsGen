import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {MainComponent} from './components/main/main.component';
import {KnowledgeBranchComponent} from './components/knowledge-branch/knowledge-branch.component';
import {SpecialityComponent} from './components/speciality/speciality.component';
import {KnowledgeBranchAddEditComponent} from './components/knowledge-branch/knowledge-branch-add-edit/knowledge-branch-add-edit.component';

const routes: Routes = [
  { path: '', component: MainComponent},
  { path: 'knowledgebranch', component: KnowledgeBranchComponent},
  { path: 'knowledgebranch/add', component: KnowledgeBranchAddEditComponent},
  { path: 'knowledgebranch/edit/:id', component: KnowledgeBranchAddEditComponent},
  { path: 'speciality', component: SpecialityComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
