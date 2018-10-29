import { Component, OnInit, Inject } from '@angular/core';
import { PlanService } from '../../plans/shared/plan.service';
import { BaseDialogComponent } from '../../shared/base-dialog.component';
import { PlanMaster } from '../../plans/shared/plan-master.model';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-plan-master-dialog',
  templateUrl: './plan-master-dialog.component.html',
  styleUrls: ['./plan-master-dialog.component.scss'],
  providers: [PlanService]
})
export class PlanMasterDialogComponent extends BaseDialogComponent<PlanMaster, PlanService> {

  constructor(
    public service: PlanService,
    public dialogRef: MatDialogRef<PlanMasterDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public mode: number
  ) {
    super(service, dialogRef);
  }

  // on init
  onInit(): void {
    this.fastSelectd = true;
  }
}

