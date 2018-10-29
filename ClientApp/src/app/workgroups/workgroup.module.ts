import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { WorkgroupRoutingModule } from './workgroup-routing.module';
import { WorkgroupService } from './shared/workgroup.service';
import { WorkgroupCommunicateService } from './shared/workgroup-communicate.service';
import { WorkgroupCenterComponent } from './workgroup-center.component';
import { WorkgroupTableComponent } from './workgroup-table/workgroup-table.component';
import { WorkgroupMasterComponent } from './workgroup-master/workgroup-master.component';
import { WorkgroupInfoComponent } from './workgroup-info/workgroup-info.component';
import { ReactiveFormsModule } from '@angular/forms';
import { CustomMaterialModule } from '../shared/customer-material.module';
import { SharedModule } from "../shared/shared.module";
@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    CustomMaterialModule,
    SharedModule,
    WorkgroupRoutingModule,
  ],
  declarations: [
    WorkgroupCenterComponent,
    WorkgroupTableComponent,
    WorkgroupMasterComponent,
    WorkgroupInfoComponent],
  providers: [
    WorkgroupService,
    WorkgroupCommunicateService
  ]
})
export class WorkgroupModule { }
