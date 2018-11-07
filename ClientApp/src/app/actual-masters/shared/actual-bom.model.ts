import { BaseModel } from "../../shared/base-model.model";
import { ActualType, ActualDetailType } from "./actual-detail.model";

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
  ActualType?: ActualType;
  ActualDetailType?: ActualDetailType;
  // FK
  // ActualMasterId
  ActualMasterId?: number;
}
