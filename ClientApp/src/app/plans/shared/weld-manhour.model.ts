import { BaseModel } from "../../shared/base-model.model";

export interface WeldManhour extends BaseModel {
  WeldManHourId?: number;
  WeldWetght?: number;
  //Weld
  WeldMH?: number;
  //Relation
  //StadardTime-Weld
  WeldId?: number;
  WeldString?: string;
}
