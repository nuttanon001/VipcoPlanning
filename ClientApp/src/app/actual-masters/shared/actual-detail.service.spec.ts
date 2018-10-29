import { TestBed, inject } from '@angular/core/testing';

import { ActualDetailService } from './actual-detail.service';

describe('ActualDetailService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ActualDetailService]
    });
  });

  it('should be created', inject([ActualDetailService], (service: ActualDetailService) => {
    expect(service).toBeTruthy();
  }));
});
