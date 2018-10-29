import { TestBed, inject } from '@angular/core/testing';

import { RateManhourCommuncateService } from './rate-manhour-communcate.service';

describe('RateManhourCommuncateService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [RateManhourCommuncateService]
    });
  });

  it('should be created', inject([RateManhourCommuncateService], (service: RateManhourCommuncateService) => {
    expect(service).toBeTruthy();
  }));
});
