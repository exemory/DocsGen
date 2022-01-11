import {Component, OnInit, ViewChild} from '@angular/core';
import {MatTableDataSource} from "@angular/material/table";
import {MatSort} from "@angular/material/sort";
import {MatPaginator} from "@angular/material/paginator";

export interface knowledgeBranch {
  name: string;
  code: number;
}

const ELEMENT_DATA: knowledgeBranch[] = [
  {code: 12, name: 'Інформаційні технології'},
  {code: 15, name: 'Автоматизація та приладобудування'},
  {code: 19, name: 'Архітектура та будівництво'},
];

@Component({
  selector: 'app-knowledge-branch',
  templateUrl: './knowledge-branch.component.html',
  styleUrls: ['./knowledge-branch.component.scss']
})
export class KnowledgeBranchComponent implements OnInit {
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor() { }

  ngOnInit(): void {
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  displayedColumns: string[] = ['code', 'name', 'details'];
  dataSource = new MatTableDataSource(ELEMENT_DATA);

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
}
