import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LoadAddEditComponent } from './load-add-edit.component';

describe('LoadAddEditComponent', () => {
  let component: LoadAddEditComponent;
  let fixture: ComponentFixture<LoadAddEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LoadAddEditComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LoadAddEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
