import { BaseModel } from "../../shared/base-model.model";
import { PlanDetail } from "./plan-detail.model";
import { PlanStatus } from "./plan-status.enum";

export interface PlanMaster extends BaseModel {
  PlanMasterId: number;
  ProjectName?: string;
  Revised?: number;
  DeliveryDate?: Date;
  PlanningStatus?: PlanStatus;
  //Relation
  ProjectCodeMasterId?: number;
  ManagementBy?: string;
  PlanDetailsFormFile?: Array<PlanDetail>;
  PlanDetails?: Array<PlanDetail>;
  //ViewModel
  ManagementByString?: string;
}
