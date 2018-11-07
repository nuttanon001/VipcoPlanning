import { TestBed, inject } from '@angular/core/testing';

import { PlanShipmentService } from './plan-shipment.service';

describe('PlanShipmentService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PlanShipmentService]
    });
  });

  it('should be created', inject([PlanShipmentService], (service: PlanShipmentService) => {
    expect(service).toBeTruthy();
  }));
});
