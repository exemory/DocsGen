import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GuarantorAddEditComponent } from './guarantor-add-edit.component';

describe('GuarantorAddEditComponent', () => {
  let component: GuarantorAddEditComponent;
  let fixture: ComponentFixture<GuarantorAddEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GuarantorAddEditComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GuarantorAddEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
