import { Component, OnInit } from '@angular/core';
import { BaseTableDetailMk2Component } from '../../shared/base-table-detail-mk2.component';
import { PlanDetail } from '../shared/plan-detail.model';
import * as moment from "moment";

@Component({
  selector: 'app-plan-detailmk2',
  templateUrl: './plan-detailmk2.component.html',
  styleUrls: ['./plan-detailmk2.component.scss']
})
export class PlanDetailmk2Component extends BaseTableDetailMk2Component<PlanDetail>{
  constructor() {
    super();
    this.columns = [
      { columnName: "Code.", columnField: "Code", cell: (row: PlanDetail) => row.Code },
      { columnName: "BomLevel2", columnField: "BomLevel2", cell: (row: PlanDetail) => row.BomLevel2 },
      { columnName: "Description", columnField: "Description", cell: (row: PlanDetail) => row.Description },
      { columnName: "ResponsibilityBy", columnField: "ResponsibilityBy", cell: (row: PlanDetail) => row.ResponsibilityBy },
      { columnName: "AssignmentToGroup", columnField: "AssignmentToGroup", cell: (row: PlanDetail) => row.AssignmentToGroup },
      { columnName: "ContentWeigth", columnField: "ContentWeigth", cell: (row: PlanDetail) => row.ContentWeigth },
      { columnName: "CustomerDrawingDate", columnField: "CustomerDrawingDate", cell: (row: PlanDetail) => this.dateToString(row.CustomerDrawingDate) },
      { columnName: "ShopDrawingDate", columnField: "ShopDrawingDate", cell: (row: PlanDetail) => this.dateToString(row.ShopDrawingDate)},
      { columnName: "CuttingPlanDate", columnField: "CuttingPlanDate", cell: (row: PlanDetail) => this.dateToString(row.CuttingPlanDate)},
      { columnName: "MaterialDate", columnField: "MaterialDate", cell: (row: PlanDetail) => this.dateToString(row.MaterialDate) },
      { columnName: "MachineAndPartDate", columnField: "MachineAndPartDate", cell: (row: PlanDetail) => this.dateToString(row.MachineAndPartDate)},
      { columnName: "FabPlanSDate", columnField: "FabPlanSDate", cell: (row: PlanDetail) => this.dateToString(row.FabPlanSDate)},
      { columnName: "FabPlanEDate", columnField: "FabPlanEDate", cell: (row: PlanDetail) => this.dateToString(row.FabPlanEDate)},
      { columnName: "PreAssPlanSDate", columnField: "PreAssPlanSDate", cell: (row: PlanDetail) => this.dateToString(row.PreAssPlanSDate)},
      { columnName: "PreAssPlanEDate", columnField: "PreAssPlanEDate", cell: (row: PlanDetail) => this.dateToString(row.PreAssPlanEDate)},
      { columnName: "PaintPlanSDate", columnField: "PaintPlanSDate", cell: (row: PlanDetail) => this.dateToString(row.PaintPlanSDate)},
      { columnName: "PaintPlanEDate", columnField: "PaintPlanEDate", cell: (row: PlanDetail) => this.dateToString(row.PaintPlanEDate)},
      { columnName: "InsuPlanSDate", columnField: "InsuPlanSDate", cell: (row: PlanDetail) => this.dateToString(row.InsuPlanSDate)},
      { columnName: "InsuPlanEDate", columnField: "InsuPlanEDate", cell: (row: PlanDetail) => this.dateToString(row.InsuPlanEDate)},
      { columnName: "PackPlanSDate", columnField: "PackPlanSDate", cell: (row: PlanDetail) => this.dateToString(row.PackPlanSDate)},
      { columnName: "PackPlanEDate", columnField: "PackPlanEDate", cell: (row: PlanDetail) => this.dateToString(row.PackPlanEDate)},
      { columnName: "Remark", columnField: "Remark", cell: (row: PlanDetail) => row.Remark },
      { columnName: "CheckCuttingPlanStd", columnField: "CheckCuttingPlanStd", cell: (row: PlanDetail) => row.CheckCuttingPlanStd },
      { columnName: "CheckPackingFrameStd", columnField: "CheckPackingFrameStd", cell: (row: PlanDetail) => row.CheckPackingFrameStd },
      { columnName: "CheckShopDrawingStd", columnField: "CheckShopDrawingStd", cell: (row: PlanDetail) => row.CheckShopDrawingStd },
      { columnName: "CuttingPlanStd", columnField: "CuttingPlanStd", cell: (row: PlanDetail) => row.CuttingPlanStd },
      { columnName: "FabStd", columnField: "FabStd", cell: (row: PlanDetail) => row.FabStd },
      { columnName: "PackingFrameStd", columnField: "PackingFrameStd", cell: (row: PlanDetail) => row.PackingFrameStd },
      { columnName: "PackStd", columnField: "PackStd", cell: (row: PlanDetail) => row.PackStd },
      { columnName: "PreStd", columnField: "PreStd", cell: (row: PlanDetail) => row.PreStd },
      { columnName: "ShopDrawingStd", columnField: "ShopDrawingStd", cell: (row: PlanDetail) => row.ShopDrawingStd },
      { columnName: "WeldStd", columnField: "WeldStd", cell: (row: PlanDetail) => row.WeldStd },
    ];
    this.displayedColumns = this.columns.map(x => x.columnField);
    this.displayedColumns.splice(0, 0, "Command");
  }

  dateToString(date?: Date): string {
    return date ? moment(date).format("DD-MM-YYYY") : "";
  }
}
