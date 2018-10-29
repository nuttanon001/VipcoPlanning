import { Injectable } from '@angular/core';
import { BaseCommunicateService } from '../../shared/base-communicate.service';
import { Workgroup } from './workgroup.model';

@Injectable()
export class WorkgroupCommunicateService extends BaseCommunicateService<Workgroup> {
  constructor() { super(); }
}
