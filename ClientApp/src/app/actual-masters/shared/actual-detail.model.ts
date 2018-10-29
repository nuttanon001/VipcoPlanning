import { BaseModel } from "../../shared/base-model.model";

export interface ActualDetail extends BaseModel {
  ActualDetailId: number;
  GroupCode?: string;
  GroupName?: string;
  ReferenceGroupCode?: string;
  ReferenceGroupName?: string;
  NickName?: string;
  WorkShop?: string;
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
  // ViewModel
  ActualTypeString?: string;
}

export enum ActualType {
  FABRICATE = 1,
  ENGINEERING,
  MACHINE,
  WELD,
  PAINT,
  INSULATION,
  PACK,
  NONE,
}

export enum ActualDetailType {
  VIPCO = 1,
  SUBCONTRACTOR
}
