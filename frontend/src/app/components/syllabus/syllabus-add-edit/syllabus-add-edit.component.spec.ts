import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SyllabusAddEditComponent } from './syllabus-add-edit.component';

describe('SyllabusAddEditComponent', () => {
  let component: SyllabusAddEditComponent;
  let fixture: ComponentFixture<SyllabusAddEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SyllabusAddEditComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SyllabusAddEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
