import {AfterViewInit, Component, OnInit, ViewChild} from '@angular/core';
import {MatTableDataSource} from '@angular/material/table';
import {MatSort} from '@angular/material/sort';
import {MatPaginator} from '@angular/material/paginator';
import {Router} from '@angular/router';
import {MatDialog} from '@angular/material/dialog';
import {ConfirmDialogModel, DialogConfirmComponent} from '../../shared/dialog-confirm/dialog-confirm.component';
import {KnowledgeBranch} from '../../shared/interfaces/knowledge-branch';
import {HttpService} from '../../shared/services/http.service';


@Component({
  selector: 'app-knowledge-branch',
  templateUrl: './knowledge-branch.component.html',
  styleUrls: ['./knowledge-branch.component.scss']
})
export class KnowledgeBranchComponent implements OnInit, AfterViewInit {
  isLoading = true;

  constructor(private router: Router, public dialog: MatDialog, private http: HttpService) {
  }

  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;

  dataSource = new MatTableDataSource<KnowledgeBranch>();
  displayedColumns: string[] = ['code', 'name', 'details'];

  ngOnInit(): void {
    this.http.get('knowledge-branches').subscribe((data: KnowledgeBranch[]) => this.dataSource.data = data,
      () => {
      }, () => this.isLoading = false);
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
    this.router.navigate(['knowledgebranch', 'add']);
  }

  edit(id): void {
    this.router.navigate(['knowledgebranch', 'edit', id]);
  }

  remove(id): any {
    const selectedBranch: KnowledgeBranch = this.dataSource.data.filter(item => item.id === id)[0];
    const dialogData = new ConfirmDialogModel('Підтвердіть дію', `Ви впевнені, що хочете видалити галузь знань "${selectedBranch.name}"?`);

    const dialogRef = this.dialog.open(DialogConfirmComponent, {
      width: '600px',
      data: dialogData
    });

    dialogRef.afterClosed().subscribe(dialogResult => {
      if (dialogResult) {
        this.http.delete(`knowledge-branches/${id}`).subscribe(data => console.log(data));
        this.dataSource.data = this.dataSource.data.filter(item => item.id !== id);
      }
    });
  }
}
