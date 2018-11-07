import { Component, OnInit, ViewContainerRef } from '@angular/core';
import { BaseInfoMk2Component } from '../../shared/base-info-mk2-component';
import { UseridService } from '../shared/userid.service';
import { UseridCommunicateService } from '../shared/userid-communicate.service';
import { User } from '../shared/user.model';
import { DialogsService } from '../../dialogs/shared/dialogs.service';
import { AuthService } from '../../core/auth/auth.service';
import { Validators } from '@angular/forms';

@Component({
  selector: 'app-user-info',
  templateUrl: './user-info.component.html',
  styleUrls: ['./user-info.component.scss']
})
export class UserInfoComponent extends BaseInfoMk2Component<User,UseridService,UseridCommunicateService> {
  constructor(
    service: UseridService,
    serviceCom: UseridCommunicateService,
    private serviceDialogs: DialogsService,
    private serviceAuth: AuthService,
    private viewContainer: ViewContainerRef,
  ) { super(service, serviceCom); }

  onGetDataByKey(InfoValue: User): void {
    if (InfoValue && InfoValue.UserId) {
      this.service.getOneKeyNumber(InfoValue)
        .subscribe(dbData => {
          this.InfoValue = dbData;
        }, error => console.error(error), () =>  this.buildForm());
    }
  }
  // Build Form
  buildForm(): void {
    this.InfoValue.LevelUserType = this.InfoValue.LevelUser == 1 ? "Level 1" :
      (this.InfoValue.LevelUser == 2 ? "Level 2" : "Level 3");


    this.regConfig = [
      // BasemodelRequireWorkpermit //
      {
        type: "input",
        label: "UserName",
        inputType: "text",
        name: "UserName",
        disabled: true,
        value: this.InfoValue.UserName,
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
        label: "PassWord",
        inputType: "password",
        name: "PassWord",
        disabled: true,
        value: this.InfoValue.PassWord,
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
        label: "MailAddress",
        inputType: "mail",
        name: "MailAddress",
        disabled: this.denySave,
        value: this.InfoValue.MailAddress,
        validations: [
          {
            name: "maxlength",
            validator: Validators.maxLength(200),
            message: "Max length is 200"
          },
          {
            name: "required",
            validator: Validators.required,
            message: "Is required"
          },
        ]
      },
      {
        type: "input",
        label: "NameThai",
        inputType: "text",
        name: "NameThai",
        disabled: true,
        value: this.InfoValue.NameThai,
      },
      {
        type: "input",
        label: "GroupName",
        inputType: "text",
        name: "GroupName",
        disabled: true,
        value: this.InfoValue.GroupName,
      },
      {
        type: "select",
        label: "Level",
        name: "LevelUserType",
        value: this.InfoValue.LevelUserType,
        options: ["Level 1", "Level 2", "Level 3"],
        disabled: this.denySave,
        validations: [
          {
            name: "required",
            validator: Validators.required,
            message: "Is required"
          },
        ]
      }
    ];
    let ExcludeList = this.regConfig.map((item) => item.name);

    //Object.keys(this.InfoValue).forEach((item, index) => {
    //  if (!ExcludeList.find((Exitem) => Exitem !== item)) {
    //    this.regConfig.push({
    //      type: "input",
    //      label: item,
    //      inputType: "text",
    //      name: item,
    //      disabled: this.denySave,
    //      hidden: true,
    //      value: this.InfoValue[item],
    //      group: "detail",
    //    });
    //  }
    //});
  }
  // set communicate
  SetCommunicatetoParent(): void {
    if (this.isValid) {
      this.communicateService.toParent(this.InfoValue);
    }
  }
  // submit dynamic form
  submitDynamicForm(InfoValue?: User): void {
    if (InfoValue) {
      if (!this.denySave) {
        let template = InfoValue;
        // Template
        for (let key in template) {
          // console.log(key);
          this.InfoValue[key] = template[key];
        }
        // Set is valid
        this.InfoValue.LevelUser = this.InfoValue.LevelUserType == "Level 1" ? 1 :
          (this.InfoValue.LevelUserType == "Level 2" ? 2 : 3);
        this.isValid = true;
        this.SetCommunicatetoParent();
      }
    }
  }
  // event from component
  FromComponents(): void { }
}
