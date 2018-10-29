import { BaseModel } from "../../shared/base-model.model";

export interface StandardTimeForWorkgroup extends BaseModel {
  StandardTimeForId: number;
  Name?: string;
  Description?: string;
}
