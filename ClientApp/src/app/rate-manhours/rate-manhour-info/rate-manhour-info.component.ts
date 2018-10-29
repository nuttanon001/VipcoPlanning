import { Component, OnInit, ViewContainerRef } from '@angular/core';
import { BaseInfoComponent } from '../../shared/base-info-component';
import { RateManhour } from '../shared/rate-manhour.model';
import { RateManhourService } from '../shared/rate-manhour.service';
import { RateManhourCommuncateService } from '../shared/rate-manhour-communcate.service';
import { FormBuilder, Validators } from '@angular/forms';
import { distinctUntilChanged, debounceTime } from "rxjs/operators";
import { StandardTimeForWorkgroupService } from '../../standard-times/shared/standard-time-for-workgroup.service';
import { StandardTimeForWorkgroup } from '../../standard-times/shared/standard-time-for-workgroup.model';
import { DialogsService } from '../../dialogs/shared/dialogs.service';

@Component({
  selector: 'app-rate-manhour-info',
  templateUrl: './rate-manhour-info.component.html',
  styleUrls: ['./rate-manhour-info.component.scss']
})
export class RateManhourInfoComponent extends BaseInfoComponent<RateManhour, RateManhourService, RateManhourCommuncateService> {
  constructor(
    service: RateManhourService,
    serviceCommuncate: RateManhourCommuncateService,
    private fb: FormBuilder,
    private serviceDialogs: DialogsService,
    private viewContainerRef: ViewContainerRef
  ) { super(service, serviceCommuncate); }

  //On get data from api
  onGetDataByKey(infoValue?: RateManhour): void {
    if (infoValue) {
      this.service.getOneKeyNumber(infoValue)
        .subscribe(dbData => {
          this.InfoValue = dbData;
        }, error => console.error(error), () => this.buildForm());
    } else {
      this.InfoValue = {
        RateManHourId: 0
      };
      this.buildForm();
    }
  }
  //BulidForm
  buildForm(): void {
    this.InfoValueForm = this.fb.group({
      RateManHourId: [this.InfoValue.RateManHourId],
      Description: [this.InfoValue.Description,
      [
        Validators.maxLength(200)
      ]
      ],
      RateBathPerManHour: [this.InfoValue.RateBathPerManHour,
      [
        Validators.required,
        Validators.min(0)
      ]
      ],
      ValidFrom: [this.InfoValue.ValidFrom,],
      ValidTo: [this.InfoValue.ValidTo],
      StandardTimeForId: [this.InfoValue.StandardTimeForId],
      ForWorkGroupString: [this.InfoValue.ForWorkGroupString,
      [
        Validators.required
      ]
      ],
      //BaseModel
      CreateDate: [this.InfoValue.CreateDate],
      Creator: [this.InfoValue.Creator],
      ModifyDate: [this.InfoValue.ModifyDate],
      Modifyer: [this.InfoValue.Modifyer],
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
      if (type.indexOf("StandardTimeForWorkGroup") !== -1) {
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
