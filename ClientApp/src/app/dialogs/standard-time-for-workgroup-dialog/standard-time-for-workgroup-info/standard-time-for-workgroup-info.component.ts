import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { BaseInfoDialogComponent } from '../../../shared/base-info-dialog-component';
import { StandardTimeForWorkgroup } from '../../../standard-times/shared/standard-time-for-workgroup.model';

@Component({
  selector: 'app-standard-time-for-workgroup-info',
  templateUrl: './standard-time-for-workgroup-info.component.html',
  styleUrls: ['./standard-time-for-workgroup-info.component.scss']
})
export class StandardTimeForWorkgroupInfoComponent extends BaseInfoDialogComponent<StandardTimeForWorkgroup> {

  constructor(
    private fb: FormBuilder
  ) {
    super();
  }

  buildForm(): void {
    this.InfoValueForm = this.fb.group({
      StandardTimeForId: [this.InfoValue.StandardTimeForId],
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
