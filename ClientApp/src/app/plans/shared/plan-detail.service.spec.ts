import { TestBed, inject } from '@angular/core/testing';

import { PlanDetailService } from './plan-detail.service';

describe('PlanDetailService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PlanDetailService]
    });
  });

  it('should be created', inject([PlanDetailService], (service: PlanDetailService) => {
    expect(service).toBeTruthy();
  }));
});
