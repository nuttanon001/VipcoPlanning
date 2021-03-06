import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PlanRoutingModule } from './plan-routing.module';
import { PlanService } from './shared/plan.service';
import { PlanCenterComponent } from './plan-center.component';
import { PlanTableComponent } from './plan-table/plan-table.component';
import { PlanMasterComponent } from './plan-master/plan-master.component';
import { PlanInfoComponent } from './plan-info/plan-info.component';
import { PlanCommuncateService } from './shared/plan-communcate.service';
import { ReactiveFormsModule } from '@angular/forms';
import { CustomMaterialModule } from '../shared/customer-material.module';
import { PlanDetailComponent } from './plan-detail/plan-detail.component';
import { PlanDetailService } from './shared/plan-detail.service';
import { PlanDetailInfoComponent } from './plan-detail-info/plan-detail-info.component';
import { PlanScheduleComponent } from './plan-schedule/plan-schedule.component';
import { PlanShipmentService } from './shared/plan-shipment.service';
import { PlanShipmentTableComponent } from './plan-shipment-table/plan-shipment-table.component';
import { PlanDetailmk2Component } from './plan-detailmk2/plan-detailmk2.component';

@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    PlanRoutingModule,
    CustomMaterialModule,
  ],
  declarations: [
    PlanCenterComponent,
    PlanTableComponent,
    PlanMasterComponent,
    PlanInfoComponent,
    PlanDetailComponent,
    PlanDetailInfoComponent,
    PlanScheduleComponent,
    PlanShipmentTableComponent,
    PlanDetailmk2Component
  ],
  providers: [
    PlanService,
    PlanCommuncateService,
    PlanDetailService,
    PlanShipmentService
  ]
})
export class PlanModule { }
