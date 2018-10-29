import { TestBed, inject } from '@angular/core/testing';

import { ActualMasterService } from './actual-master.service';

describe('ActualMasterService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ActualMasterService]
    });
  });

  it('should be created', inject([ActualMasterService], (service: ActualMasterService) => {
    expect(service).toBeTruthy();
  }));
});
