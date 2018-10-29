import { Component, OnInit } from '@angular/core';
import { BaseTableComponent } from '../../shared/base-table.component';
import { BillMaterial } from '../shared/bill-material.model';
import { BillMaterialService } from '../shared/bill-material.service';
import { AuthService } from '../../core/auth/auth.service';

@Component({
  selector: 'app-bill-material-table',
  templateUrl: './bill-material-table.component.html',
  styleUrls: ['./bill-material-table.component.scss']
})
export class BillMaterialTableComponent extends BaseTableComponent<BillMaterial,BillMaterialService> {

  constructor(
    service: BillMaterialService,
    serviceAuth:AuthService
  ) {
    super(service, serviceAuth);
    this.displayedColumns = ["select", "Code", "Name", "LevelofBom","BomParentString"];
  }
}
