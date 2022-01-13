import {AfterViewInit, Component, OnInit, ViewChild} from '@angular/core';
import {MatTableDataSource} from '@angular/material/table';
import {MatSort} from '@angular/material/sort';
import {MatPaginator} from '@angular/material/paginator';
import {Router} from '@angular/router';
import {MatDialog} from '@angular/material/dialog';
import {ConfirmDialogModel, DialogConfirmComponent} from '../../shared/dialog-confirm/dialog-confirm.component';

export interface KnowledgeBranch {
  name: string;
  code: number;
}

const ELEMENT_DATA: KnowledgeBranch[] = [
  {code: 12, name: 'Інформаційні технології'},
  {code: 15, name: 'Автоматизація та приладобудування'},
  {code: 19, name: 'Архітектура та будівництво'},
];

@Component({
  selector: 'app-knowledge-branch',
  templateUrl: './knowledge-branch.component.html',
  styleUrls: ['./knowledge-branch.component.scss']
})
export class KnowledgeBranchComponent implements OnInit, AfterViewInit {

  constructor(private router: Router, public dialog: MatDialog) {
  }

  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;

  displayedColumns: string[] = ['code', 'name', 'details'];
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
    this.router.navigate(['knowledgebranch', 'add']);
  }

  edit(id): void {
    this.router.navigate(['knowledgebranch', 'edit', id]);
  }

  remove(code): any {
    const selectedBranch: KnowledgeBranch = this.dataSource.data.filter(item => item.code === code)[0];
    const dialogData = new ConfirmDialogModel('Підтвердіть дію', `Ви впевнені, що хочете видалити галузь знань "${selectedBranch.name}"?`);
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
}
