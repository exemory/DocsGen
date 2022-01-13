import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';
import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatButtonModule} from '@angular/material/button';
import {MainComponent} from './components/main/main.component';
import {KnowledgeBranchComponent} from './components/knowledge-branch/knowledge-branch.component';
import {SpecialityComponent} from './components/speciality/speciality.component';
import {MatTableModule} from '@angular/material/table';
import {MatInputModule} from '@angular/material/input';
import {MatSortModule} from '@angular/material/sort';
import {MatPaginatorIntl, MatPaginatorModule} from '@angular/material/paginator';
import {MatIconModule} from '@angular/material/icon';
import {MatMenuModule} from '@angular/material/menu';
import {getDutchPaginatorIntl} from './shared/dutch-paginator-intl';
import {KnowledgeBranchAddEditComponent} from './components/knowledge-branch/knowledge-branch-add-edit/knowledge-branch-add-edit.component';
import {DialogConfirmComponent} from './shared/dialog-confirm/dialog-confirm.component';
import {MatDialogModule} from '@angular/material/dialog';
import {MatCardModule} from '@angular/material/card';


@NgModule({
  declarations: [
    AppComponent,
    MainComponent,
    KnowledgeBranchComponent,
    SpecialityComponent,
    KnowledgeBranchAddEditComponent,
    DialogConfirmComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    MatFormFieldModule,
    MatToolbarModule,
    MatButtonModule,
    MatTableModule,
    MatInputModule,
    MatSortModule,
    MatPaginatorModule,
    MatIconModule,
    MatMenuModule,
    MatDialogModule,
    MatCardModule,
    ReactiveFormsModule
  ],
  providers: [
    {provide: MatPaginatorIntl, useValue: getDutchPaginatorIntl()}
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}
