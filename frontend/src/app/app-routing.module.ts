import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {MainComponent} from "./components/main/main.component";
import {KnowledgeBranchComponent} from "./components/knowledge-branch/knowledge-branch.component";
import {SpecialityComponent} from "./components/speciality/speciality.component";

const routes: Routes = [
  { path: '', component: MainComponent},
  { path: 'knowledgebranch', component: KnowledgeBranchComponent},
  { path: 'speciality', component: SpecialityComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
