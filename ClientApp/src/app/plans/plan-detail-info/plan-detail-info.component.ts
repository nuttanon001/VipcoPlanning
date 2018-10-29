import { Component, OnInit, ViewContainerRef } from '@angular/core';
import { BaseInfoDialogComponent } from '../../shared/base-info-dialog-component';
import { FormBuilder, Validators } from '@angular/forms';
import { StandardTimeService } from '../../standard-times/shared/standard-time.service';
import { BillMaterialService } from '../../bill-materials/shared/bill-material.service';
import { DialogsService } from '../../dialogs/shared/dialogs.service';
import { debounceTime, distinctUntilChanged } from 'rxjs/operators';
import { PlanDetail } from '../shared/plan-detail.model';

@Component({
  selector: 'app-plan-detail-info',
  templateUrl: './plan-detail-info.component.html',
  styleUrls: ['./plan-detail-info.component.scss']
})
export class PlanDetailInfoComponent extends BaseInfoDialogComponent<PlanDetail> {

  constructor(
    private fb: FormBuilder,
    private serviceDialogs: DialogsService,
    private viewContainerRef: ViewContainerRef
  ) { super() }


  buildForm(): void {

    this.InfoValueForm = this.fb.group({
      PlanDetailId: [this.InfoValue.PlanDetailId],
      Code: [this.InfoValue.Code, [Validators.maxLength(50), Validators.required]],
      Description: [this.InfoValue.Description, [Validators.maxLength(300)]],
      ContentWeigth: [this.InfoValue.ContentWeigth, [Validators.min(0)]],
      CustomerDrawingDate: [this.InfoValue.CustomerDrawingDate],
      ShopDrawingDate: [this.InfoValue.ShopDrawingDate],
      CuttingPlanDate: [this.InfoValue.CuttingPlanDate],
      MaterialDate: [this.InfoValue.MaterialDate],
      MachineAndPartDate: [this.InfoValue.MachineAndPartDate],
      FabPlanSDate: [this.InfoValue.FabPlanSDate],
      FabPlanEDate: [this.InfoValue.FabPlanEDate],
      PreAssPlanSDate: [this.InfoValue.PreAssPlanSDate],
      PreAssPlanEDate: [this.InfoValue.PreAssPlanEDate],
      PaintPlanSDate: [this.InfoValue.PaintPlanSDate],
      PaintPlanEDate: [this.InfoValue.PaintPlanEDate],
      InsuPlanSDate: [this.InfoValue.InsuPlanSDate],
      InsuPlanEDate: [this.InfoValue.InsuPlanEDate],
      PackPlanSDate: [this.InfoValue.PackPlanSDate],
      PackPlanEDate: [this.InfoValue.PackPlanEDate],
      Remark: [this.InfoValue.Remark, [Validators.maxLength(200)]],
      //BaseMode
      CreateDate: [this.InfoValue.CreateDate],
      Creator: [this.InfoValue.Creator],
      ModifyDate: [this.InfoValue.ModifyDate],
      Modifyer: [this.InfoValue.Modifyer],
      //Relation
      ResponsibilityBy: [this.InfoValue.ResponsibilityBy],
      AssignmentToGroup: [this.InfoValue.AssignmentToGroup],
      PlanMasterId: [this.InfoValue.PlanMasterId],
      BillofMaterialId: [this.InfoValue.BillofMaterialId],
      EngineerManHourId: [this.InfoValue.EngineerManHourId],
      EngineerManHour: this.fb.group({
        EngineerManHourId: [this.InfoValue.EngineerManHour.EngineerManHourId],
        CuttingPlanCheckId: [this.InfoValue.EngineerManHour.CuttingPlanCheckId],
        CuttingPlanCheckString: [this.InfoValue.EngineerManHour.CuttingPlanCheckString],
        CuttingPlanId: [this.InfoValue.EngineerManHour.CuttingPlanId],
        CuttingPlanString: [this.InfoValue.EngineerManHour.CuttingPlanString],
        ShopDrawingCheckId: [this.InfoValue.EngineerManHour.ShopDrawingCheckId],
        ShopDrawingCheckString: [this.InfoValue.EngineerManHour.ShopDrawingCheckString],
        ShopDrawingId: [this.InfoValue.EngineerManHour.ShopDrawingId],
        ShopDrawingString: [this.InfoValue.EngineerManHour.ShopDrawingString],
        PackingCheckId: [this.InfoValue.EngineerManHour.PackingCheckId],
        PackingCheckString: [this.InfoValue.EngineerManHour.PackingCheckString],
        PackingId: [this.InfoValue.EngineerManHour.PackingId],
        PackingString: [this.InfoValue.EngineerManHour.PackingString],
      }),
      FabricationManHourId: [this.InfoValue.FabricationManHourId],
      FabricationManHour: this.fb.group({
        FabricationManHourId: [this.InfoValue.FabricationManHour.FabricationManHourId],
        FabricationId: [this.InfoValue.FabricationManHour.FabricationId],
        FabricationString: [this.InfoValue.FabricationManHour.FabricationString],
        PerAssemblyId: [this.InfoValue.FabricationManHour.PerAssemblyId],
        PerAssemblyString: [this.InfoValue.FabricationManHour.PerAssemblyString],
      }),
      PackingManHourId: [this.InfoValue.PackingManHourId],
      PackingManHour: this.fb.group({
        PackingManHourId: [this.InfoValue.PackingManHour.PackingManHourId],
        PackingId: [this.InfoValue.PackingManHour.PackingId],
        PackingString: [this.InfoValue.PackingManHour.PackingString],
      }),
      WeldManHourId: [this.InfoValue.WeldManHourId],
      WeldManHour: this.fb.group({
        WeldManHourId: [this.InfoValue.WeldManHour.WeldManHourId],
        WeldId: [this.InfoValue.WeldManHour.WeldId],
        WeldString: [this.InfoValue.WeldManHour.WeldString],
      }),
      //ViewModel
      ResponsibilityByString: [this.InfoValue.ResponsibilityByString],
      AssignmentToGroupString: [this.InfoValue.AssignmentToGroupString],
      BomLevel2: [this.InfoValue.BomLevel2],
      ShopDrawingStd: [this.InfoValue.ShopDrawingStd],
      CheckShopDrawingStd: [this.InfoValue.CheckShopDrawingStd],
      CuttingPlanStd: [this.InfoValue.CuttingPlanStd],
      CheckCuttingPlanStd: [this.InfoValue.CheckCuttingPlanStd],
      PackingFrameStd: [this.InfoValue.PackingFrameStd],
      FabStd: [this.InfoValue.FabStd],
      PreStd: [this.InfoValue.PreStd],
      PackStd: [this.InfoValue.PackStd],
      WeldStd: [this.InfoValue.WeldStd],
    });
  }

  openDialog(ControlName?: string,GroupName?:string,SubControlName:string = ""): void {
    if (ControlName) {
      if (ControlName.indexOf("BomLevel2") !== -1) {
        this.serviceDialogs.dialogInfoBomLowLevel(this.viewContainerRef, {BillofMaterialId:-99})
          .subscribe(resultBom => {
            if (resultBom) {
              this.InfoValueForm.patchValue({
                "BillofMaterialId": resultBom.BillofMaterialId,
                "BomLevel2": resultBom.Name
              });
            }
          });
      } else {
        this.serviceDialogs.dialogSelectStandardTime(this.viewContainerRef)
          .subscribe(resultStd => {
            if (resultStd) {
              this.InfoValueForm.get(`${GroupName}.${SubControlName}`).patchValue(resultStd.Name);
              this.InfoValueForm.get(`${GroupName}.${ControlName}`).patchValue(resultStd.StandardTimeId);
            }
          });
      }
    }
  }
}
