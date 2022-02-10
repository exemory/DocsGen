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
import {Teacher} from "../../shared/interfaces/teacher";

@Component({
  selector: 'app-teacher',
  templateUrl: './teacher.component.html',
  styleUrls: ['./teacher.component.scss']
})
export class TeacherComponent implements OnInit {
  isLoading = true;

  constructor(private router: Router, public dialog: MatDialog,
              private http: HttpService, private toastr: ToastrService) {
  }

  @ViewChild(MatSort, {static: false}) set content(sort: MatSort) {
    this.dataSource.sort = sort;
  }

  @ViewChild(MatPaginator) paginator: MatPaginator | any;

  dataSource = new MatTableDataSource<Teacher>();
  displayedColumns: string[] = ['name', 'academicDegree', 'academicRank', 'email', 'phone', 'details'];

  ngOnInit(): void {
    this.http.get('teachers').subscribe({
      next: (data: Teacher[]) => this.dataSource.data = data,
      error: (e) => console.error(e),
      complete: () => this.isLoading = false
    })
  }

  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;
  }

  applyFilter(event: Event): any {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  create(): void {
    this.router.navigate(['teacher', 'add']);
  }

  edit(id: number): void {
    this.router.navigate(['teacher', 'edit', id]);
  }

  remove(id: number): any {
    const selectedTeacher: Teacher = this.dataSource.data.filter(item => item.id === id)[0];
    const dialogData = new ConfirmDialogModel('Підтвердіть дію', `Ви впевнені, що хочете видалити галузь знань "${selectedTeacher.name}"?`);

    const dialogRef = this.dialog.open(DialogConfirmComponent, {
      width: '600px',
      data: dialogData
    });

    dialogRef.afterClosed().subscribe(dialogResult => {
      if (dialogResult) {
        this.http.delete(`teachers/${id}`).subscribe({
          next: data => null,
          error: err => this.toastr.error(err.message),
          complete: () => {
            this.dataSource.data = this.dataSource.data.filter(item => item.id !== id);
            this.toastr.success('', 'Успішно видалено');
          }
        })
      }
    });
  }
}
