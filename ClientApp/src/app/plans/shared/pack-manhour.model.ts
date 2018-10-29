import { BaseModel } from "../../shared/base-model.model";

export interface PackManhour extends BaseModel {
  PackingManHourId?: number;
  PackingWeight?: number;
  //Packing
  PackingMH?: number;
  //Relation
  PackingId?: number;
  PackingString?: string;
}
