import { Component, OnInit } from "@angular/core";
import { FormGroup } from "@angular/forms";
import { FieldConfig } from "../field-config.model";

@Component({
  selector: "app-radiobutton",
  template: `
  <div [formGroup]="group" class="app-radiobutton">
  <label class="radio-label-padding">{{field.label}}:</label>
  <mat-radio-group [formControlName]="field.name">
    <mat-radio-button *ngFor="let item of field.options" [value]="item" style="margin-left:5px;">
      {{item}}
    </mat-radio-button>
  </mat-radio-group>
  </div>
`,
  styles: [`
 .app-radiobutton {
    width: 95%;
    margin: 5px;
    display: flex;
    align-content: center;
    align-items: center;x
  }
  .radio-label-padding {
    padding-right: 10px;
    color: grey;
  }
`]
})
export class RadiobuttonComponent implements OnInit {
  field: FieldConfig;
  group: FormGroup;
  constructor() { }
  ngOnInit() { }
}
