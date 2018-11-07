import { Component, OnInit, ViewContainerRef, ViewChild } from '@angular/core';
import { BaseMasterComponent } from '../../shared/base-master-component';
import { User } from '../shared/user.model';
import { UseridService } from '../shared/userid.service';
import { UseridCommunicateService } from '../shared/userid-communicate.service';
import { DialogsService } from '../../dialogs/shared/dialogs.service';
import { AuthService } from '../../core/auth/auth.service';
import { UserTableComponent } from '../user-table/user-table.component';

@Component({
  selector: 'app-user-master',
  templateUrl: './user-master.component.html',
  styleUrls: ['./user-master.component.scss']
})
export class UserMasterComponent extends BaseMasterComponent<User, UseridService, UseridCommunicateService> {

  constructor(
    service: UseridService,
    serviceCom: UseridCommunicateService,
    serviceDialog: DialogsService,
    serviceAuth: AuthService,
    viewCon: ViewContainerRef,
  ) {
    super(service, serviceCom, serviceAuth, serviceDialog, viewCon);
  }
  backToSchedule: boolean = false;
  @ViewChild(UserTableComponent)
  private tableComponent: UserTableComponent;

  onReloadData(): void {
    this.tableComponent.reloadData();
  }

  onCheckStatus(infoValue?: User): boolean {
    if (this.authService.getAuth) {
      if (this.authService.getAuth.LevelUser < 3) {
        if (this.authService.getAuth.UserName !== infoValue.Creator) {
          this.dialogsService.error("Access Denied", "You don't have permission to access.", this.viewContainerRef);
          return false;
        }
      }
    }
    return true;
  }

}
