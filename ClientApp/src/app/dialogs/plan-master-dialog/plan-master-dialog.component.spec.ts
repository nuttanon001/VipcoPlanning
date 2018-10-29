import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PlanMasterDialogComponent } from './plan-master-dialog.component';

describe('PlanMasterDialogComponent', () => {
  let component: PlanMasterDialogComponent;
  let fixture: ComponentFixture<PlanMasterDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PlanMasterDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PlanMasterDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
