import { BaseModel } from "../../shared/base-model.model";

export interface RateManhour extends BaseModel {
  RateManHourId: number;
  Description?: string;
  RateBathPerManHour?: number;
  ValidFrom?: Date;
  ValidTo?: Date;
  // Relation
  StandardTimeForId?: number;
  // ViewModel
  ForWorkGroupString?: string;
}
