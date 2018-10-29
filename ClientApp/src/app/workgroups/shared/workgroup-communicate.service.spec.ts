import { TestBed, inject } from '@angular/core/testing';

import { WorkgroupCommunicateService } from './workgroup-communicate.service';

describe('WorkgroupCommunicateService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [WorkgroupCommunicateService]
    });
  });

  it('should be created', inject([WorkgroupCommunicateService], (service: WorkgroupCommunicateService) => {
    expect(service).toBeTruthy();
  }));
});
