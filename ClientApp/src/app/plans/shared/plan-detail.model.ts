import { BaseModel } from "../../shared/base-model.model";
import { EngManhour } from "./eng-manhour.model";
import { FabManhour } from "./fab-manhour.model";
import { PackManhour } from "./pack-manhour.model";
import { WeldManhour } from "./weld-manhour.model";

export interface PlanDetail extends BaseModel {
  PlanDetailId?: number;
  Code?: string;
  Description?: string;
  ContentWeigth?: number;
  CustomerDrawingDate?: Date;
  ShopDrawingDate?: Date;
  CuttingPlanDate?: Date;
  MaterialDate?: Date;
  MachineAndPartDate?: Date;
  FabPlanSDate?: Date;
  FabPlanEDate?: Date;
  PreAssPlanSDate?: Date;
  PreAssPlanEDate?: Date;
  PaintPlanSDate?: Date;
  PaintPlanEDate?: Date;
  InsuPlanSDate?: Date;
  InsuPlanEDate?: Date;
  PackPlanSDate?: Date;
  PackPlanEDate?: Date;
  Remark?: string;
  //Relation
  ResponsibilityBy?: string;
  //WorkGroup
  AssignmentToGroup?: string;
  // PlanningProjectMaster
  PlanMasterId?: number;
  //Bill of material
  BillofMaterialId?: number;
  EngineerManHourId?: number;
  EngineerManHour?: EngManhour;
  FabricationManHourId?: number;
  FabricationManHour?: FabManhour;
  PackingManHourId?: number;
  PackingManHour?: PackManhour,
  WeldManHourId?: number;
  WeldManHour?:WeldManhour,
  //ViewModel
  ResponsibilityByString?: string;
  AssignmentToGroupString?: string;

  BomLevel2?: string;
  ShopDrawingStd?: string;
  CheckShopDrawingStd?: string;
  CuttingPlanStd?: string;
  CheckCuttingPlanStd?: string;
  PackingFrameStd?: string;
  CheckPackingFrameStd?: string;
  FabStd?: string;
  PreStd?: string;
  PackStd?: string;
  WeldStd?: string;
}
