import { Component, OnInit, ViewContainerRef } from '@angular/core';
import { BaseInfoComponent } from '../../shared/base-info-component';
import { StandardTime } from '../shared/standard-time.model';
import { StandardTimeService } from '../shared/standard-time.service';
import { StandardTimeCommuncateService } from '../shared/standard-time-communcate.service';
import { DialogsService } from '../../dialogs/shared/dialogs.service';
import { FormBuilder, Validators } from '@angular/forms';
import { debounceTime, distinctUntilChanged } from 'rxjs/operators';

@Component({
  selector: 'app-standard-time-info',
  templateUrl: './standard-time-info.component.html',
  styleUrls: ['./standard-time-info.component.scss']
})
export class StandardTimeInfoComponent extends BaseInfoComponent<StandardTime,StandardTimeService,StandardTimeCommuncateService> {

  constructor(
    service: StandardTimeService,
    serviceCommuncate: StandardTimeCommuncateService,
    private serviceDialogs: DialogsService,
    private fb: FormBuilder,
    private viewContainerRef:ViewContainerRef,
  ) {
    super(service, serviceCommuncate);
  }
  //On get data from api
  onGetDataByKey(infoValue?: StandardTime): void {
    if (infoValue) {
      this.service.getOneKeyNumber(infoValue)
        .subscribe(dbData => {
          this.InfoValue = dbData;
        }, error => console.error(error), () => this.buildForm());
    } else {
      this.InfoValue = {
        StandardTimeId: 0
      };
      this.buildForm();
    }
  }
  //BulidForm
  buildForm(): void {
    this.InfoValueForm = this.fb.group({
      StandardTimeId: [this.InfoValue.StandardTimeId],
      Code: [this.InfoValue.Code,
        [
          Validators.required,
          Validators.maxLength(50)
        ]
      ],
      Name: [this.InfoValue.Name,
        [
          Validators.required,
          Validators.maxLength(200)
        ]
      ],
      Rate: [this.InfoValue.Rate,
        [
          Validators.required,
          Validators.min(1)
        ]
      ],
      RateUnit: [this.InfoValue.RateUnit,
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
      Remark: [this.InfoValue.Remark,
        [
          Validators.maxLength(200)
        ]
      ],
      GroupStandardId: [this.InfoValue.GroupStandardId],
      StandardTimeForId:[this.InfoValue.StandardTimeForId],
      //BaseModel
      CreateDate: [this.InfoValue.CreateDate],
      Creator: [this.InfoValue.Creator],
      ModifyDate: [this.InfoValue.ModifyDate],
      Modifyer: [this.InfoValue.Modifyer],
      //ViewModel
      ForWorkGroupString: [this.InfoValue.ForWorkGroupString,
        [
          Validators.required
        ]
      ],
      GroupStandardString: [this.InfoValue.GroupStandardString,
        [
          Validators.required
        ]
      ]
    });
    this.InfoValueForm.valueChanges.pipe(debounceTime(250), distinctUntilChanged()).subscribe(data => this.onValueChanged(data));

    if (this.InfoValueForm) {
      Object.keys(this.InfoValueForm.controls).forEach(field => {
        const control = this.InfoValueForm.get(field);
        control.markAsTouched({ onlySelf: true });
      });
    }
  }
  //OpenDialog
  openDialog(type: string = ""): void {
    if (type) {
      if (type.indexOf("GroupStandardTime") !== -1) {
        this.serviceDialogs.dialogInfoGroupStandardTime(this.viewContainerRef)
          .subscribe(groupStandardTime => {
            this.InfoValueForm.patchValue({
              GroupStandardId: groupStandardTime ? groupStandardTime.GroupStandardId : undefined,
              GroupStandardString: groupStandardTime ? groupStandardTime.Name : undefined
            });
          })
      } else if (type.indexOf("StandardTimeForWorkGroup") !== -1) {
        this.serviceDialogs.dialogInfoStandardTimeForWorkGroup(this.viewContainerRef)
          .subscribe(standardTimeForWorkGroup => {
            this.InfoValueForm.patchValue({
              StandardTimeForId: standardTimeForWorkGroup ? standardTimeForWorkGroup.StandardTimeForId : undefined,
              ForWorkGroupString: standardTimeForWorkGroup ? standardTimeForWorkGroup.Name : undefined
            });
          });
      }
    }
  }
}
