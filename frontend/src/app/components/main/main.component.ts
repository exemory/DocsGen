import {AfterViewInit, Component, ElementRef, OnInit, ViewChild} from '@angular/core';
import {HttpService} from "../../shared/services/http.service";
import {Teacher} from "../../shared/interfaces/teacher";
import {ToastrService} from "ngx-toastr";
import {FormControl} from "@angular/forms";
import {concatMap, map, Observable, startWith} from "rxjs";
import {HttpEventType, HttpHeaders, HttpResponse} from "@angular/common/http";
import {saveAs} from "file-saver";

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})
export class MainComponent implements OnInit {
  @ViewChild("fileDropRef", {static: false}) fileDropEl: ElementRef | any;
  file: any;
  progress: number = 0;
  teachers: Teacher[] = [];
  teacherControl: FormControl = new FormControl();
  filteredTeachers: Observable<Teacher[]> | any;
  fileId: number | undefined;

  constructor(private http: HttpService, private toastr: ToastrService) {
  }

  ngOnInit(): void {
    this.http.get('teachers').subscribe({
      next: data => this.teachers = data,
      error: err => this.toastr.error(err.message),
      complete: () => {
        this.filteredTeachers = this.teacherControl.valueChanges.pipe(
          startWith(''),
          map(value => (typeof value === 'string' ? value : value.name)),
          map(name => (name ? this._filter(name) : this.teachers.slice())),
        );
      }
    })
  }

  private _filter(value: string): Teacher[] {
    const filterValue = value.toLowerCase();
    return this.teachers.filter(option => option.name.toLowerCase().includes(filterValue) ||
      option.surname.toLowerCase().includes(filterValue) ||
      option.patronymic.toLowerCase().includes(filterValue));
  }

  displayFn(teacher: Teacher): string {
    return teacher ? `${teacher.surname} ${teacher.name} ${teacher.patronymic}` : '';
  }

  // on file drop handler
  onFileDropped(files: any) {
    this.uploadFile(files[0]);
  }

  // handle file from browsing
  fileBrowseHandler($event: any) {
    this.uploadFile($event.target.files[0]);
  }

  // Simulate the upload process
  uploadFile(file: File) {
    this.file = file;
    this.progress = 0;
    this.fileDropEl.nativeElement.value = "";

    const formData = new FormData();
    formData.append('file', file, file.name);

    const options = {
      reportProgress: true,
      observe: 'events',
    }

    this.http.postWithCustomOptions('templates/upload', formData, options).subscribe({
      next: event => {
        if (event.type === HttpEventType.UploadProgress) {
          this.progress = Math.round(100 * event.loaded / event.total);
        } else if (event instanceof HttpResponse) {
          this.fileId = event.body.id
          this.toastr.success('Файл повністю завантажено!')
        }
      },
      error: err => this.toastr.error(err.message),
    })
  }

  // Delete file
  deleteFile() {
    this.file = undefined;
  }

  // format bytes
  formatBytes(bytes: number, decimals = 2) {
    if (bytes === 0) {
      return "0 Bytes";
    }
    const k = 1024;
    const dm = decimals <= 0 ? 0 : decimals;
    const sizes = ["Bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB"];
    const i = Math.floor(Math.log(bytes) / Math.log(k));
    return parseFloat((bytes / Math.pow(k, i)).toFixed(dm)) + " " + sizes[i];
  }

  generate() {
    console.log(this.teacherControl)
    if (this.file) {

      const options = {
        responseType: 'blob',
        headers: new HttpHeaders({
          'Content-Type': 'application/json',
        })
      }

      if (this.teacherControl.status === 'DISABLED') {
        const teachersID = this.teachers.map(t => t.id);
        this.http.postWithCustomOptions('documents/generate/curricula', {
          "templateId": this.fileId,
          "teacherIds": teachersID
        }, options).subscribe(blob => {
          saveAs(blob, 'документи.zip');
        });
      } else {
        this.http.postWithCustomOptions('documents/generate/curricula', {
          "templateId": this.fileId,
          "teacherIds": [this.teacherControl.value.id]
        }, options).subscribe(blob => {
          saveAs(blob, 'документи.zip');
        });
      }
    }
  }
}
