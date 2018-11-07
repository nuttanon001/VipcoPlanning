import { BaseModel } from "../../shared/base-model.model";
import { PlanDetail } from "./plan-detail.model";
import { PlanStatus } from "./plan-status.enum";
import { PlanShipment } from "./plan-shipment.model";

export interface PlanMaster extends BaseModel {
  PlanMasterId: number;
  ProjectName?: string;
  Revised?: number;
  DeliveryDate?: Date;
  PlanningStatus?: PlanStatus;
  ManagementName? : string;
  //Relation
  ProjectCodeMasterId?: number;
  ManagementBy?: string;
  PlanDetails?: Array<PlanDetail>;
  PlanShipments?: Array<PlanShipment>;
  //ViewModel
  ManagementByString?: string;
  PlanDetailsFormFile?: Array<PlanDetail>;
}
