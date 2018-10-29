import { TestBed, inject } from '@angular/core/testing';

import { ActualMasterCommunicateService } from './actual-master-communicate.service';

describe('ActualMasterCommunicateService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ActualMasterCommunicateService]
    });
  });

  it('should be created', inject([ActualMasterCommunicateService], (service: ActualMasterCommunicateService) => {
    expect(service).toBeTruthy();
  }));
});
