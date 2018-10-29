import { Component, OnInit } from '@angular/core';
import { BaseTableFontData } from '../../shared/base-table-fontdata.component';
import { BillMaterial } from '../shared/bill-material.model';

@Component({
  selector: 'app-bill-material-lowlevel-table',
  templateUrl: './bill-material-lowlevel-table.component.html',
  styleUrls: ['./bill-material-lowlevel-table.component.scss']
})
export class BillMaterialLowlevelTableComponent extends BaseTableFontData<BillMaterial> {

  constructor() {
    super();
    this.displayedColumns = ["Code", "Name", "LevelofBom", "BomParentString","Command"];
  }
}
