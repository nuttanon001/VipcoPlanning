// angular core
import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
// 3rd party
import "rxjs/Rx";
import "hammerjs";
// services
import { DialogsService } from "./shared/dialogs.service";
// modules
import { SharedModule } from "../shared/shared.module";
// components
import { ConfirmDialog } from "./confirm-dialog/confirm-dialog.component";
import { ErrorDialog } from "./error-dialog/error-dialog.component";
import { ContextDialog } from "./context-dialog/context-dialog.component";
import { ProjectDialogComponent } from "./project-dialog/project-dialog.component";
import { GroupmisDialogComponent } from "./groupmis-dialog/groupmis-dialog.component";
import { EmployeeDialogComponent } from "./employee-dialog/employee-dialog.component";
import { ProjectTableComponent } from "./project-dialog/project-table/project-table.component";
import { EmployeeTableComponent } from "./employee-dialog/employee-table/employee-table.component";
import { GroupmisTableComponent } from "./groupmis-dialog/groupmis-table/groupmis-table.component";
import { ProjectDetailTableComponent } from './project-dialog/project-detail-table/project-detail-table.component';
import { CustomMaterialModule } from "../shared/customer-material.module";
import { GroupStandardTimeDialogComponent } from './group-standard-time-dialog/group-standard-time-dialog.component';
import { GroupStandardTimeTableComponent } from './group-standard-time-dialog/group-standard-time-table.component';
import { GroupStandardTimeInfoComponent } from './group-standard-time-dialog/group-standard-time-info.component';
import { BillMaterialDialogComponent } from './bill-material-dialog/bill-material-dialog.component';
import { BillMaterialLowlevelInfoComponent } from './bill-material-dialog/bill-material-lowlevel-info.component';
import { ProjectInfoComponent } from './project-dialog/project-info.component';
import { BillMaterialLowlevelTableComponent } from './bill-material-dialog/bill-material-lowlevel-table.component';
import { StandardTimeDialogComponent } from './standard-time-dialog/standard-time-dialog.component';
import { StandardTimeTableDialogComponent } from './standard-time-dialog/standard-time-table-dialog.component';
import { StandardTimeForWorkgroupDialogComponent } from './standard-time-for-workgroup-dialog/standard-time-for-workgroup-dialog.component';
import { StandardTimeForWorkgroupInfoComponent } from './standard-time-for-workgroup-dialog/standard-time-for-workgroup-info/standard-time-for-workgroup-info.component';
import { StandardTimeForWorkgroupTableComponent } from './standard-time-for-workgroup-dialog/standard-time-for-workgroup-table/standard-time-for-workgroup-table.component';
import { PlanMasterDialogComponent } from './plan-master-dialog/plan-master-dialog.component';
import { PlanMasterTableExtendComponent } from './plan-master-dialog/plan-master-table-extend/plan-master-table-extend.component';
import { PlanShipmentDialogComponent } from './plan-shipment-dialog/plan-shipment-dialog.component';
import { PlanShipmentInfoComponent } from './plan-shipment-dialog/plan-shipment-info/plan-shipment-info.component';

@NgModule({
  imports: [
    // angular
    FormsModule,
    CommonModule,
    ReactiveFormsModule,
    // customer Module
    SharedModule,
    CustomMaterialModule,
  ],
  declarations: [
    ErrorDialog,
    ConfirmDialog,
    ContextDialog,
    EmployeeDialogComponent,
    EmployeeTableComponent,
    ProjectDialogComponent,
    ProjectTableComponent,
    //WorkgroupDialogComponent,
    GroupmisDialogComponent,
    GroupmisTableComponent,
    ProjectDetailTableComponent,
    GroupStandardTimeDialogComponent,
    GroupStandardTimeTableComponent,
    GroupStandardTimeInfoComponent,
    BillMaterialDialogComponent,
    BillMaterialLowlevelInfoComponent,
    BillMaterialLowlevelTableComponent,
    ProjectInfoComponent,
    StandardTimeDialogComponent,
    StandardTimeTableDialogComponent,
    StandardTimeForWorkgroupDialogComponent,
    StandardTimeForWorkgroupInfoComponent,
    StandardTimeForWorkgroupTableComponent,
    PlanMasterDialogComponent,
    PlanMasterTableExtendComponent,
    PlanShipmentDialogComponent,
    PlanShipmentInfoComponent,
  ],
  providers: [
    DialogsService,
  ],
  // a list of components that are not referenced in a reachable component template.
  // doc url is :https://angular.io/guide/ngmodule-faq
  entryComponents: [
    ErrorDialog,
    ConfirmDialog,
    ContextDialog,
    GroupmisTableComponent,
    ProjectDialogComponent,
    EmployeeDialogComponent,
    GroupmisDialogComponent,
    ProjectDetailTableComponent,
    GroupStandardTimeDialogComponent,
    GroupStandardTimeTableComponent,
    GroupStandardTimeInfoComponent,
    BillMaterialDialogComponent,
    BillMaterialLowlevelInfoComponent,
    BillMaterialLowlevelTableComponent,
    ProjectInfoComponent,
    StandardTimeDialogComponent,
    StandardTimeTableDialogComponent,
    StandardTimeForWorkgroupDialogComponent,
    StandardTimeForWorkgroupInfoComponent,
    StandardTimeForWorkgroupTableComponent,
    PlanMasterDialogComponent,
    PlanMasterTableExtendComponent,
    PlanShipmentDialogComponent,
    PlanShipmentInfoComponent,
  ],
})
export class DialogsModule { }
