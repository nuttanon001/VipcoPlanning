import { TestBed, inject } from '@angular/core/testing';

import { BillMaterialCommuncateService } from './bill-material-communcate.service';

describe('BillMaterialCommuncateService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [BillMaterialCommuncateService]
    });
  });

  it('should be created', inject([BillMaterialCommuncateService], (service: BillMaterialCommuncateService) => {
    expect(service).toBeTruthy();
  }));
});
