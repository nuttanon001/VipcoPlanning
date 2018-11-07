import { Component, OnInit, Inject } from '@angular/core';
import { PlanShipment } from '../../plans/shared/plan-shipment.model';
// Components
import { BaseDialogComponent } from '../../shared/base-dialog.component';
// Services
import { PlanShipmentService } from '../../plans/shared/plan-shipment.service';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-plan-shipment-dialog',
  templateUrl: './plan-shipment-dialog.component.html',
  styleUrls: ['./plan-shipment-dialog.component.scss'],
  providers: [ PlanShipmentService ]
})
export class PlanShipmentDialogComponent extends BaseDialogComponent<PlanShipment, PlanShipmentService> {

  constructor(
    public service: PlanShipmentService,
    public dialogRef: MatDialogRef<PlanShipmentDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public InfoValue?: { data: PlanShipment, option: boolean }
  ) {
    super(service, dialogRef);
  }

  // on init
  onInit(): void {
    if (this.InfoValue.data && this.InfoValue.data.PlanShipmentId) {
      this.fastSelectd = this.InfoValue.data.PlanShipmentId === -99;
    }
  }

  // on complate or cancel entity
  onComplateOrCancelEntity(infoValue?: { data: PlanShipment | undefined, force: boolean }): void {
    if (infoValue) {
      if (infoValue.data) {
        this.getValue = infoValue.data;
        if (infoValue.force) {
          this.onSelectedClick();
        }
      }
    }
  }
}
