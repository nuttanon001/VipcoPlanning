import { Injectable } from '@angular/core';
import { RateManhour } from './rate-manhour.model';
import { BaseCommunicateService } from '../../shared/base-communicate.service';

@Injectable()
export class RateManhourCommuncateService extends BaseCommunicateService<RateManhour> {
  constructor() {
    super();
  }
}
