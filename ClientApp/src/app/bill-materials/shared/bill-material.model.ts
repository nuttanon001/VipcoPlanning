import { BaseModel } from "../../shared/base-model.model";

export interface BillMaterial extends BaseModel {
  BillofMaterialId: number;
  Code?: string;
  Name?: string;
  LevelofBom?: number;
  Description?: string;
  Remark?: string;
  // Relation
  BomParentId?: number;
  //ViewModel
  BomParentString?: string;
  BomLowLevel?: Array<BillMaterial>;
}
