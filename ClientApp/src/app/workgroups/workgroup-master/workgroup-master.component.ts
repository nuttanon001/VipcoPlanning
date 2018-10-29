import { Component, OnInit, ViewContainerRef, ViewChild } from '@angular/core';
import { BaseMasterComponent } from '../../shared/base-master-component';
import { Workgroup } from '../shared/workgroup.model';
import { WorkgroupService } from '../shared/workgroup.service';
import { WorkgroupCommunicateService } from '../shared/workgroup-communicate.service';
import { DialogsService } from '../../dialogs/shared/dialogs.service';
import { AuthService } from '../../core/auth/auth.service';
import { WorkgroupTableComponent } from '../workgroup-table/workgroup-table.component';

@Component({
  selector: 'app-workgroup-master',
  templateUrl: './workgroup-master.component.html',
  styleUrls: ['./workgroup-master.component.scss']
})
export class WorkgroupMasterComponent extends BaseMasterComponent<Workgroup, WorkgroupService, WorkgroupCommunicateService> {

  constructor(
    service: WorkgroupService,
    serviceCom: WorkgroupCommunicateService,
    serviceDialog: DialogsService,
    serviceAuth: AuthService,
    viewCon: ViewContainerRef,
  ) {
    super(service, serviceCom, serviceAuth, serviceDialog, viewCon);
  }
  backToSchedule: boolean = false;
  @ViewChild(WorkgroupTableComponent)
  private tableComponent: WorkgroupTableComponent;

  onReloadData(): void {
    this.tableComponent.reloadData();
  }

  onCheckStatus(infoValue?: Workgroup): boolean {
    if (this.authService.getAuth) {
      if (this.authService.getAuth.LevelUser < 2) {
        if (this.authService.getAuth.UserName !== infoValue.Creator) {
          this.dialogsService.error("Access Denied", "You don't have permission to access.", this.viewContainerRef);
          return false;
        }
      }
    }
    return true;
  }
}
