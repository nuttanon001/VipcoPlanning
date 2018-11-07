// Angular Core
import { Component, OnInit, ViewContainerRef } from '@angular/core';
import { Validators } from '@angular/forms';
// Components
import { BaseInfoMk2Component } from '../../shared/base-info-mk2-component';
// Models
import { ActualBom } from '../shared/actual-bom.model';
import { ActualMaster } from '../shared/actual-master.model';
import { ActualDetail } from '../shared/actual-detail.model';
import { PlanMaster } from '../../plans/shared/plan-master.model';
import { PlanStatus } from '../../plans/shared/plan-status.enum';
// Services
import { ShareService } from '../../shared/share.service';
import { AuthService } from '../../core/auth/auth.service';
import { ActualBomService } from '../shared/actual-bom.service';
import { DialogsService } from '../../dialogs/shared/dialogs.service';
import { ActualMasterService } from '../shared/actual-master.service';
import { ActualDetailService } from '../shared/actual-detail.service';
import { WorkgroupManhourService } from '../shared/workgroup-manhour.service';
import { ActualMasterCommunicateService } from '../shared/actual-master-communicate.service';

@Component({
  selector: 'app-actual-info',
  templateUrl: './actual-info.component.html',
  styleUrls: ['./actual-info.component.scss'],
  providers: [ShareService]
})
export class ActualInfoComponent extends BaseInfoMk2Component<ActualMaster, ActualMasterService, ActualMasterCommunicateService> {
  constructor(
    service: ActualMasterService,
    serviceCom: ActualMasterCommunicateService,
    private serviceTotalManHour: WorkgroupManhourService,
    private serviceDetail: ActualDetailService,
    private serviceBom: ActualBomService,
    private serviceShared: ShareService,
    private serviceDialogs: DialogsService,
    private serviceAuth: AuthService,
    private viewContainer: ViewContainerRef,
  ) { super(service, serviceCom); }
  // Parameter
  isLoad: boolean = false;

  // Methods
  onGetDataByKey(InfoValue: ActualMaster): void {
    if (InfoValue && InfoValue.ActualMasterId) {
      this.service.getOneKeyNumber(InfoValue)
        .subscribe(dbData => {
          this.InfoValue = dbData;
          this.isValid = true;

          if (this.InfoValue.ActualMasterId) {
            this.InfoValue.ActualDetails = new Array;
            this.serviceDetail.getByMasterId(this.InfoValue.ActualMasterId)
              .subscribe(data => {
                // this.InfoValue.ActualDetails = data.slice();
                // $id
                if (data) {
                  data.forEach(item => {
                    let temp: ActualDetail = {
                      ActualDetailId:0
                    };

                    for (let key in item) {
                      if (key.indexOf("$id") === -1) {
                        temp[key] = item[key];
                      } 
                    }

                    this.InfoValue.ActualDetails.push(temp);
                  });
                  this.InfoValue.ActualDetails = this.InfoValue.ActualDetails.slice();
                }
              });

            this.InfoValue.ActualBoms = new Array;
            this.serviceBom.getByMasterId(this.InfoValue.ActualMasterId)
              .subscribe(data => {
                if (data) {
                  data.forEach(item => {
                    let temp: ActualBom = {
                      ActualBomId: 0
                    };

                    for (let key in item) {
                      // console.log(key);
                      if (key.indexOf("$id") === -1) {
                        temp[key] = item[key];
                      } 
                    }

                    this.InfoValue.ActualBoms.push(temp);
                  });
                  this.InfoValue.ActualBoms = this.InfoValue.ActualBoms.slice();
                }
              });
          }
        }, error => console.error(error), () => this.buildForm());
    } else {
      this.InfoValue = {
        ActualMasterId: 0,
        ActualStatus: PlanStatus.InProcess,
        ActualDetails: new Array,
        ActualBoms: new Array,
      };
      this.buildForm();
    }
  }

  // Build Form
  buildForm(): void {
    this.regConfig = [
      // BasemodelRequireWorkpermit //
      {
        type: "inputclick",
        label: "ProjectName",
        inputType: "text",
        name: "ProjectName",
        disabled: this.denySave,
        value: this.InfoValue.ProjectName,
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
        label: "OverTimemultiply",
        inputType: "number",
        name: "OverTimemultiply",
        disabled: this.denySave,
        value: this.InfoValue.OverTimemultiply,
        validations: [
          {
            name: "required",
            validator: Validators.required,
            message: "Is required"
          },
          {
            name: "min",
            validator: Validators.min(1),
            message: "Minimum is 1"
          },
          {
            name: "max",
            validator: Validators.max(2),
            message: "Maximum is 2"
          },
        ]
      },
      //{
      //  type: "date",
      //  label: "ValidFrom",
      //  name: "ValidFrom",
      //  disabled: this.denySave,
      //  value: this.InfoValue.ValidFrom,
      //  validations: [
      //    {
      //      name: "required",
      //      validator: Validators.required,
      //      message: "Is required"
      //    },
      //  ]
      //},
      //{
      //  type: "date",
      //  label: "ValidTo",
      //  name: "ValidTo",
      //  disabled: this.denySave,
      //  value: this.InfoValue.ValidTo,
      //},
    ];
    // let ExcludeList = this.regConfig.map((item) => item.name);
  }

  // set communicate
  SetCommunicatetoParent(): void {
    if (this.isValid && this.InfoValue.ActualDetails) {
      if (this.InfoValue.ActualDetails.length > 0) {
        // debug here
        console.log("communicateService");
        this.communicateService.toParent(this.InfoValue);
      }
    }
  }

  // submit dynamic form
  submitDynamicForm(InfoValue?: ActualMaster): void {
    if (InfoValue) {
      if (!this.denySave) {
        let template = InfoValue;
        // Template
        for (let key in template) {
          // console.log(key);
          this.InfoValue[key] = template[key];
        }
        this.isValid = true;
        //debug here
        // console.log(JSON.stringify(InfoValue));
        this.SetCommunicatetoParent();
      }
    }
  }

  // event from component
  FromComponents(): void {
    this.subscription2 = this.serviceShared.ToParent$.subscribe(data => {
      if (data.name.indexOf("ProjectName") !== -1) {
        this.serviceDialogs.dialogSelectPlanMaster(this.viewContainer)
          .subscribe((planMaster: PlanMaster) => {
            this.serviceShared.toChild(
              {
                name: data.name,
                value: planMaster.ProjectName
              });

            this.InfoValue.ProjectCodeMasterId = planMaster.ProjectCodeMasterId;
            this.InfoValue.PlanMasterId = planMaster.PlanMasterId;
          });
      }
    });
  }

  // ActualDetail
  OnActualDetail(Item: { data?: ActualDetail, option: number }): void {
    if (this.denySave) {
      return;
    }

    if (this.InfoValue.PlanMasterId) {
      if (Item.option === 1 && !Item.data) {
        this.isLoad = true;
        this.serviceTotalManHour.getWorkGroupTotalManHour(this.InfoValue.PlanMasterId)
          .subscribe((data: Array<ActualDetail>) => {
            if (data) {
              data.forEach(item => {
                if (!this.InfoValue.ActualDetails.find(detail => detail.GroupCode === item.GroupCode))
                {
                  let template: ActualDetail = {
                    ActualDetailId: 0,
                    ActualMasterId: this.InfoValue.ActualMasterId
                  };
                  for (let key in item) {
                    template[key] = item[key];
                  }
                  this.InfoValue.ActualDetails.push(template);
                }
                else
                {
                  const actualDetails = this.InfoValue.ActualDetails.filter(value => value.GroupCode === item.GroupCode);
                  if (actualDetails[0])
                  {
                    actualDetails[0].TotalManHour = item.TotalManHour;
                    actualDetails[0].TotalManHourNTOT = item.TotalManHourNTOT;
                    actualDetails[0].TotalManHourOT = item.TotalManHourOT;
                    actualDetails[0].GroupName = item.GroupName;
                    actualDetails[0].WorkShop = item.WorkShop;
                    actualDetails[0].NickName = item.NickName;
                    actualDetails[0].ActualType = item.ActualType;
                    actualDetails[0].ActualDetailType = item.ActualDetailType;
                    actualDetails[0].ActualTypeString = item.ActualTypeString;
                  }
                }
              });
              // ActualDetails
              this.InfoValue.ActualDetails = this.InfoValue.ActualDetails.slice();
              this.SetCommunicatetoParent();
            }
          }, () => { }, () => this.isLoad = false);
      }
    }
    else {
      this.serviceDialogs.error("Warning Message","Select planning project first.",this.viewContainer).subscribe();
    }
  }

  // ActualBom
  OnActualBom(Item: { data?: ActualBom, option: number }): void {
    if (this.denySave) {
      return;
    }

    if (this.InfoValue.PlanMasterId) {
      if (Item.option === 1 && !Item.data) {
        this.isLoad = true;
        this.serviceTotalManHour.getBomTotalManHour(this.InfoValue.PlanMasterId)
          .subscribe((data: Array<ActualBom>) => {
            if (data) {
              data.forEach(item => {
                if (!this.InfoValue.ActualBoms.find(detail => detail.BomCode === item.BomCode)) {
                  let template: ActualBom = {
                    ActualBomId: 0,
                    ActualMasterId: this.InfoValue.ActualMasterId
                  };
                  for (let key in item) {
                    template[key] = item[key];
                  }
                  this.InfoValue.ActualBoms.push(template);
                }
                else {
                  const actualBoms = this.InfoValue.ActualBoms.filter(value => value.BomCode === item.BomCode);
                  if (actualBoms[0]) {
                    actualBoms[0].TotalManHour = item.TotalManHour;
                    actualBoms[0].TotalManHourNTOT = item.TotalManHourNTOT;
                    actualBoms[0].TotalManHourOT = item.TotalManHourOT;
                    actualBoms[0].GroupCode = item.GroupCode;
                    actualBoms[0].BomCode = item.BomCode;
                    actualBoms[0].BomName = item.BomName;
                    actualBoms[0].ActualType = item.ActualType;
                    actualBoms[0].ActualDetailType = item.ActualDetailType;
                  }
                }
              });
              // ActualDetails
              this.InfoValue.ActualBoms = this.InfoValue.ActualBoms.slice();
              this.SetCommunicatetoParent();
            }
          }, () => { }, () => this.isLoad = false);
      }
    }
    else {
      this.serviceDialogs.error("Warning Message", "Select planning project first.", this.viewContainer).subscribe();
    }
  }
}
