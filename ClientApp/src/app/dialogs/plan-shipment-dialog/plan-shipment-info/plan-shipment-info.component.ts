import { Component, OnInit } from '@angular/core';
import { PlanShipment } from '../../../plans/shared/plan-shipment.model';
import { BaseInfoDialogComponent } from '../../../shared/base-info-dialog-component';
import { FormBuilder, FormControl, Validators, AbstractControl } from '@angular/forms';
import { PlanShipmentService } from '../../../plans/shared/plan-shipment.service';
import { debounceTime, distinctUntilChanged } from 'rxjs/operators';
import { BaseInfoDialogMK2Component } from '../../../shared/base-info-dialogmk2-component';

@Component({
  selector: 'app-plan-shipment-info',
  templateUrl: './plan-shipment-info.component.html',
  styleUrls: ['./plan-shipment-info.component.scss']
})
export class PlanShipmentInfoComponent extends BaseInfoDialogMK2Component<PlanShipment> {

  constructor(
    private fb: FormBuilder,
    private service: PlanShipmentService,
  ) { super(); }
  // Parameters
  // Methods
  buildForm(): void {
    // Create Form Array
    this.InfoValueForm = this.fb.group({
      PlanShipmentId: [this.InfoValue.PlanShipmentId],
      DateShipment: new FormControl({ value: this.InfoValue.DateShipment, disabled: this.denySave },
        [Validators.required]
      ),
      SequenceNo: [this.InfoValue.SequenceNo],
      // BaseModel
      Creator: [this.InfoValue.Creator],
      CreateDate: [this.InfoValue.CreateDate],
      Modifyer: [this.InfoValue.Modifyer],
      ModifyDate: [this.InfoValue.ModifyDate],
      // fK
      PlanMasterId: [this.InfoValue.PlanMasterId],
    });

    // On Form Value
    this.InfoValueForm.valueChanges.pipe(debounceTime(250), distinctUntilChanged()).subscribe(data => {
      if (!this.InfoValueForm) { return; }
      if (this.InfoValueForm.valid) {
        this.InfoValue = this.InfoValueForm.value;
        this.SubmitOrCancel.emit({ data: this.InfoValue, force: false });
      }
    });
  }
}
