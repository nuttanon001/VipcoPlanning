import { Component, OnInit } from '@angular/core';
import { BaseTableComponent } from '../../../shared/base-table.component';
import { StandardTimeForWorkgroup } from '../../../standard-times/shared/standard-time-for-workgroup.model';
import { StandardTimeForWorkgroupService } from '../../../standard-times/shared/standard-time-for-workgroup.service';
import { AuthService } from '../../../core/auth/auth.service';

@Component({
  selector: 'app-standard-time-for-workgroup-table',
  templateUrl: './standard-time-for-workgroup-table.component.html',
  styleUrls: ['./standard-time-for-workgroup-table.component.scss']
})
export class StandardTimeForWorkgroupTableComponent extends BaseTableComponent<StandardTimeForWorkgroup, StandardTimeForWorkgroupService> {

  constructor(
    service: StandardTimeForWorkgroupService,
    serviceAuth: AuthService,
  ) {
    super(service, serviceAuth);
    this.displayedColumns = ["select", "Name", "Description"];
  }
}
