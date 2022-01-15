import { ComponentFixture, TestBed } from '@angular/core/testing';

import { KnowledgeBranchAddEditComponent } from './knowledge-branch-add-edit.component';

describe('KnowledgeBranchAddEditComponent', () => {
  let component: KnowledgeBranchAddEditComponent;
  let fixture: ComponentFixture<KnowledgeBranchAddEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ KnowledgeBranchAddEditComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(KnowledgeBranchAddEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
