import { Component, OnInit } from '@angular/core';
import { BaseTableComponent } from '../../shared/base-table.component';
import { BillMaterial } from '../../bill-materials/shared/bill-material.model';
import { BillMaterialService } from '../../bill-materials/shared/bill-material.service';
import { AuthService } from '../../core/auth/auth.service';

@Component({
  selector: 'app-bill-material-lowlevel-table',
  templateUrl: './bill-material-lowlevel-table.component.html',
  styleUrls: ['./bill-material-lowlevel-table.component.scss']
})
export class BillMaterialLowlevelTableComponent extends BaseTableComponent<BillMaterial,BillMaterialService> {

  constructor(service: BillMaterialService,serviceAuth:AuthService) {
    super(service, serviceAuth);
    this.displayedColumns = ["select", "Code", "Name", "LevelofBom", "BomParentString"];
    this.isDialog = true;
    this.WhereId = 2;
  }
}
