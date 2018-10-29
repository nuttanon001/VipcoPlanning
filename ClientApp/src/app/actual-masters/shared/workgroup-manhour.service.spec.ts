import { TestBed, inject } from '@angular/core/testing';

import { WorkgroupManhourService } from './workgroup-manhour.service';

describe('WorkgroupManhourService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [WorkgroupManhourService]
    });
  });

  it('should be created', inject([WorkgroupManhourService], (service: WorkgroupManhourService) => {
    expect(service).toBeTruthy();
  }));
});
