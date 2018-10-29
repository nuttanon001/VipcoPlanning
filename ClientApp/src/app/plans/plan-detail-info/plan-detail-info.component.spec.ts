import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PlanDetailInfoComponent } from './plan-detail-info.component';

describe('PlanDetailInfoComponent', () => {
  let component: PlanDetailInfoComponent;
  let fixture: ComponentFixture<PlanDetailInfoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PlanDetailInfoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PlanDetailInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
