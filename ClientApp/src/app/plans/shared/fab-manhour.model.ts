import { BaseModel } from "../../shared/base-model.model";

export interface FabManhour extends BaseModel {
  FabricationManHourId?: number;
  FabricationWeight?: number;
  //Fabrication
  FabricationMH?: number;
  //PerAssembly
  PerAssemblyMH?: number;
  //Relation
  //StadardTime-Fabrication
  FabricationId?: number;
  FabricationString?: string;
  //StadardTime-PerAssembly
  PerAssemblyId?: number;
  PerAssemblyString?: string;
}
