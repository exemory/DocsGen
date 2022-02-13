import {Component, OnInit, ViewChild} from '@angular/core';
import {Router} from "@angular/router";
import {MatDialog} from "@angular/material/dialog";
import {HttpService} from "../../shared/services/http.service";
import {ToastrService} from "ngx-toastr";
import {MatSort} from "@angular/material/sort";
import {MatPaginator} from "@angular/material/paginator";
import {MatTableDataSource} from "@angular/material/table";
import {KnowledgeBranch} from "../../shared/interfaces/knowledge-branch";
import {
  ConfirmDialogModel,
  DialogConfirmComponent
} from "../../shared/components/dialog-confirm/dialog-confirm.component";
import {HeadOfSMC} from "../../shared/interfaces/headOfSMC";

@Component({
  selector: 'app-head',
  templateUrl: './head.component.html',
  styleUrls: ['./head.component.scss']
})
export class HeadComponent implements OnInit {
  isLoading = true;

  constructor(private router: Router, public dialog: MatDialog,
              private http: HttpService, private toastr: ToastrService) {
  }

  @ViewChild(MatSort, {static: false}) set content(sort: MatSort) {
    this.dataSource.sort = sort;
  }

  @ViewChild(MatPaginator) paginator: MatPaginator | any;

  dataSource = new MatTableDataSource<HeadOfSMC>();
  displayedColumns: string[] = ['name', 'academicDegree', 'academicRank', 'email', 'phone', 'details'];

  ngOnInit(): void {
    this.http.get('heads-of-smc').subscribe({
      next: (data: HeadOfSMC[]) => this.dataSource.data = data,
      error: err => this.toastr.error(err.message),
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
    this.router.navigate(['head', 'add']);
  }

  edit(id: number): void {
    this.router.navigate(['head', 'edit', id]);
  }

  remove(id: number): any {
    const selectedHead: HeadOfSMC = this.dataSource.data.filter(item => item.id === id)[0];
    const dialogData = new ConfirmDialogModel('Підтвердіть дію',
      `Ви впевнені, що хочете видалити голову
       "${selectedHead.surname} ${selectedHead.name} ${selectedHead.patronymic}"?`);

    const dialogRef = this.dialog.open(DialogConfirmComponent, {
      width: '600px',
      data: dialogData
    });

    dialogRef.afterClosed().subscribe(dialogResult => {
      if (dialogResult) {
        this.http.delete(`heads-of-smc/${id}`).subscribe({
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
