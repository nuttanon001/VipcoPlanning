import { Component, OnInit, ViewContainerRef } from '@angular/core';
import { BaseInfoMk2Component } from '../../shared/base-info-mk2-component';
import { Workgroup } from '../shared/workgroup.model';
import { WorkgroupService } from '../shared/workgroup.service';
import { WorkgroupCommunicateService } from '../shared/workgroup-communicate.service';
import { ShareService } from '../../shared/share.service';
import { DialogsService } from '../../dialogs/shared/dialogs.service';
import { AuthService } from '../../core/auth/auth.service';
import { ActualType } from '../../actual-masters/shared/actual-detail.model';
import { Validators } from '@angular/forms';
import { EmployeeGroupMis } from '../../employees/shared/employee-group-mis.model';
import { map } from "rxjs/operators";


@Component({
  selector: 'app-workgroup-info',
  templateUrl: './workgroup-info.component.html',
  styleUrls: ['./workgroup-info.component.scss'],
  providers: [ShareService]
})
export class WorkgroupInfoComponent extends BaseInfoMk2Component<Workgroup, WorkgroupService, WorkgroupCommunicateService> {
  constructor(
    service: WorkgroupService,
    serviceCom: WorkgroupCommunicateService,
    private serviceShared: ShareService,
    private serviceDialogs: DialogsService,
    private serviceAuth: AuthService,
    private viewContainer: ViewContainerRef,
  ) { super(service, serviceCom); }

  // Parameters
  typeGroups: Array<{ name: string, value: number }>;

  // Methods
  onGetDataByKey(InfoValue: Workgroup): void {
    this.typeGroups = [
      { name: "FABRICATE", value: 1 },
      { name: "ENGINEERING", value: 2 },
      { name: "MACHINE", value: 3 },
      { name: "WELD", value: 4 },
      { name: "PAINT", value: 5 },
      { name: "INSULATION", value: 6 },
      { name: "PACK", value: 7 },
      { name: "NONE", value: 8 },
    ];

    if (InfoValue && InfoValue.WorkGroupNickNameId) {
      this.service.getOneKeyNumber(InfoValue)
        .subscribe(dbData => {
          this.InfoValue = dbData;
        }, error => console.error(error), () => this.buildForm());
    } else {
      this.InfoValue = {
        WorkGroupNickNameId: 0,
        ActualType: ActualType.FABRICATE
      };
      this.buildForm();
    }
  }
  // options: ["FABRICATE", "ENGINEERING", "MACHINE", "WELD", "PAINT", "INSULATION", "PACK","NONE"],
  //
  // Build Form
  buildForm(): void {
    this.regConfig = [
      {
        type: "radiobutton",
        label: "Type of Planning",
        name: "TypeName",
        options: this.typeGroups.map(item => item.name),
        disabled: this.denySave,
        value: this.InfoValue.TypeName,
        validations: [
          {
            name: "required",
            validator: Validators.required,
            message: "Is required"
          },
        ]
      },
      {
        type: "input",
        label: "NickName",
        inputType: "text",
        name: "NickName",
        disabled: this.denySave,
        value: this.InfoValue.NickName,
        validations: [
          {
            name: "maxlength",
            validator: Validators.maxLength(200),
            message: "Max length is 200"
          },
        ]
      },
      {
        type: "inputclick",
        label: "GroupName",
        inputType: "text",
        name: "GroupName",
        disabled: this.denySave,
        value: this.InfoValue.GroupName,
        validations: [
          {
            name: "required",
            validator: Validators.required,
            message: "Is required"
          },
        ]
      },
      {
        type: "inputclick",
        label: "ReferenceName",
        inputType: "text",
        name: "ReferenceName",
        disabled: this.denySave,
        value: this.InfoValue.ReferenceName,
      },
    ];
    // let ExcludeList = this.regConfig.map((item) => item.name);
  }

  // set communicate
  SetCommunicatetoParent(): void {
    if (this.isValid) {
      this.communicateService.toParent(this.InfoValue);
    }
  }

  // submit dynamic form
  submitDynamicForm(InfoValue?: Workgroup): void {
    if (InfoValue) {
      if (!this.denySave) {
        let template = InfoValue;
        // Template
        for (let key in template) {
          // console.log(key);
          this.InfoValue[key] = template[key];
        }
        this.isValid = true;
        this.InfoValue.ActualType = this.typeGroups.find(item => item.name == this.InfoValue.TypeName).value;
        //debug here
        // console.log(JSON.stringify(InfoValue));
        this.SetCommunicatetoParent();
      }
    }
  }

  // event from component
  FromComponents(): void {
    this.subscription2 = this.serviceShared.ToParent$.subscribe(data => {
      if (data.name.indexOf("GroupName") !== -1 || data.name.indexOf("ReferenceName") !== -1) {
        this.serviceDialogs.dialogSelectGroupMis(this.viewContainer)
          .subscribe((workgroup: EmployeeGroupMis) => {
            this.serviceShared.toChild(
              {
                name: data.name,
                value: workgroup.GroupDesc
              });

            if (data.name.indexOf("GroupName") !== -1) {
              this.InfoValue.GroupCode = workgroup.GroupMis;
            } else {
              this.InfoValue.ReferenceGroupCode = workgroup.GroupMis;
            }
          });
      }
    });
  }
}
