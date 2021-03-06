import { Component, OnInit, ViewContainerRef, ViewChild } from '@angular/core';
import { BaseMasterComponent } from '../../shared/base-master-component';
import { PlanMaster } from '../shared/plan-master.model';
import { PlanService } from '../shared/plan.service';
import { PlanCommuncateService } from '../shared/plan-communcate.service';
import { DialogsService } from '../../dialogs/shared/dialogs.service';
import { AuthService } from '../../core/auth/auth.service';
import { PlanTableComponent } from '../plan-table/plan-table.component';
import { PlanStatus } from '../shared/plan-status.enum';

@Component({
  selector: 'app-plan-master',
  templateUrl: './plan-master.component.html',
  styleUrls: ['./plan-master.component.scss']
})
export class PlanMasterComponent extends BaseMasterComponent<PlanMaster,PlanService,PlanCommuncateService> {

  constructor(
    service: PlanService,
    serviceCommuncate: PlanCommuncateService,
    serviceAuth:AuthService,
    serviceDialogs: DialogsService,
    viewContainerRef: ViewContainerRef,
  ) {
    super(service, serviceCommuncate, serviceAuth, serviceDialogs, viewContainerRef);
  }

  //Parameter
  @ViewChild(PlanTableComponent)
  private tableComponent: PlanTableComponent;
  CancelSave: boolean;
  infoValue: PlanMaster;

  CanCalculator: boolean = false; 
  // Methods
  onReloadData(): void {
    if (this.tableComponent) {
      this.tableComponent.reloadData();
    }
  }
  // Check Status
  onCheckStatus(infoValue?: PlanMaster): boolean {
    return true;
  }
  // on calculator plan-master
  onCalculatorPlanMaster(option:boolean = false): boolean {
    if (this.authService.getAuth) {
      if (this.authService.getAuth.LevelUser < 3) {
        this.dialogsService.error("Error Message", "Access denied you level can't access.", this.viewContainerRef)
          .subscribe();
        return false;
      }
    }
    if (this.infoValue) {
      this.dialogsService.confirm("Question Message", "Do you want calculator ?", this.viewContainerRef)
        .subscribe(result => {
          if (result) {
            this.onLoading = true;
            this.service.calculatorPlanMaster(this.infoValue)
              .subscribe(_result1 => {
                this.dialogsService.context("System Message", "Save complate", this.viewContainerRef).subscribe();
              }, (e: any) => this.onLoading = false, () => this.onLoading = false);
          } else {
            if (option) {
              this.onSaveComplete();
              if (this.onLoading) {
                this.onLoading = false;
              }
            }
          }
        });
      return true;
    }
    return false;
  }


  //////////////
  // OverRide //
  //////////////

  // on submit
  onSubmit(): void {
    this.canSave = false;
    this.onLoading = true;
    if (this.displayValue.CreateDate) {
      if (this.displayValue.PlanDetails) {
        this.displayValue.PlanDetails = undefined;
      }

      this.onUpdateToDataBase(this.displayValue);
    } else {
      this.onInsertToDataBase(this.displayValue);
    }
  }

  // Overrider on insert data
  onInsertToDataBase(value: PlanMaster): void {
    if (this.authService.getAuth) {
      value["Creator"] = this.authService.getAuth.UserName || "";
    }
    // insert data
    this.service.addModel(value).subscribe(
      (complete: any) => {
        if (complete) {
          this.displayValue = complete;
          this.infoValue = complete;
          if (!this.onCalculatorPlanMaster(true)) {
            this.onSaveComplete();
          }
        }
        if (this.onLoading) {
          this.onLoading = false;
        }
      },
      (error: any) => {
        console.error(error);
        this.dialogsService.error("Failed !",
          "Save failed with the following error: Invalid Identifier code !!!", this.viewContainerRef);
      }
    );
  }

  // on display
  onDetailView(value?: { data: PlanMaster, option: number }): void {
    super.onDetailView(value);
    this.CanCalculator = false;
  }
  // option
  onSelectedData(planMaster?:PlanMaster): void {
    if (planMaster != null) {
      if (planMaster.PlanningStatus !== PlanStatus.Cancel) {
        this.infoValue = Object.assign({}, planMaster);
        this.CanCalculator = !this.ShowDetail && true;
        return;
      }
    }
    this.infoValue = undefined;
    this.CanCalculator = false;
  }
}
