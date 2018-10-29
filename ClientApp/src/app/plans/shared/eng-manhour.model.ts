import { BaseModel } from "../../shared/base-model.model";

export interface EngManhour extends BaseModel {
  EngineerManHourId?: number;
  EngineerWeight?: number;
  //ShopDrawing
  ShopDrawingMH?: number;
  ShopDrawingCheckMH?: number;
  //CuttingPlan
  CuttingPlanMH?: number;
  CuttingPlanCheckMH?: number;
  //Packing
  PackingMH?: number;
  PackingCheckMH?: number;
  //Relation
  //StadardTime-ShopDrawing
  ShopDrawingId?: number;
  ShopDrawingString?: string;
  //StadardTime-ShopDrawingCheck
  ShopDrawingCheckId?: number;
  ShopDrawingCheckString?: string;
  //StadardTime-CuttingPlan
  CuttingPlanId?: number;
  CuttingPlanString?: string;
  //StadardTime-CuttingPlanCheck
  CuttingPlanCheckId?: number;
  CuttingPlanCheckString?: string;
  //StadardTime-Packing
  PackingId?: number;
  PackingString?: string;
  //StadardTime-PackingCheck
  PackingCheckId?: number;
  PackingCheckString?: string;
}
