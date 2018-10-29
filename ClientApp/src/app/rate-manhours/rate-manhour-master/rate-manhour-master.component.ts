import { Component, OnInit, ViewContainerRef, ViewChild } from '@angular/core';
import { BaseRestService } from '../../shared/base-rest.service';
import { RateManhour } from '../shared/rate-manhour.model';
import { RateManhourService } from '../shared/rate-manhour.service';
import { RateManhourCommuncateService } from '../shared/rate-manhour-communcate.service';
import { DialogsService } from '../../dialogs/shared/dialogs.service';
import { AuthService } from '../../core/auth/auth.service';
import { BaseMasterComponent } from '../../shared/base-master-component';
import { RateManhourTableComponent } from '../rate-manhour-table/rate-manhour-table.component';

@Component({
  selector: 'app-rate-manhour-master',
  templateUrl: './rate-manhour-master.component.html',
  styleUrls: ['./rate-manhour-master.component.scss']
})
export class RateManhourMasterComponent extends BaseMasterComponent<RateManhour,RateManhourService,RateManhourCommuncateService> {
  constructor(
    service: RateManhourService,
    serviceCommuncate: RateManhourCommuncateService,
    serviceDialog: DialogsService,
    serviceAuth: AuthService,
    viewContainerRef:ViewContainerRef
  ) {
    super(service,serviceCommuncate,serviceAuth,serviceDialog,viewContainerRef);
  }

  //Parameter
  @ViewChild(RateManhourTableComponent)
  private tableComponent: RateManhourTableComponent;

  onReloadData(): void {
    this.tableComponent.reloadData();
  }

  onCheckStatus(infoValue?: RateManhour): boolean {
    return true;
  }
}
