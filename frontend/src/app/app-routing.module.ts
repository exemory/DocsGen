import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {MainComponent} from "./components/main/main.component";
import {KnowledgeBranchComponent} from "./components/knowledge-branch/knowledge-branch.component";
import {SpecialityComponent} from "./components/speciality/speciality.component";
import {SpecialityAddEditComponent} from "./components/speciality/speciality-add-edit/speciality-add-edit.component";
import {TeacherComponent} from "./components/teacher/teacher.component";
import {HeadComponent} from "./components/head/head.component";
import {GuarantorComponent} from "./components/guarantor/guarantor.component";
import {SyllabusComponent} from "./components/syllabus/syllabus.component";
import {SubjectComponent} from "./components/subject/subject.component";
import {LoadComponent} from "./components/load/load.component";
import {
  KnowledgeBranchAddEditComponent
} from "./components/knowledge-branch/knowledge-branch-add-edit/knowledge-branch-add-edit.component";
import {LoginComponent} from "./components/login/login.component";
import {AuthGuard} from "./shared/helpers/auth.guard";
import {TeacherAddEditComponent} from "./components/teacher/teacher-add-edit/teacher-add-edit.component";
import {HeadAddEditComponent} from "./components/head/head-add-edit/head-add-edit.component";
import {GuarantorAddEditComponent} from "./components/guarantor/guarantor-add-edit/guarantor-add-edit.component";
import {SubjectAddEditComponent} from "./components/subject/subject-add-edit/subject-add-edit.component";
import {SyllabusAddEditComponent} from "./components/syllabus/syllabus-add-edit/syllabus-add-edit.component";
import {LoadAddEditComponent} from "./components/load/load-add-edit/load-add-edit.component";

const routes: Routes = [
  {path: 'login', component: LoginComponent},
  {path: '', component: MainComponent, canActivate: [AuthGuard]},
  {path: 'knowledge-branch', component: KnowledgeBranchComponent, canActivate: [AuthGuard]},
  {path: 'knowledge-branch/add', component: KnowledgeBranchAddEditComponent, canActivate: [AuthGuard]},
  {path: 'knowledge-branch/edit/:id', component: KnowledgeBranchAddEditComponent, canActivate: [AuthGuard]},
  {path: 'speciality', component: SpecialityComponent, canActivate: [AuthGuard]},
  {path: 'speciality/add', component: SpecialityAddEditComponent, canActivate: [AuthGuard]},
  {path: 'speciality/edit/:id', component: SpecialityAddEditComponent, canActivate: [AuthGuard]},
  {path: 'teacher', component: TeacherComponent, canActivate: [AuthGuard]},
  {path: 'teacher/add', component: TeacherAddEditComponent, canActivate: [AuthGuard]},
  {path: 'teacher/edit/:id', component: TeacherAddEditComponent, canActivate: [AuthGuard]},
  {path: 'head', component: HeadComponent, canActivate: [AuthGuard]},
  {path: 'head/add', component: HeadAddEditComponent, canActivate: [AuthGuard]},
  {path: 'head/edit/:id', component: HeadAddEditComponent, canActivate: [AuthGuard]},
  {path: 'guarantor', component: GuarantorComponent, canActivate: [AuthGuard]},
  {path: 'guarantor/add', component: GuarantorAddEditComponent, canActivate: [AuthGuard]},
  {path: 'guarantor/edit/:id', component: GuarantorAddEditComponent, canActivate: [AuthGuard]},
  {path: 'subject', component: SubjectComponent, canActivate: [AuthGuard]},
  {path: 'subject/add', component: SubjectAddEditComponent, canActivate: [AuthGuard]},
  {path: 'subject/edit/:id', component: SubjectAddEditComponent, canActivate: [AuthGuard]},
  {path: 'syllabus', component: SyllabusComponent, canActivate: [AuthGuard]},
  {path: 'syllabus/add', component: SyllabusAddEditComponent, canActivate: [AuthGuard]},
  {path: 'syllabus/edit/:id', component: SyllabusAddEditComponent, canActivate: [AuthGuard]},
  {path: 'load', component: LoadComponent, canActivate: [AuthGuard]},
  {path: 'load/add', component: LoadAddEditComponent, canActivate: [AuthGuard]},
  {path: 'load/edit/:id', component: LoadAddEditComponent, canActivate: [AuthGuard]},
  {path: '**', redirectTo: ''}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
