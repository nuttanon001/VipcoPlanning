import { Injectable } from '@angular/core';
import { BaseCommunicateService } from '../../shared/base-communicate.service';
import { ActualMaster } from './actual-master.model';

@Injectable()
export class ActualMasterCommunicateService extends BaseCommunicateService<ActualMaster> {
  constructor() { super(); }
}
