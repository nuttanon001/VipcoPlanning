import { Injectable } from '@angular/core';
import { BaseCommunicateService } from '../../shared/base-communicate.service';
import { User } from './user.model';

@Injectable()
export class UseridCommunicateService
  extends BaseCommunicateService<User> {
  constructor() { super() }
}
