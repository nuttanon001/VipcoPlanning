import { Component, OnInit } from '@angular/core';
import { BaseTableComponent } from '../../shared/base-table.component';
import { GroupStandardTime } from '../../standard-times/shared/group-standard-time.model';
import { GroupStandardTimeService } from '../../standard-times/shared/group-standard-time.service';
import { AuthService } from '../../core/auth/auth.service';

@Component({
  selector: 'app-group-standard-time-table',
  templateUrl: './group-standard-time-table.component.html',
  styleUrls: ['./group-standard-time-table.component.scss']
})
export class GroupStandardTimeTableComponent extends BaseTableComponent<GroupStandardTime,GroupStandardTimeService> {

  constructor(
    service: GroupStandardTimeService,
    serviceAuth:AuthService,
  ) {
    super(service, serviceAuth);
    this.displayedColumns = ["select", "Name", "Description"];
  }
}
