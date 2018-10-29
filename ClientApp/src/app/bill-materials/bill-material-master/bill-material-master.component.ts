//AngularCore
import { Component, OnInit, ViewContainerRef, ViewChild } from '@angular/core';
//Models
import { BillMaterial } from '../shared/bill-material.model';
//Services
import { AuthService } from '../../core/auth/auth.service';
import { DialogsService } from '../../dialogs/shared/dialogs.service';
import { BillMaterialService } from '../shared/bill-material.service';
import { BillMaterialCommuncateService } from '../shared/bill-material-communcate.service';
//Components
import { BaseMasterComponent } from '../../shared/base-master-component';
import { BillMaterialTableComponent } from '../bill-material-table/bill-material-table.component';

@Component({
  selector: 'app-bill-material-master',
  templateUrl: './bill-material-master.component.html',
  styleUrls: ['./bill-material-master.component.scss']
})
export class BillMaterialMasterComponent extends BaseMasterComponent<BillMaterial,BillMaterialService,BillMaterialCommuncateService> {

  constructor(
    service: BillMaterialService,
    serviceCommuncate: BillMaterialCommuncateService,
    serviceAuth: AuthService,
    serviceDialogs: DialogsService,
    viewContainerRef:ViewContainerRef
  ) {
    super(service, serviceCommuncate, serviceAuth, serviceDialogs, viewContainerRef);
  }

  @ViewChild(BillMaterialTableComponent)
  private tableComponent: BillMaterialTableComponent;

  onReloadData(): void {
    this.tableComponent.reloadData();
  }

  onCheckStatus(infoValue?: BillMaterial): boolean {
    return true;
  }

  onInsertBomFromSageX3(): void {
    this.onLoading = true;
    this.service.getAllFromSageX3()
      .subscribe(dbBom => {
        if (dbBom) {
          let creator = "Someone";
          if (this.authService.getAuth) {
            creator = this.authService.getAuth.UserName || "";
          }

          let listBom: Array<BillMaterial> = new Array;
          dbBom.forEach(item => {
            listBom.push({
              BillofMaterialId: 0,
              LevelofBom: 2,
              Code: item.BomLevelCode,
              Name: item.BomLevelName,
              Creator: creator,
            });
          });
          if (listBom && listBom.length > 0) {
            this.service.insertFromSageX3(listBom)
              .subscribe(result => {
                if (result && result.Result) {
                  this.onSaveComplete();
                }
              },() => this.onLoading = false,() => this.onLoading = false);
          }
        }
      }, () => this.onLoading = false);
  }
}
