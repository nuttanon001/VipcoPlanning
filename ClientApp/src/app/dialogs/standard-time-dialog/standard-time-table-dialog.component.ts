import { Component, OnInit } from '@angular/core';
import { BaseTableComponent } from '../../shared/base-table.component';
import { StandardTime } from '../../standard-times/shared/standard-time.model';
import { StandardTimeService } from '../../standard-times/shared/standard-time.service';
import { AuthService } from '../../core/auth/auth.service';

@Component({
  selector: 'app-standard-time-table-dialog',
  templateUrl: './standard-time-table-dialog.component.html',
  styleUrls: ['./standard-time-table-dialog.component.scss']
})
export class StandardTimeTableDialogComponent extends BaseTableComponent<StandardTime, StandardTimeService> {

  constructor(
    service: StandardTimeService,
    serviceAuth: AuthService,
  ) {
    super(service, serviceAuth);
    this.displayedColumns = ["select", "Code", "Name", "Rate", "RateUnit", "GroupStandardString","ForWorkGroupString"];
    this.isDialog = true;
  }
}
