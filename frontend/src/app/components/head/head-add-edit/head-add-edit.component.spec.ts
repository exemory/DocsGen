import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HeadAddEditComponent } from './head-add-edit.component';

describe('HeadAddEditComponent', () => {
  let component: HeadAddEditComponent;
  let fixture: ComponentFixture<HeadAddEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HeadAddEditComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HeadAddEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
