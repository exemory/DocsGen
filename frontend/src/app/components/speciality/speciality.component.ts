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
import {Specialty} from "../../shared/interfaces/specialty";
import {FormControl} from "@angular/forms";
import {KnowledgeBranch} from "../../shared/interfaces/knowledge-branch";


@Component({
  selector: 'app-speciality',
  templateUrl: './speciality.component.html',
  styleUrls: ['./speciality.component.scss']
})
export class SpecialityComponent implements OnInit {
  isLoading = true;
  selectedBranch = new FormControl();
  knowledgeBranches: KnowledgeBranch[] = [];


  constructor(private router: Router, public dialog: MatDialog,
              private http: HttpService, private toastr: ToastrService) {
  }

  @ViewChild(MatSort, {static: false}) set content(sort: MatSort) {
    this.dataSource.sort = sort;
  }

  @ViewChild(MatPaginator) paginator: MatPaginator | any;

  dataSource = new MatTableDataSource<Specialty>();
  displayedColumns: string[] = ['code', 'name', 'details'];

  ngOnInit(): void {
    this.http.get('specialties').subscribe({
      next: (data: Specialty[]) => this.dataSource.data = data,
      error: err => this.toastr.error(err.message),
      complete: () => this.isLoading = false
    })

    this.http.get('knowledge-branches').subscribe(data => this.knowledgeBranches = data);
  }

  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;
  }

  onSelect(): any {
    if(this.selectedBranch.value) {
      this.http.get(`specialties?branch-id=${this.selectedBranch.value}`).subscribe({
        next: (data: Specialty[]) => this.dataSource.data = data,
        error: err => this.toastr.error(err.message),
        complete: () => this.isLoading = false
      })
    } else {
      this.http.get('specialties').subscribe({
        next: (data: Specialty[]) => this.dataSource.data = data,
        error: err => this.toastr.error(err.message),
        complete: () => this.isLoading = false
      })
    }
  }

  applyFilter(event: Event): any {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  create(): void {
    this.router.navigate(['speciality', 'add']);
  }

  edit(id: number): void {
    this.router.navigate(['speciality', 'edit', id]);
  }

  remove(id: number): any {
    const selectedSpeciality: Specialty = this.dataSource.data.filter(item => item.id === id)[0];
    const dialogData = new ConfirmDialogModel('Підтвердіть дію',
      `Ви впевнені, що хочете видалити спеціальність "${selectedSpeciality.name}"?`);

    const dialogRef = this.dialog.open(DialogConfirmComponent, {
      width: '600px',
      data: dialogData
    });

    dialogRef.afterClosed().subscribe(dialogResult => {
      if (dialogResult) {
        this.http.delete(`specialties/${id}`).subscribe({
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
