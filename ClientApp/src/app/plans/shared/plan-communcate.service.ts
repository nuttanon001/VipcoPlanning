import { Injectable } from '@angular/core';
import { BaseCommunicateService } from '../../shared/base-communicate.service';
import { PlanMaster } from './plan-master.model';

@Injectable()
export class PlanCommuncateService extends BaseCommunicateService<PlanMaster> {
  constructor() { super() }
}
