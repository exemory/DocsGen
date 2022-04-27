import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';
import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {MaterialModule} from './shared/modules/material.module';
import {MainComponent} from './components/main/main.component';
import {KnowledgeBranchComponent} from './components/knowledge-branch/knowledge-branch.component';
import {SpecialityComponent} from './components/speciality/speciality.component';
import {SpecialityAddEditComponent} from './components/speciality/speciality-add-edit/speciality-add-edit.component';
import {TeacherComponent} from './components/teacher/teacher.component';
import {HeadComponent} from './components/head/head.component';
import {GuarantorComponent} from './components/guarantor/guarantor.component';
import {SyllabusComponent} from './components/syllabus/syllabus.component';
import {LoadComponent} from './components/load/load.component';
import {SubjectComponent} from './components/subject/subject.component';
import {
  KnowledgeBranchAddEditComponent
} from "./components/knowledge-branch/knowledge-branch-add-edit/knowledge-branch-add-edit.component";
import {DialogConfirmComponent} from './shared/components/dialog-confirm/dialog-confirm.component';
import {HTTP_INTERCEPTORS, HttpClientModule} from "@angular/common/http";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {MatPaginatorIntl} from "@angular/material/paginator";
import {getUkranianPaginatorIntl} from "./shared/helpers/ukranian-paginator-intl";
import {ToastrModule} from "ngx-toastr";
import {LoginComponent} from './components/login/login.component';
import {JwtInterceptor} from "./shared/helpers/jwt.interceptor";
import {TeacherAddEditComponent} from './components/teacher/teacher-add-edit/teacher-add-edit.component';
import {HeadAddEditComponent} from './components/head/head-add-edit/head-add-edit.component';
import {GuarantorAddEditComponent} from './components/guarantor/guarantor-add-edit/guarantor-add-edit.component';
import {SubjectAddEditComponent} from './components/subject/subject-add-edit/subject-add-edit.component';
import {SyllabusAddEditComponent} from './components/syllabus/syllabus-add-edit/syllabus-add-edit.component';
import {LoadAddEditComponent} from './components/load/load-add-edit/load-add-edit.component';
import {DndDirective} from './shared/directives/dnd.directive';
import {Router} from "@angular/router";
import {AuthInterceptorService} from "./shared/helpers/auth-interceptor.service";


@NgModule({
  declarations: [
    AppComponent,
    MainComponent,
    KnowledgeBranchComponent,
    KnowledgeBranchAddEditComponent,
    SpecialityComponent,
    SpecialityAddEditComponent,
    TeacherComponent,
    HeadComponent,
    GuarantorComponent,
    SyllabusComponent,
    LoadComponent,
    SubjectComponent,
    DialogConfirmComponent,
    LoginComponent,
    TeacherAddEditComponent,
    HeadAddEditComponent,
    GuarantorAddEditComponent,
    SubjectAddEditComponent,
    SyllabusAddEditComponent,
    LoadAddEditComponent,
    DndDirective,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    HttpClientModule,
    ReactiveFormsModule,
    ToastrModule.forRoot({
      timeOut: 2500,
      positionClass: 'toast-bottom-right',
      progressBar: true
    }),
    FormsModule
  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: AuthInterceptorService, multi: true},
    {provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true},
    {provide: MatPaginatorIntl, useValue: getUkranianPaginatorIntl()},
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}
