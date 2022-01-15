import { ComponentFixture, TestBed } from '@angular/core/testing';

import { KnowledgeBranchComponent } from './knowledge-branch.component';

describe('KnowledgeBranchComponent', () => {
  let component: KnowledgeBranchComponent;
  let fixture: ComponentFixture<KnowledgeBranchComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ KnowledgeBranchComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(KnowledgeBranchComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
