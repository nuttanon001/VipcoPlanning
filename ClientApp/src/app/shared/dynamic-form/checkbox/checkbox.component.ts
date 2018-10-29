import { Component, OnInit } from "@angular/core";
import { FormGroup } from "@angular/forms";
import { FieldConfig } from "../field-config.model";
// Component
@Component({
  selector: "app-checkbox",
  template: `
  <div class="app-checkbox" [formGroup]="group">
    <mat-checkbox [formControlName]="field.name">
      {{field.label}}
    </mat-checkbox>
  </div>
`,
  styles: [`
 .app-checkbox {
    width: 25%;
    margin: 5px;
  }
`]
})
export class CheckboxComponent implements OnInit {
  field: FieldConfig;
  group: FormGroup;
  constructor() { }
  ngOnInit() { }
}
