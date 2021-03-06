import { Component, OnInit, OnDestroy } from "@angular/core";
import { FormGroup } from "@angular/forms";
import { FieldConfig } from "../field-config.model";
import { Subscription } from "rxjs";
import { ShareService } from "../../share.service";
import { filter } from "rxjs/operators";

@Component({
  selector: "app-input-click",
  template: `
  <mat-form-field [formGroup]="group" class="app-input">
    <input matInput [formControlName]="field.name" [placeholder]="field.label"
           (click)="onSendToParent(field.name)" [type]="field.inputType" class="click-input" readonly>
    <ng-container *ngFor="let validation of field.validations;" ngProjectAs="mat-error">
      <mat-error *ngIf="group.get(field.name).hasError(validation.name)">
        {{validation.message}}
      </mat-error>
    </ng-container>
  </mat-form-field>
`,
  styles: [`
  .app-input {
    width: 45%;
    margin: 5px;

    mat-form-field {
      width: 90%;
      min-height:50px;
      margin:5px;
    }
  }
  .click-input {
    cursor: pointer;
  }
`]
})
export class InputClickComponent implements OnInit,OnDestroy {
  field: FieldConfig;
  group: FormGroup;
  subscription: Subscription;

  constructor(
    private serviceShared: ShareService
  ) { }

  ngOnInit() {
    this.subscription = this.serviceShared.toChild$.pipe(filter((item) => this.field.name == item.name)).
      subscribe(item => {
        // console.log(item);
        // Patch Value
        this.group.get(this.field.name).patchValue(item.value);
    });
  }

  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  onSendToParent(name?: any): void {
    //debug here
    this.serviceShared.toParent({name:name});
  }
 
}
