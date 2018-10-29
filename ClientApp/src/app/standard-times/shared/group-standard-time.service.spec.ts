import { TestBed, inject } from '@angular/core/testing';

import { GroupStandardTimeService } from './group-standard-time.service';

describe('GroupStandardTimeService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [GroupStandardTimeService]
    });
  });

  it('should be created', inject([GroupStandardTimeService], (service: GroupStandardTimeService) => {
    expect(service).toBeTruthy();
  }));
});
