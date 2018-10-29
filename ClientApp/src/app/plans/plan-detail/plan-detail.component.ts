import { Component, OnInit } from '@angular/core';
import { BaseTableFontData } from '../../shared/base-table-fontdata.component';
import { PlanDetail } from '../shared/plan-detail.model';

@Component({
  selector: 'app-plan-detail',
  templateUrl: './plan-detail.component.html',
  styleUrls: ['./plan-detail.component.scss']
})
export class PlanDetailComponent extends BaseTableFontData<PlanDetail> {
  constructor() {
    super();
    this.isLoadingResults = true;
    this.displayedColumns = ["Command", "Code", "BomLevel2", "Description", "ResponsibilityBy", "AssignmentToGroup", "ContentWeigth",
      "CustomerDrawingDate", "ShopDrawingDate", "CuttingPlanDate", "MaterialDate", "MachineAndPartDate", "FabPlanSDate",
      "FabPlanEDate", "PreAssPlanSDate", "PreAssPlanEDate", "PaintPlanSDate", "PaintPlanEDate", "InsuPlanSDate", "InsuPlanEDate",
      "PackPlanSDate", "PackPlanEDate", "Remark", "CheckCuttingPlanStd","CheckPackingFrameStd",
      "CheckShopDrawingStd","CuttingPlanStd","FabStd","PackingFrameStd","PackStd",
      "PreStd", "ShopDrawingStd", "WeldStd"];
  }
}
