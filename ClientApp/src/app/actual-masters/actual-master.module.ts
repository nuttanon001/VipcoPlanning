import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
// Modules
import { SharedModule } from '../shared/shared.module';
import { CustomMaterialModule } from '../shared/customer-material.module';
import { ActualMasterRoutingModule } from './actual-master-routing.module';
// Services
import { ActualMasterService } from './shared/actual-master.service';
import { ActualDetailService } from './shared/actual-detail.service';
import { ActualMasterCommunicateService } from './shared/actual-master-communicate.service';
// Components
import { ActualCenterComponent } from './actual-center.component';
import { ActualInfoComponent } from './actual-info/actual-info.component';
import { ActualTableComponent } from './actual-table/actual-table.component';
import { ActualMasterComponent } from './actual-master/actual-master.component';
import { WorkgroupManhourService } from './shared/workgroup-manhour.service';
import { ActualDetailTableComponent } from './actual-detail-table/actual-detail-table.component';
import { ActualChartComponent } from './actual-chart/actual-chart.component';
import { ActualReportComponent } from './actual-report/actual-report.component';
import { ActualReportTableComponent } from './actual-report-table/actual-report-table.component';
import { ActualBomService } from './shared/actual-bom.service';
import { ActutalBomTableComponent } from './actutal-bom-table/actutal-bom-table.component';

@NgModule({
  imports: [
    SharedModule,
    CommonModule,
    ReactiveFormsModule,
    CustomMaterialModule,
    ActualMasterRoutingModule,
  ],
  declarations: [
    ActualInfoComponent,
    ActualTableComponent,
    ActualMasterComponent,
    ActualCenterComponent,
    ActualDetailTableComponent,
    ActualChartComponent,
    ActualReportComponent,
    ActualReportTableComponent,
    ActutalBomTableComponent,
  ],
  providers: [
    ActualMasterService,
    ActualDetailService,
    ActualMasterCommunicateService,
    WorkgroupManhourService,
    ActualBomService,
  ]
})
export class ActualMasterModule { }
