import { Component, OnInit,Inject } from '@angular/core';
import { BaseDialogComponent } from '../../shared/base-dialog.component';
import { GroupStandardTime } from '../../standard-times/shared/group-standard-time.model';
import { GroupStandardTimeService } from '../../standard-times/shared/group-standard-time.service';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-group-standard-time-dialog',
  templateUrl: './group-standard-time-dialog.component.html',
  styleUrls: ['./group-standard-time-dialog.component.scss'],
  providers: [GroupStandardTimeService]
})
export class GroupStandardTimeDialogComponent
  extends BaseDialogComponent<GroupStandardTime, GroupStandardTimeService> {

  constructor(
    public service: GroupStandardTimeService,
    public dialogRef: MatDialogRef<GroupStandardTimeDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public mode: number
  ) {
    super(service, dialogRef);
  }
  // Parameter
  InfoValue: GroupStandardTime;

  // on init
  onInit(): void {
    this.fastSelectd = true;
  }

  // on new entity
  onNewEntity(): void {
    this.InfoValue = {
      GroupStandardId: 0
    };
  }

  // on complate or cancel entity
  onComplateOrCancelEntity(infoValue?: GroupStandardTime): void {
    if (infoValue) {
      if (infoValue.GroupStandardId) {
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
