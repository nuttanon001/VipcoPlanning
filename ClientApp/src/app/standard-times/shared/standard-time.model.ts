import { BaseModel } from "../../shared/base-model.model";

export interface StandardTime extends BaseModel {
  StandardTimeId: number;
  Code?: string;
  Name?: string;
  Rate?: number;
  RateUnit?: string;
  Description?: string;
  Remark?: string;
  //Relation
  GroupStandardId?: number;
  StandardTimeForId?: number;
  //ViewModel
  GroupStandardString?: string;
  ForWorkGroupString?: string;
}
