import { Component, OnInit, ViewContainerRef, ViewChild } from '@angular/core';
import { BaseMasterComponent } from '../../shared/base-master-component';
import { StandardTime } from '../shared/standard-time.model';
import { StandardTimeService } from '../shared/standard-time.service';
import { StandardTimeCommuncateService } from '../shared/standard-time-communcate.service';
import { AuthService } from '../../core/auth/auth.service';
import { DialogsService } from '../../dialogs/shared/dialogs.service';
import { StandardTimeTableComponent } from '../standard-time-table/standard-time-table.component';

@Component({
  selector: 'app-standard-time-master',
  templateUrl: './standard-time-master.component.html',
  styleUrls: ['./standard-time-master.component.scss']
})
export class StandardTimeMasterComponent extends BaseMasterComponent<StandardTime,StandardTimeService,StandardTimeCommuncateService> {
  constructor(
    service: StandardTimeService,
    serviceCommuncate: StandardTimeCommuncateService,
    serviceAuth: AuthService,
    serviceDialogs: DialogsService,
    viewContainerRef:ViewContainerRef
  ) {
    super(service, serviceCommuncate, serviceAuth, serviceDialogs, viewContainerRef);
  }

  //Parameter
  @ViewChild(StandardTimeTableComponent)
  private tableComponent: StandardTimeTableComponent;

  onReloadData(): void {
    this.tableComponent.reloadData();
  }
  onCheckStatus(infoValue?: StandardTime): boolean {
    return true;
  }
}
