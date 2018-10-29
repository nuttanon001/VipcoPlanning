import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PlanCenterComponent } from './plan-center.component';

describe('PlanCenterComponent', () => {
  let component: PlanCenterComponent;
  let fixture: ComponentFixture<PlanCenterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PlanCenterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PlanCenterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
