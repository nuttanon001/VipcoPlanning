import { TestBed, inject } from '@angular/core/testing';

import { BillMaterialService } from './bill-material.service';

describe('BillMaterialService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [BillMaterialService]
    });
  });

  it('should be created', inject([BillMaterialService], (service: BillMaterialService) => {
    expect(service).toBeTruthy();
  }));
});
