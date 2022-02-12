import {Component, OnInit, ViewChild} from '@angular/core';
import {MatDialog} from "@angular/material/dialog";
import {MatSort, Sort} from "@angular/material/sort";
import {Router} from "@angular/router";
import {MatPaginator} from "@angular/material/paginator";
import {MatTableDataSource} from "@angular/material/table";
import {HttpService} from "../../shared/services/http.service";
import {KnowledgeBranch} from "../../shared/interfaces/knowledge-branch";
import {
  ConfirmDialogModel,
  DialogConfirmComponent
} from "../../shared/components/dialog-confirm/dialog-confirm.component";
import {ToastrService} from "ngx-toastr";

@Component({
  selector: 'app-knowledge-branch',
  templateUrl: './knowledge-branch.component.html',
  styleUrls: ['./knowledge-branch.component.scss']
})
export class KnowledgeBranchComponent implements OnInit {
  isLoading = true;

  constructor(private router: Router, public dialog: MatDialog,
              private http: HttpService, private toastr: ToastrService) {
  }

  @ViewChild(MatSort, {static: false}) set content(sort: MatSort) {
    this.dataSource.sort = sort;
  }

  @ViewChild(MatPaginator) paginator: MatPaginator | any;

  dataSource = new MatTableDataSource<KnowledgeBranch>();
  displayedColumns: string[] = ['code', 'name', 'details'];

  ngOnInit(): void {
    this.http.get('knowledge-branches').subscribe({
      next: (data: KnowledgeBranch[]) => this.dataSource.data = data,
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
    this.router.navigate(['knowledge-branch', 'add']);
  }

  edit(id: number): void {
    this.router.navigate(['knowledge-branch', 'edit', id]);
  }

  remove(id: number): any {
    const selectedBranch: KnowledgeBranch = this.dataSource.data.filter(item => item.id === id)[0];
    const dialogData = new ConfirmDialogModel('Підтвердіть дію',
      `Ви впевнені, що хочете видалити галузь знань "${selectedBranch.name}"?`);

    const dialogRef = this.dialog.open(DialogConfirmComponent, {
      width: '600px',
      data: dialogData
    });

    dialogRef.afterClosed().subscribe(dialogResult => {
      if (dialogResult) {
        this.http.delete(`knowledge-branches/${id}`).subscribe({
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
