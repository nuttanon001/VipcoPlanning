import { TestBed, inject } from '@angular/core/testing';

import { ActualDailyService } from './actual-daily.service';

describe('ActualDailyService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ActualDailyService]
    });
  });

  it('should be created', inject([ActualDailyService], (service: ActualDailyService) => {
    expect(service).toBeTruthy();
  }));
});
