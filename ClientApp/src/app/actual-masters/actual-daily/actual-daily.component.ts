
import { Component, OnInit, ViewContainerRef } from '@angular/core';
// Models
import { ChartOption } from '../shared/chart-option.model';
import { FieldConfig } from '../../shared/dynamic-form/field-config.model';
// Services
import { ActualDailyService } from '../shared/actual-daily.service';
import { DialogsService } from '../../dialogs/shared/dialogs.service';
import { WorkgroupManhourService } from '../shared/workgroup-manhour.service';
// 3rd Party
import * as moment from "moment";
import { Validators } from '@angular/forms';
import { ActualDaily } from '../shared/actual-daily.model';
import { AuthService } from '../../core/auth/auth.service';

@Component({
  selector: 'app-actual-daily',
  templateUrl: './actual-daily.component.html',
  styleUrls: ['./actual-daily.component.scss']
})
export class ActualDailyComponent implements OnInit {

  constructor(
    private service: WorkgroupManhourService,
    private serviceDaily: ActualDailyService,
    private serviceDialogs: DialogsService,
    private viewCon: ViewContainerRef,
    private serviceAuth:AuthService,
  ) {
    moment.locale("th-TH");
  }

  /*
   Parameter
   */
  regConfig: Array<FieldConfig>;
  option: ChartOption;
  infoValue: Array<ActualDaily>;
  isValid: boolean = false;
  isLoading: boolean = false;
  canSave: boolean = false;

  /*
   Method
   */

  // on ng init
  ngOnInit() {
    if (!this.option) {
      let today = moment(new Date);
      let fDate = moment(new Date).add(-7,"day").toDate();

      // console.log(fDate);

      this.option = {
        SDate: fDate,
        EDate: today.toDate()
      };
    }

    if (!this.infoValue) {
      this.infoValue = new Array;
    }

    this.buildForm();
    this.isValid = true;
  }

  // bulid-form
  buildForm(): void {
    this.regConfig = [
      // BasemodelRequireWorkpermit //
      {
        type: "date",
        label: "StartDate",
        name: "SDate",
        value: this.option.SDate,
        validations: [
          {
            name: "required",
            validator: Validators.required,
            message: "Is required"
          },
        ]
      },
      {
        type: "date",
        label: "EndDate",
        name: "EDate",
        value: this.option.EDate,
        validations: [
          {
            name: "required",
            validator: Validators.required,
            message: "Is required"
          },
        ]
      },
    ];
  }

  // submit dynamic form
  submitDynamicForm(option?: ChartOption): void {
    if (option) {
      let template = option;
      // Template
      for (let key in template) {
        // console.log(key);
        this.option[key] = template[key];
      }
      this.isValid = true;
    } else {
      this.isValid = false;
    }
  }

  // on submit
  onSubmit(): void {
    this.canSave = false;
    if (this.infoValue) {
      this.isLoading = true;
      this.serviceDaily.arrayCreateAndUpdate(this.infoValue)
        .subscribe(result => {
          if (result) {
            this.serviceDialogs.context("System message", "Save completed.", this.viewCon)
              .subscribe(result => {
                this.infoValue = new Array;
              });
          }
        },() => this.isLoading = false,() => this.isLoading = false);
    }
  }

  // ActualDetail
  OnActualDaily(): void {
    if (this.option.SDate && this.option.EDate) {
      this.isLoading = true;
      this.service.getManHourDaily(this.option)
        .subscribe((data: Array<ActualDaily>) => {
          if (data) {
            //if (!this.infoValue) {
            //  this.infoValue = new Array;
            //}
            this.infoValue = new Array;
            const UseName = this.serviceAuth.getAuth.UserName || "-";
            data.forEach(item => {
              if (!this.infoValue.find(daily => daily.GroupCode === item.GroupCode &&
                daily.Daily === item.Daily && daily.JobNo === item.JobNo)) {
                let template: ActualDaily = {
                  ActualDailyId: 0,
                };
                for (let key in item) {
                  template[key] = item[key];
                }
                template.Creator = UseName;
                this.infoValue.push(template);
              }
              else {
                const actualDalies = this.infoValue.filter(value => value.GroupCode === item.GroupCode &&
                  value.Daily === item.Daily && value.JobNo === item.JobNo);
                if (actualDalies[0]) {
                  actualDalies[0].TotalManHour = item.TotalManHour;
                  actualDalies[0].TotalManHourNTOT = item.TotalManHourNTOT;
                  actualDalies[0].TotalManHourOT = item.TotalManHourOT;
                  actualDalies[0].Modifyer = Object.assign({}, UseName);
                }
              }
            });
            // ActualDetails
            this.infoValue = this.infoValue.slice();
            if (this.infoValue) {
              this.canSave = true;
            }
          }
        }, () => { }, () => this.isLoading = false);
    }
    else {
      this.serviceDialogs.error("Warning Message", "Select planning project first.", this.viewCon).subscribe();
    }
  }
}
