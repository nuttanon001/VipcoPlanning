import { TestBed, inject } from '@angular/core/testing';

import { RateManhourService } from './rate-manhour.service';

describe('RateManhourService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [RateManhourService]
    });
  });

  it('should be created', inject([RateManhourService], (service: RateManhourService) => {
    expect(service).toBeTruthy();
  }));
});
