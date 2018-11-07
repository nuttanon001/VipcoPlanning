import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PlanShipmentInfoComponent } from './plan-shipment-info.component';

describe('PlanShipmentInfoComponent', () => {
  let component: PlanShipmentInfoComponent;
  let fixture: ComponentFixture<PlanShipmentInfoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PlanShipmentInfoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PlanShipmentInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
