export interface Validator {
  name: string;
  validator: any;
  message: string;
}

export interface GroupField {
  name?: string;
  title?: string;
}

export interface FieldConfig {
  label?: string;
  name?: string;
  inputType?: string;
  options?: string[];
  collections?: any;
  type: string;
  value?: any;
  disabled?: boolean;
  hidden?: boolean;
  group?: string;
  validations?: Validator[];
}
