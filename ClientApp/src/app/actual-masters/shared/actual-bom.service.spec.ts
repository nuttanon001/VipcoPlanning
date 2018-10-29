import { TestBed, inject } from '@angular/core/testing';

import { ActualBomService } from './actual-bom.service';

describe('ActualBomService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ActualBomService]
    });
  });

  it('should be created', inject([ActualBomService], (service: ActualBomService) => {
    expect(service).toBeTruthy();
  }));
});
