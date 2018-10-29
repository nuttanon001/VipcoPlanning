import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BillMaterialRoutingModule } from './bill-material-routing.module';
import { BillMaterialService } from './shared/bill-material.service';
import { BillMaterialCommuncateService } from './shared/bill-material-communcate.service';
import { BillMaterialCenterComponent } from './bill-material-center.component';
import { BillMaterialTableComponent } from './bill-material-table/bill-material-table.component';
import { BillMaterialMasterComponent } from './bill-material-master/bill-material-master.component';
import { BillMaterialInfoComponent } from './bill-material-info/bill-material-info.component';
import { ReactiveFormsModule } from '@angular/forms';
import { CustomMaterialModule } from '../shared/customer-material.module';
import { BillMaterialLowlevelTableComponent } from './bill-material-lowlevel-table/bill-material-lowlevel-table.component';

@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    CustomMaterialModule,
    BillMaterialRoutingModule
  ],
  declarations: [
    BillMaterialCenterComponent,
    BillMaterialTableComponent,
    BillMaterialMasterComponent,
    BillMaterialInfoComponent,
    BillMaterialLowlevelTableComponent
  ],
  providers: [
    BillMaterialService,
    BillMaterialCommuncateService
  ]
})
export class BillMaterialModule { }
