import { TestBed, inject } from '@angular/core/testing';

import { PlanCommuncateService } from './plan-communcate.service';

describe('PlanCommuncateService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PlanCommuncateService]
    });
  });

  it('should be created', inject([PlanCommuncateService], (service: PlanCommuncateService) => {
    expect(service).toBeTruthy();
  }));
});
