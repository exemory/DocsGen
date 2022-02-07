import {AfterViewInit, Component, OnInit, ViewChild} from '@angular/core';
import {Router} from '@angular/router';
import {MatDialog} from '@angular/material/dialog';
import {MatSort} from '@angular/material/sort';
import {MatPaginator} from '@angular/material/paginator';
import {MatTableDataSource} from '@angular/material/table';
import {ConfirmDialogModel, DialogConfirmComponent} from '../../shared/dialog-confirm/dialog-confirm.component';
import {FormControl} from '@angular/forms';
import {Observable} from 'rxjs';
import {map, startWith, tap} from 'rxjs/operators';
import {KnowledgeBranch} from '../../shared/interfaces/knowledge-branch';

export interface Speciality {
  name: string;
  code: number;
  knowledgeBranch: number;
  headOfSMC: number;
  guarantor: number;
}

const ELEMENT_DATA: Speciality[] = [
  {code: 121, name: 'Інженерія програмного забезпечення', knowledgeBranch: 12, headOfSMC: null, guarantor: null},
  {code: 122, name: 'Комп’ютерні науки та інформаційні технології', knowledgeBranch: 12, headOfSMC: null, guarantor: null},
  {code: 123, name: 'Комп’ютерна інженерія', knowledgeBranch: 12, headOfSMC: null, guarantor: null},
  {code: 125, name: 'Кібербезпека', knowledgeBranch: 12, headOfSMC: null, guarantor: null},
  {code: 126, name: 'Інформаційні системи та технології', knowledgeBranch: 12, headOfSMC: null, guarantor: null},
  {code: 151, name: 'Автоматизація та комп\'ютерно-інтегровані технології', knowledgeBranch: 15, headOfSMC: null, guarantor: null},
  {code: 152, name: 'Метрологія та інформаційно-вимірювальна техніка', knowledgeBranch: 15, headOfSMC: null, guarantor: null},
  {code: 153, name: 'Мікро- та наносистемна техніка', knowledgeBranch: 15, headOfSMC: null, guarantor: null},
  {code: 191, name: 'Архітектура та містобудування', knowledgeBranch: 19, headOfSMC: null, guarantor: null},
  {code: 192, name: 'Будівництво та цивільна інженерія', knowledgeBranch: 19, headOfSMC: null, guarantor: null},
  {code: 193, name: 'Геодезія та землеустрій', knowledgeBranch: 19, headOfSMC: null, guarantor: null},
];

@Component({
  selector: 'app-speciality',
  templateUrl: './speciality.component.html',
  styleUrls: ['./speciality.component.scss']
})
export class SpecialityComponent implements OnInit, AfterViewInit {
  selectedBranch = new FormControl();
  options: KnowledgeBranch[] = [];
  filteredOptions: Observable<any[]>;

  constructor(private router: Router, public dialog: MatDialog) {
  }

  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;

  displayedColumns: string[] = ['code', 'name', 'details'];
  dataSource = new MatTableDataSource(ELEMENT_DATA);

  ngOnInit(): void {
    this.filteredOptions = this.selectedBranch.valueChanges.pipe(
      startWith(''),
      map(value => this.filter(value))
    );
  }

  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  private filter(value): any {
    if (this.selectedBranch) {
      return this.options.filter(option => option.name.toLowerCase().includes(value.toLowerCase()));
    }
  }

  applyFilter(event: Event): any {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  create(): void {
    this.router.navigate(['speciality', 'add']);
  }

  edit(id): void {
    this.router.navigate(['speciality', 'edit', id]);
  }

  remove(code): any {
    const selectedSpeciality: Speciality = this.dataSource.data.filter(item => item.code === code)[0];
    const dialogData = new ConfirmDialogModel('Підтвердіть дію', `Ви впевнені, що хочете видалити галузь знань "${selectedSpeciality.name}"?`);
    const dialogRef = this.dialog.open(DialogConfirmComponent, {
      width: '400px',
      data: dialogData
    });
    dialogRef.afterClosed().subscribe(dialogResult => {
      if (dialogResult) {
        this.dataSource.data = this.dataSource.data.filter(item => item.code !== code);
      }
    });
  }

  onSelectBranch(code): any {
    // this.dataSource.data = this.dataSource.data.filter(item => item.knowledgeBranch === code);
  }
}
