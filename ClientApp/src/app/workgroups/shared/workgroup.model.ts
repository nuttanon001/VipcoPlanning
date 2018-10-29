import { BaseModel } from "../../shared/base-model.model";
import { ActualType } from "../../actual-masters/shared/actual-detail.model";

export interface Workgroup extends BaseModel {
  WorkGroupNickNameId: number;
  NickName?: string;
  ActualType?: ActualType;
  //Relation
  GroupCode?: string;
  ReferenceGroupCode?: string;
  GroupName?: string;
  TypeName?: string;
  ReferenceName?: string;
}
