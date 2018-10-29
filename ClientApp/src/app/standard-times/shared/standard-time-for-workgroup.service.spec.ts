import { TestBed, inject } from '@angular/core/testing';

import { StandardTimeForWorkgroupService } from './standard-time-for-workgroup.service';

describe('StandardTimeForWorkgroupService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [StandardTimeForWorkgroupService]
    });
  });

  it('should be created', inject([StandardTimeForWorkgroupService], (service: StandardTimeForWorkgroupService) => {
    expect(service).toBeTruthy();
  }));
});
