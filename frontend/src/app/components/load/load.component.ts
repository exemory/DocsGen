import {Component, OnInit, ViewChild} from '@angular/core';
import {Router} from "@angular/router";
import {MatDialog} from "@angular/material/dialog";
import {HttpService} from "../../shared/services/http.service";
import {ToastrService} from "ngx-toastr";
import {MatSort} from "@angular/material/sort";
import {MatPaginator} from "@angular/material/paginator";
import {MatTableDataSource} from "@angular/material/table";
import {
  ConfirmDialogModel,
  DialogConfirmComponent
} from "../../shared/components/dialog-confirm/dialog-confirm.component";
import {Load} from "../../shared/interfaces/load";
import {Teacher} from "../../shared/interfaces/teacher";
import {Subject} from "../../shared/interfaces/subject";
import {Specialty} from "../../shared/interfaces/specialty";

@Component({
  selector: 'app-load',
  templateUrl: './load.component.html',
  styleUrls: ['./load.component.scss']
})
export class LoadComponent implements OnInit {
  isLoading = true;
  teachers: Teacher[] = [];
  subjects: Subject[] = [];
  specialties: Specialty[] = [];

  constructor(private router: Router, public dialog: MatDialog,
              private http: HttpService, private toastr: ToastrService) {
  }

  @ViewChild(MatSort, {static: false}) set content(sort: MatSort) {
    this.dataSource.sort = sort;
  }

  @ViewChild(MatPaginator) paginator: MatPaginator | any;

  dataSource = new MatTableDataSource<Load>();
  displayedColumns: string[] = [
    'type', 'year', 'teacher',
    'subject', 'specialty', 'details'
  ];

  ngOnInit(): void {
    this.http.get('teacher-loads').subscribe({
      next: (data: Load[]) => this.dataSource.data = data,
      error: err => this.toastr.error(err.message),
      complete: () => this.isLoading = false
    })

    this.http.get('teachers').subscribe(data => this.teachers = data);
    this.http.get('subjects').subscribe(data => this.subjects = data);
    this.http.get('specialties').subscribe(data => this.specialties = data);
  }

  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;
  }

  applyFilter(event: Event): any {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  create(): void {
    this.router.navigate(['load', 'add']);
  }

  edit(id: number): void {
    this.router.navigate(['load', 'edit', id]);
  }

  remove(id: number): any {
    const dialogData = new ConfirmDialogModel('Підтвердіть дію',
      `Ви впевнені, що хочете видалити навантаження?`);

    const dialogRef = this.dialog.open(DialogConfirmComponent, {
      width: '600px',
      data: dialogData
    });

    dialogRef.afterClosed().subscribe(dialogResult => {
      if (dialogResult) {
        this.http.delete(`teacher-loads/${id}`).subscribe({
          error: err => this.toastr.error(err.message),
          complete: () => {
            this.dataSource.data = this.dataSource.data.filter(item => item.id !== id);
            this.toastr.success('', 'Успішно видалено');
          }
        })
      }
    });
  }

  getTeacher(id: number): string {
    const teacher: Teacher | undefined = this.teachers.find(teacher => teacher.id == id);
    return `${teacher?.surname} ${teacher?.name}`;
  }

  getSubject(id: number): string {
    const subject: Subject | undefined = this.subjects.find(subject => subject.id == id);
    return `${subject?.name}`;
  }

  getSpeciality(id: number): string {
    const specialty: Specialty | undefined = this.specialties.find(specialty => specialty.id == id);
    return `${specialty?.name}`;
  }
}
