import { Component, OnInit } from '@angular/core';
import { BaseInfoDialogComponent } from '../../shared/base-info-dialog-component';
import { GroupStandardTime } from '../../standard-times/shared/group-standard-time.model';
import { GroupStandardTimeService } from '../../standard-times/shared/group-standard-time.service';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-group-standard-time-info',
  templateUrl: './group-standard-time-info.component.html',
  styleUrls: ['./group-standard-time-info.component.scss']
})
export class GroupStandardTimeInfoComponent extends BaseInfoDialogComponent<GroupStandardTime> {

  constructor(
    private fb:FormBuilder
  ) {
    super();
  }

  buildForm(): void {
    this.InfoValueForm = this.fb.group({
      GroupStandardId: [this.InfoValue.GroupStandardId],
      Name: [this.InfoValue.Name,
        [
          Validators.required,
          Validators.maxLength(50)
        ]
      ],
      Description: [this.InfoValue.Description,
        [
          Validators.maxLength(200)
        ]
      ],
      //BaseModel
      CreateDate: [this.InfoValue.CreateDate],
      Creator: [this.InfoValue.Creator],
      ModifyDate: [this.InfoValue.ModifyDate],
      Modifyer: [this.InfoValue.Modifyer],
    });
  }
}
