import { Component, OnInit, Inject } from '@angular/core';
import { BaseDialogComponent } from '../../shared/base-dialog.component';
import { StandardTime } from '../../standard-times/shared/standard-time.model';
import { StandardTimeService } from '../../standard-times/shared/standard-time.service';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-standard-time-dialog',
  templateUrl: './standard-time-dialog.component.html',
  styleUrls: ['./standard-time-dialog.component.scss'],
  providers: [StandardTimeService]
})
export class StandardTimeDialogComponent extends BaseDialogComponent<StandardTime, StandardTimeService> {

  constructor(
    public service: StandardTimeService,
    public dialogRef: MatDialogRef<StandardTimeDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public mode: number
  ) {
    super(service, dialogRef);
  }

  // on init
  onInit(): void {
    this.fastSelectd = true;
  }
}
