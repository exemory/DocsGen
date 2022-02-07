import {AfterViewInit, Component, OnInit, ViewChild} from '@angular/core';
import {Router} from '@angular/router';
import {MatDialog} from '@angular/material/dialog';
import {MatSort} from '@angular/material/sort';
import {MatPaginator} from '@angular/material/paginator';
import {MatTableDataSource} from '@angular/material/table';
import {ConfirmDialogModel, DialogConfirmComponent} from '../../shared/dialog-confirm/dialog-confirm.component';

export interface Teacher {
  name: string;
  surname: string;
  patronymic: string;
  academicDegree?: string;
  academicRank?: string;
  email?: string;
  phone?: string;
}

const ELEMENT_DATA: Teacher[] = [
  {
    name: 'Василь',
    surname: 'Чапурний',
    patronymic: 'Віталійович',
    academicDegree: 'д.т.н.',
    academicRank: 'Доцент',
    email: 'chopurniy@gmail.com',
    phone: '+380639359303'
  },
  {
    name: 'Георгій',
    surname: 'Гучний',
    patronymic: 'Володимирович',
    academicRank: 'Доцент',
    email: 'gregorguchniy_34@gmail.com',
    phone: '+380933279002'
  },
  {
    name: 'Андрій',
    surname: 'Голуб',
    patronymic: 'Олегович',
    academicDegree: 'к.т.н.',
    academicRank: 'Доцент',
    email: 'andreyka483@mail.com.com'
  },
  {
    name: 'Тетяна',
    surname: 'Компанець',
    patronymic: 'Олександрівна',
    academicRank: 'Доцент',
    email: 'andreyka483@mail.com.com',
    phone: '+380664763861'
  },
  {
    name: 'Ірина',
    surname: 'Безкрай',
    patronymic: 'Анатоліївна',
    academicDegree: 'д.т.н.',
    academicRank: 'Професор',
    email: 'iragurina@gmail.com'
  },
  {
    name: 'Дмитро',
    surname: 'Подоляк',
    patronymic: 'Ігорович',
    academicDegree: 'д.т.н.',
    academicRank: 'Доцент',
    phone: '+380666208284'
  },
  {
    name: 'Анна',
    surname: 'Травнева',
    patronymic: 'Максимівна',
    academicDegree: 'к.т.н.',
    academicRank: 'Доцент',
    email: 'travanna434@mail.ua',
    phone: '+380977317052'
  }
];

@Component({
  selector: 'app-teachers',
  templateUrl: './teachers.component.html',
  styleUrls: ['./teachers.component.scss']
})
export class TeachersComponent implements OnInit, AfterViewInit {
  constructor(private router: Router, public dialog: MatDialog) {
  }

  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;

  displayedColumns: string[] = ['fio', 'academicRank', 'academicDegree', 'email', 'phone', 'details'];
  dataSource = new MatTableDataSource(ELEMENT_DATA);

  ngOnInit(): void {
  }

  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  applyFilter(event: Event): any {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  create(): void {
    this.router.navigate(['teacher', 'add']);
  }

  edit(id): void {
    this.router.navigate(['teacher', 'edit', id]);
  }

  // remove(code): any {
  //   const selectedTeacher: Teacher = this.dataSource.data.filter(item => item.code === code)[0];
  //   const dialogData = new ConfirmDialogModel('Підтвердіть дію', `Ви впевнені, що хочете видалити викладача "${selectedTeacher.name}"?`);
  //   const dialogRef = this.dialog.open(DialogConfirmComponent, {
  //     width: '400px',
  //     data: dialogData
  //   });
  //   dialogRef.afterClosed().subscribe(dialogResult => {
  //     if (dialogResult) {
  //       this.dataSource.data = this.dataSource.data.filter(item => item.code !== code);
  //     }
  //   });
  // }
}
