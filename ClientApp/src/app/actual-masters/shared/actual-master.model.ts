import { BaseModel } from "../../shared/base-model.model";
import { ActualDetail } from "./actual-detail.model";
import { PlanStatus } from "../../plans/shared/plan-status.enum";
import { ActualBom } from "./actual-bom.model";

export interface ActualMaster extends BaseModel {
  ActualMasterId: number;
  ProjectName ?: string;
  OverTimemultiply ?:number;
  ValidFrom?:Date;
  ValidTo ?: Date;
  ActualStatus ?: PlanStatus;
  ProjectCodeMasterId?: number;
  //Relation
  // PlanMaster
  PlanMasterId ?: number;
  // ActualDetail
  ActualDetails?: Array<ActualDetail>;
  ActualBoms?: Array<ActualBom>;
}
