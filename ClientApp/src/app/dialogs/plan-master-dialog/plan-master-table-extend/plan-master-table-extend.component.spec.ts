import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PlanMasterTableExtendComponent } from './plan-master-table-extend.component';

describe('PlanMasterTableExtendComponent', () => {
  let component: PlanMasterTableExtendComponent;
  let fixture: ComponentFixture<PlanMasterTableExtendComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PlanMasterTableExtendComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PlanMasterTableExtendComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
