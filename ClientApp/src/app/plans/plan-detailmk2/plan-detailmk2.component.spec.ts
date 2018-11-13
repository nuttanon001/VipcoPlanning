import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PlanDetailmk2Component } from './plan-detailmk2.component';

describe('PlanDetailmk2Component', () => {
  let component: PlanDetailmk2Component;
  let fixture: ComponentFixture<PlanDetailmk2Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PlanDetailmk2Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PlanDetailmk2Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
