import { TestBed, inject } from '@angular/core/testing';

import { UseridCommunicateService } from './userid-communicate.service';

describe('UseridCommunicateService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [UseridCommunicateService]
    });
  });

  it('should be created', inject([UseridCommunicateService], (service: UseridCommunicateService) => {
    expect(service).toBeTruthy();
  }));
});
