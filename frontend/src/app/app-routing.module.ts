import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {MainComponent} from './components/main/main.component';
import {KnowledgeBranchComponent} from './components/knowledge-branch/knowledge-branch.component';
import {SpecialityComponent} from './components/speciality/speciality.component';
import {KnowledgeBranchAddEditComponent} from './components/knowledge-branch/knowledge-branch-add-edit/knowledge-branch-add-edit.component';
import {SpecialityAddEditComponent} from './components/speciality/speciality-add-edit/speciality-add-edit.component';
import {TeachersComponent} from './components/teachers/teachers.component';
import {HeadsComponent} from './components/heads/heads.component';
import {GuarantorsComponent} from './components/guarantors/guarantors.component';
import {SubjectsComponent} from './components/subjects/subjects.component';
import {SyllabusesComponent} from './components/syllabuses/syllabuses.component';
import {LoadsComponent} from './components/loads/loads.component';

const routes: Routes = [
  {path: '', component: MainComponent},
  {path: 'knowledgebranch', component: KnowledgeBranchComponent},
  {path: 'knowledgebranch/add', component: KnowledgeBranchAddEditComponent},
  {path: 'knowledgebranch/edit/:id', component: KnowledgeBranchAddEditComponent},
  {path: 'speciality', component: SpecialityComponent},
  {path: 'speciality/add', component: SpecialityAddEditComponent},
  {path: 'speciality/edit/:id', component: SpecialityAddEditComponent},
  {path: 'teachers', component: TeachersComponent},
  {path: 'heads', component: HeadsComponent},
  {path: 'guarantors', component: GuarantorsComponent},
  {path: 'subjects', component: SubjectsComponent},
  {path: 'syllabuses', component: SyllabusesComponent},
  {path: 'loads', component: LoadsComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
