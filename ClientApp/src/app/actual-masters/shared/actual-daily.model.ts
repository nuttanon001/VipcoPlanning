import { BaseModel } from "../../shared/base-model.model";
import { ActualType, ActualDetailType } from "./actual-detail.model";

export interface ActualDaily extends BaseModel {
  ActualDailyId: number;
  Daily?: Date;
  JobNo?: string;
  GroupCode?: string;
  GroupName?: string;
  WorkShop?: string;
  NickName?: string;
  TotalManHour?: number;
  TotalManHourOT?: number;
  TotalManHourNTOT?: number;
  ActualType?: ActualType;
  ActualDetailType?: ActualDetailType;
}
