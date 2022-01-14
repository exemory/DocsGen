import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SyllabusesComponent } from './syllabuses.component';

describe('SyllabusesComponent', () => {
  let component: SyllabusesComponent;
  let fixture: ComponentFixture<SyllabusesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SyllabusesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SyllabusesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
