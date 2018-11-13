import { Component, OnInit } from '@angular/core';
import { StandardTime } from '../shared/standard-time.model';
// Services
import { StandardTimeService } from '../shared/standard-time.service';
import { AuthService } from '../../core/auth/auth.service';
// Components
import { BaseTableComponent } from '../../shared/base-table.component';

@Component({
  selector: 'app-standard-time-table',
  templateUrl: './standard-time-table.component.html',
  styleUrls: ['./standard-time-table.component.scss']
})
export class StandardTimeTableComponent extends BaseTableComponent<StandardTime,StandardTimeService> {

  constructor(
    service: StandardTimeService,
    authService: AuthService,
  ) {
    super(service, authService);
    this.displayedColumns = ["select", "Code", "Name", "Rate","RateMaster", "GroupStandardString"];
  }
}
