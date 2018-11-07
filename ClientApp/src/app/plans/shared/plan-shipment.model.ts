import { BaseModel } from "../../shared/base-model.model";

export interface PlanShipment extends BaseModel {
    PlanShipmentId :number;
    DateShipment ?: Date;
    SequenceNo ?:number;
    //FK
    //PlanMaster
    PlanMasterId ?: number;
}
