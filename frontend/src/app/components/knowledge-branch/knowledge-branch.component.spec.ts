import { ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { KnowledgeBranchComponent } from './knowledge-branch.component';

const testBedConfiguration = {
  imports: [
    RouterTestingModule.withRoutes([]),
  ]
};

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
});
