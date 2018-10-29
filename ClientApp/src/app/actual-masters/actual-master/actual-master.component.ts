import { Component, OnInit, ViewContainerRef, ViewChild } from '@angular/core';
import { BaseMasterComponent } from '../../shared/base-master-component';
import { ActualMaster } from '../shared/actual-master.model';
import { ActualMasterService } from '../shared/actual-master.service';
import { ActualMasterCommunicateService } from '../shared/actual-master-communicate.service';
import { DialogsService } from '../../dialogs/shared/dialogs.service';
import { AuthService } from '../../core/auth/auth.service';
import { ActualTableComponent } from '../actual-table/actual-table.component';

@Component({
  selector: 'app-actual-master',
  templateUrl: './actual-master.component.html',
  styleUrls: ['./actual-master.component.scss']
})
export class ActualMasterComponent extends BaseMasterComponent<ActualMaster, ActualMasterService, ActualMasterCommunicateService> {

  constructor(
    service: ActualMasterService,
    serviceCom: ActualMasterCommunicateService,
    serviceDialog: DialogsService,
    serviceAuth: AuthService,
    viewCon: ViewContainerRef,
  ) {
    super(service, serviceCom, serviceAuth, serviceDialog, viewCon);
  }
  backToSchedule: boolean = false;
  @ViewChild(ActualTableComponent)
  private tableComponent: ActualTableComponent;

  onReloadData(): void {
    if (this.tableComponent) {
      this.tableComponent.reloadData();
    }
  }

  onCheckStatus(infoValue?: ActualMaster): boolean {
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
