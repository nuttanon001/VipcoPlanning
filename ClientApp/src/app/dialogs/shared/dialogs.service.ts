// Angular Core
import { MatDialogRef, MatDialog, MatDialogConfig } from "@angular/material";
import { Injectable, ViewContainerRef } from "@angular/core";
// rxjs
import { Observable } from "rxjs/Rx";
// module
import { Employee } from "../../employees/shared/employee.model";
import { ProjectMaster } from "../../projects/shared/project-master.model";
import { EmployeeGroupMis } from "../../employees/shared/employee-group-mis.model";
// components
import { ErrorDialog } from "../error-dialog/error-dialog.component";
import { ConfirmDialog } from "../confirm-dialog/confirm-dialog.component";
import { ContextDialog } from "../context-dialog/context-dialog.component";
import { ProjectDialogComponent } from "../project-dialog/project-dialog.component";
import { GroupmisDialogComponent } from "../groupmis-dialog/groupmis-dialog.component";
import { EmployeeDialogComponent } from "../employee-dialog/employee-dialog.component";
import { GroupStandardTime } from "../../standard-times/shared/group-standard-time.model";
import { GroupStandardTimeDialogComponent } from "../group-standard-time-dialog/group-standard-time-dialog.component";
import { BillMaterial } from "../../bill-materials/shared/bill-material.model";
import { BillMaterialDialogComponent } from "../bill-material-dialog/bill-material-dialog.component";
import { StandardTime } from "../../standard-times/shared/standard-time.model";
import { StandardTimeDialogComponent } from "../standard-time-dialog/standard-time-dialog.component";
import { StandardTimeForWorkgroup } from "../../standard-times/shared/standard-time-for-workgroup.model";
import { StandardTimeForWorkgroupDialogComponent } from "../standard-time-for-workgroup-dialog/standard-time-for-workgroup-dialog.component";
import { PlanMaster } from "../../plans/shared/plan-master.model";
import { PlanMasterDialogComponent } from "../plan-master-dialog/plan-master-dialog.component";
import { PlanShipment } from "../../plans/shared/plan-shipment.model";
import { PlanShipmentDialogComponent } from "../plan-shipment-dialog/plan-shipment-dialog.component";

@Injectable()
export class DialogsService {
  // width and height > width and height in scss master-dialog
  width: string = "80vh";
  height: string = "80vw";

  constructor(private dialog: MatDialog) { }

  public confirm(title: string, message: string, viewContainerRef: ViewContainerRef): Observable<boolean> {

    let dialogRef: MatDialogRef<ConfirmDialog>;
    let config: MatDialogConfig = new MatDialogConfig();
    config.viewContainerRef = viewContainerRef;

    dialogRef = this.dialog.open(ConfirmDialog, config);

    dialogRef.componentInstance.title = title;
    dialogRef.componentInstance.message = message;

    return dialogRef.afterClosed();
  }

  public context(title: string, message: string, viewContainerRef: ViewContainerRef): Observable<boolean> {

    let dialogRef: MatDialogRef<ContextDialog>;
    let config: MatDialogConfig = new MatDialogConfig();
    config.viewContainerRef = viewContainerRef;

    dialogRef = this.dialog.open(ContextDialog, config);

    dialogRef.componentInstance.title = title;
    dialogRef.componentInstance.message = message;

    return dialogRef.afterClosed();
  }

  public error(title: string, message: string, viewContainerRef: ViewContainerRef): Observable<boolean> {

    let dialogRef: MatDialogRef<ErrorDialog>;
    let config: MatDialogConfig = new MatDialogConfig();
    config.viewContainerRef = viewContainerRef;

    dialogRef = this.dialog.open(ErrorDialog, config);

    dialogRef.componentInstance.title = title;
    dialogRef.componentInstance.message = message;

    return dialogRef.afterClosed();
  }
  /**
   * 
   * @param viewContainerRef
   * @param type = mode of project dialog
   */
  public dialogSelectProject(viewContainerRef: ViewContainerRef, type: number = 0): Observable<ProjectMaster> {
    let dialogRef: MatDialogRef<ProjectDialogComponent>;
    let config: MatDialogConfig = new MatDialogConfig();

    // config
    config.viewContainerRef = viewContainerRef;
    config.data = type;
    // config.height = this.height;
    // config.width= this.width;
    config.hasBackdrop = true;

    // open dialog
    dialogRef = this.dialog.open(ProjectDialogComponent, config);
    return dialogRef.afterClosed();
  }
 
  /**
   * Group Mis
   * @param viewContainerRef
   * @param type = mode 0:fastSelected
   */
  public dialogSelectGroupMis(viewContainerRef: ViewContainerRef, type: number = 0): Observable<EmployeeGroupMis> {
    let dialogRef: MatDialogRef<GroupmisDialogComponent>;
    let config: MatDialogConfig = new MatDialogConfig();

    // config
    config.viewContainerRef = viewContainerRef;
    config.data = type;
    // config.height = this.height;
    // config.width= this.width;
    config.hasBackdrop = true;

    // open dialog
    dialogRef = this.dialog.open(GroupmisDialogComponent, config);
    return dialogRef.afterClosed();
  }

  /**
   * Group Mis
   * @param viewContainerRef
   * @param type = mode 0:fastSelected
   */
  public dialogSelectGroupMises(viewContainerRef: ViewContainerRef, type: number = 1): Observable<Array<EmployeeGroupMis>> {
    let dialogRef: MatDialogRef<GroupmisDialogComponent>;
    let config: MatDialogConfig = new MatDialogConfig();

    // config
    config.viewContainerRef = viewContainerRef;
    config.data = type;
    // config.height = this.height;
    // config.width= this.width;
    config.hasBackdrop = true;

    // open dialog
    dialogRef = this.dialog.open(GroupmisDialogComponent, config);
    return dialogRef.afterClosed();
  }


  /**
   * @param viewContainerRef
   * @param type = mode 0:fastSelected
   */
  public dialogSelectEmployee(viewContainerRef: ViewContainerRef, type: number = 0): Observable<Employee> {
    let dialogRef: MatDialogRef<EmployeeDialogComponent>;
    let config: MatDialogConfig = new MatDialogConfig();

    // config
    config.viewContainerRef = viewContainerRef;
    config.data = type;
    // config.height = this.height;
    // config.width= this.width;
    config.hasBackdrop = true;

    // open dialog
    dialogRef = this.dialog.open(EmployeeDialogComponent, config);
    return dialogRef.afterClosed();
  }

  /**
 * @param viewContainerRef
 * @param type = mode 0:fastSelected
 */
  public dialogSelectEmployees(viewContainerRef: ViewContainerRef, type: number = 1): Observable<Array<Employee>> {
    let dialogRef: MatDialogRef<EmployeeDialogComponent>;
    let config: MatDialogConfig = new MatDialogConfig();

    // config
    config.viewContainerRef = viewContainerRef;
    config.data = type;
    // config.height = this.height;
    // config.width= this.width;
    config.hasBackdrop = true;

    // open dialog
    dialogRef = this.dialog.open(EmployeeDialogComponent, config);
    return dialogRef.afterClosed();
  }

  /**
 * @param viewContainerRef
 * @param type = mode 0:fastSelected
 */
  public dialogInfoGroupStandardTime(viewContainerRef: ViewContainerRef, mode: number = 0): Observable<GroupStandardTime> {
    let dialogRef: MatDialogRef<GroupStandardTimeDialogComponent>;
    let config: MatDialogConfig = new MatDialogConfig();

    // config
    config.viewContainerRef = viewContainerRef;
    config.data = mode;
    // config.height = this.height;
    // config.width= this.width;
    config.hasBackdrop = true;

    // open dialog
    dialogRef = this.dialog.open(GroupStandardTimeDialogComponent, config);
    return dialogRef.afterClosed();
  }

  /**
  * @param viewContainerRef
  * @param bomLowLevel = BillMaterial
  */
  public dialogInfoBomLowLevel(viewContainerRef: ViewContainerRef, bomLowLevel: BillMaterial = undefined): Observable<BillMaterial> {
    let dialogRef: MatDialogRef<BillMaterialDialogComponent>;
    let config: MatDialogConfig = new MatDialogConfig();

    // config
    config.viewContainerRef = viewContainerRef;
    config.data = bomLowLevel;
    // config.height = this.height;
    // config.width= this.width;
    config.hasBackdrop = true;

    // open dialog
    dialogRef = this.dialog.open(BillMaterialDialogComponent, config);
    return dialogRef.afterClosed();
  }

  /**
  * @param viewContainerRef
  * @param bomLowLevel = BillMaterial
  */
  public dialogSelectStandardTime(viewContainerRef: ViewContainerRef, mode:number = 0): Observable<StandardTime> {
    let dialogRef: MatDialogRef<StandardTimeDialogComponent>;
    let config: MatDialogConfig = new MatDialogConfig();

    // config
    config.viewContainerRef = viewContainerRef;
    config.data = mode;
    // config.height = this.height;
    // config.width= this.width;
    config.hasBackdrop = true;

    // open dialog
    dialogRef = this.dialog.open(StandardTimeDialogComponent, config);
    return dialogRef.afterClosed();
  }

  /**
  * @param viewContainerRef
  * @param type = mode 0:fastSelected
  */
  public dialogInfoStandardTimeForWorkGroup(viewContainerRef: ViewContainerRef, mode: number = 0): Observable<StandardTimeForWorkgroup> {
    let dialogRef: MatDialogRef<StandardTimeForWorkgroupDialogComponent>;
    let config: MatDialogConfig = new MatDialogConfig();

    // config
    config.viewContainerRef = viewContainerRef;
    config.data = mode;
    // config.height = this.height;
    // config.width= this.width;
    config.hasBackdrop = true;

    // open dialog
    dialogRef = this.dialog.open(StandardTimeForWorkgroupDialogComponent, config);
    return dialogRef.afterClosed();
  }

  /**
  * @param viewContainerRef
  * @param type = mode 0:fastSelected
  */
  public dialogSelectPlanMaster(viewContainerRef: ViewContainerRef, mode: number = 0): Observable<PlanMaster> {
    let dialogRef: MatDialogRef<PlanMasterDialogComponent>;
    let config: MatDialogConfig = new MatDialogConfig();

    // config
    config.viewContainerRef = viewContainerRef;
    config.data = mode;
    // config.height = this.height;
    // config.width= this.width;
    config.hasBackdrop = true;

    // open dialog
    dialogRef = this.dialog.open(PlanMasterDialogComponent, config);
    return dialogRef.afterClosed();
  }

  /**
  * @param viewContainerRef JobcardDetailDialogComponent
  * @param type = mode 0:fastSelected
  */
  public dialogInfoPlanShipment(viewContainerRef: ViewContainerRef, jobDetail: PlanShipment = undefined,option:boolean = false): Observable<PlanShipment> {
    let dialogRef: MatDialogRef<PlanShipmentDialogComponent>;
    let config: MatDialogConfig = new MatDialogConfig();

    // config
    config.viewContainerRef = viewContainerRef;
    config.data = { data: jobDetail, option: option };
    // config.height = this.height;
    // config.width= this.width;
    config.hasBackdrop = true;

    // open dialog
    dialogRef = this.dialog.open(PlanShipmentDialogComponent, config);
    return dialogRef.afterClosed();
  }

}
