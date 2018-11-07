import { TestBed, inject } from '@angular/core/testing';

import { UseridService } from './userid.service';

describe('UseridService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [UseridService]
    });
  });

  it('should be created', inject([UseridService], (service: UseridService) => {
    expect(service).toBeTruthy();
  }));
});
