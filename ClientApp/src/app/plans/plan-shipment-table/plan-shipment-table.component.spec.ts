import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PlanShipmentTableComponent } from './plan-shipment-table.component';

describe('PlanShipmentTableComponent', () => {
  let component: PlanShipmentTableComponent;
  let fixture: ComponentFixture<PlanShipmentTableComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PlanShipmentTableComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PlanShipmentTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
