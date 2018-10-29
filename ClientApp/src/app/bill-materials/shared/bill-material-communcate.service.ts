import { Injectable } from '@angular/core';
import { BaseCommunicateService } from '../../shared/base-communicate.service';
import { BillMaterial } from './bill-material.model';

@Injectable()
export class BillMaterialCommuncateService extends BaseCommunicateService<BillMaterial> {
  constructor() { super(); }
}
