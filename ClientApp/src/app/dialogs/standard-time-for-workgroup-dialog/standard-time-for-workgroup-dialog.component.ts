import { Component, OnInit, Inject } from '@angular/core';
import { BaseDialogComponent } from '../../shared/base-dialog.component';
import { StandardTimeForWorkgroup } from '../../standard-times/shared/standard-time-for-workgroup.model';
import { StandardTimeForWorkgroupService } from '../../standard-times/shared/standard-time-for-workgroup.service';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-standard-time-for-workgroup-dialog',
  templateUrl: './standard-time-for-workgroup-dialog.component.html',
  styleUrls: ['./standard-time-for-workgroup-dialog.component.scss'],
  providers: [StandardTimeForWorkgroupService]
})
export class StandardTimeForWorkgroupDialogComponent extends BaseDialogComponent<StandardTimeForWorkgroup,StandardTimeForWorkgroupService> {

  constructor(
    public service: StandardTimeForWorkgroupService,
    public dialogRef: MatDialogRef<StandardTimeForWorkgroupDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public mode: number
  ) {
    super(service, dialogRef);
  }
  // Parameter
  InfoValue: StandardTimeForWorkgroup;

  // on init
  onInit(): void {
    this.fastSelectd = true;
  }

  // on new entity
  onNewEntity(): void {
    this.InfoValue = {
      StandardTimeForId: 0
    };
  }

  // on complate or cancel entity
  onComplateOrCancelEntity(infoValue?: StandardTimeForWorkgroup): void {
    if (infoValue) {
      if (infoValue.StandardTimeForId) {
        this.service.updateModel(infoValue)
          .subscribe(dbData => {
            if (dbData) {
              this.dialogRef.close(dbData);
            }
          });
      } else {
        this.service.addModel(infoValue)
          .subscribe(dbData => {
            if (dbData) {
              this.dialogRef.close(dbData);
            }
          });
      }
    } else {
      this.InfoValue = undefined;
    }
  }
}

