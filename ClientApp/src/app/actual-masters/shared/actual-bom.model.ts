import { BaseModel } from "../../shared/base-model.model";

export interface ActualBom extends BaseModel {
  ActualBomId: number;
  BomCode?: string;
  BomName?: string;
  GroupCode?: string;
  TotalManHour?: number;
  TotalManHourOT?: number;
  TotalManHourNTOT?: number;
  WeightPlan?: number;
  TotalPlanManHour?: number;
  // FK
  // ActualMasterId
  ActualMasterId?: number;
}
