import { Component, OnInit, ViewContainerRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActualMasterService } from '../shared/actual-master.service';
import { DialogsService } from '../../dialogs/shared/dialogs.service';
import { ChartOption } from '../shared/chart-option.model';
import { ChartData, ChartData2 } from '../shared/chart-data.model';
import { ActualFab } from '../shared/actual-fab.model';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';
import { ActualDailyService } from '../shared/actual-daily.service';

@Component({
  selector: 'app-actual-report',
  templateUrl: './actual-report.component.html',
  styleUrls: ['./actual-report.component.scss']
})
export class ActualReportComponent implements OnInit {
  constructor(
    private service: ActualMasterService,
    private serviceDaily:ActualDailyService,
    private serviceDialogs: DialogsService,
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private viewContainerRef: ViewContainerRef
  ) { }

  // model
  mode: number = 1;
  chartOption: ChartOption;
  isLoading?: boolean;
  // form
  reportForm: FormGroup;
  // chart model
  // axis 1
  chartLabel: Array<string>;
  chartData: Array<ChartData2>;
  datasource: Array<ActualFab>;
  // label
  titleLabel: string = "titleLabel";
  xLabel: string = "xLabel";
  yLabel: string = "yLabel";
  yLabel2: string = "yLabel";
  // Date
  RequestDate?: Date;
  Status?: string;

  get showOption(): boolean {
    if (this.mode === 1 || this.mode === 2 || this.mode === 6) {
      return true;
    } else {
      return false;
    }
  }

  ngOnInit() {
    // Init
    this.isLoading = false;
    this.chartOption = {};
    if (!this.chartLabel) {
      this.chartLabel = new Array;
    }
    if (!this.chartData) {
      this.chartData = new Array;
    }
    if (!this.datasource) {
      this.datasource = new Array;
    }

    this.route.paramMap.subscribe((param: ParamMap) => {
      this.mode = Number(param.get("mode") || 1);
      // debug here
      // console.log(this.mode);
      this.datasource = new Array;
      this.chartLabel = new Array;
      this.chartData = new Array;
      this.onValueChanged();
    }, error => console.error(error));

    this.buildForm();
  }

  // build form
  buildForm(): void {
    this.reportForm = this.fb.group({
      PlanMasterId: [this.chartOption.PlanMasterId],
      PlanMasterName: [""],
      BomId: [this.chartOption.BomId],
      BomName: [""],
      SDate: [this.chartOption.SDate],
      EDate: [this.chartOption.EDate],
      Filter: [this.chartOption.Filter],
    });

    if (this.reportForm) {
      Object.keys(this.reportForm.controls).forEach(field => {
        const control = this.reportForm.get(field);
        control.markAsTouched({ onlySelf: true });
      });
    }

    this.reportForm.valueChanges.debounceTime(500).subscribe((data: any) => this.onValueChanged(data));
    this.onValueChanged();
  }

  // on value change
  onValueChanged(data?: any): void {
    if (!this.reportForm) { return; }

    let optionResult = this.reportForm.getRawValue() as ChartOption;
    //debug here
    //console.log(this.mode);
    //optionResult
    //console.log(JSON.stringify(optionResult));

    if (this.showOption) {
      if (optionResult.PlanMasterId) {
        this.onGetChartData();
      }
    } else {
      if (this.mode === 5) {
        if (optionResult.BomId) {
          this.onGetChartData();
        }
      } else if (optionResult.SDate && optionResult.EDate) {
        this.onGetChartData();
      }
    }
  }

  // get chart data
  onGetChartData(): void {
    if (!this.reportForm) { return; }
    if (this.isLoading) { return; }

    this.isLoading = true;
    let option: ChartOption = this.reportForm.value;
    let subString = "";

    if (this.mode === 1) {
      subString = "ChartManHour/";
    } else if (this.mode === 2) {
      subString = "ChartBomManHour/";
    } else if (!this.showOption) {
      subString = "";
    }

    if (this.mode === 1 || this.mode === 2) {
      this.service.getChartResult(option, subString)
        .subscribe(ChartResult => {
          if (ChartResult && ChartResult.ProjectName && ChartResult.ActualFabTables) {
            //debug here
            // console.log(JSON.stringify(ChartResult));
            this.RequestDate = ChartResult.ReportDate;
            this.Status = ChartResult.Status;

            this.titleLabel = ChartResult.ProjectName;
            this.xLabel = this.mode === 1 ? "Work Group" : "Bom Name";
            this.yLabel = "Manhours";
            this.yLabel2 = "Percent";
            this.chartLabel = ChartResult.Labels.slice();

            this.datasource = new Array;
            this.datasource = ChartResult.ActualFabTables.slice();

            this.chartData = new Array;
            ChartResult.ChartData2s.forEach((item, index: number) => {
              if (item) {
                let color: string = `rgba(24,15,81,1)`;
                let chartData: ChartData2 =
                {
                  type: "line",
                  fill: false,
                  yAxisID: "y-axis-2",
                  label: item.Label,
                  backgroundColor: color,
                  borderColor: color,
                  lable1: "%",
                  data: item.ChartData,
                };
                this.chartData.push(chartData);
              }
            });

            ChartResult.ChartData1s.forEach((item, index: number) => {
              if (item) {
                let color: string = index === 1 ? `rgba(4,171,247,1)` : `rgba(246,55,24,1)`;
                let chartData: ChartData2 =
                {
                  type: "bar",
                  yAxisID: "y-axis-1",
                  label: item.Label,
                  backgroundColor: color,
                  borderColor: color,
                  lable1: "Hr.",
                  data: item.ChartData,
                };
                this.chartData.push(chartData);
              }
            });
          }
          else {
            this.isLoading = false;
            this.datasource = new Array;
            this.RequestDate = undefined;
            this.Status = undefined;
            this.setChartData();
          }
        }, error => {
          this.isLoading = false;
          this.setChartData();
        }, () => this.isLoading = false);
    }
    else if (this.mode === 3) {
      // console.log(this.mode);
      this.serviceDaily.getTableActualDaily(option)
        .subscribe(result => {
          if (result.ActualFabTables) {
            this.datasource = new Array;
            this.datasource = result.ActualFabTables.slice();
          }
        }, error => {
          this.isLoading = false;
          this.setChartData();
        }, () => this.isLoading = false);
    } else if (this.mode === 4) {
      // console.log(this.mode);
      this.serviceDaily.getTableActualDaily(option, "TableActualMonthly/")
        .subscribe(result => {
          if (result.ActualFabTables) {
            this.datasource = new Array;
            this.datasource = result.ActualFabTables.slice();
          }
        }, () => {
          this.isLoading = false;
          this.setChartData();
        }, () => this.isLoading = false);
    } else if (this.mode === 5) {
      this.service.getChartResult(option, "TableBomManHour/")
        .subscribe(result => {
          if (result.ActualFabTables) {
            this.datasource = new Array;
            this.datasource = result.ActualFabTables.slice();
          }
        }, () => {
          this.isLoading = false;
          this.setChartData();
        }, () => this.isLoading = false);
    } else if (this.mode === 6) {
      this.service.getChartResult(option, "ProjectSummanyManHour/")
        .subscribe(result => {
          if (result.ActualFabTables) {
            this.RequestDate = result.ReportDate;
            this.Status = result.Status;

            this.datasource = new Array;
            this.datasource = result.ActualFabTables.slice();
          }
        }, () => {
          this.isLoading = false;
          this.setChartData();
        }, () => this.isLoading = false);
    }
  }

  // reset
  resetFilter(): void {
    this.setChartData();
    this.buildForm();
    // this.onGetChartData();
  }

  // set chart data
  setChartData(): void {
    // remove old label
    this.chartLabel = new Array;
    this.chartData = new Array;
  }

  getRandomInt(max): string {
    return Math.floor(Math.random() * Math.floor(max)).toString();
  }

  // openDialog
  openDialog(mode?: string): void {
    if (mode) {
      if (mode.indexOf("PlanMaster") !== -1) {
        this.serviceDialogs.dialogSelectPlanMaster(this.viewContainerRef)
          .subscribe(planMaster => {
            if (planMaster) {
              this.reportForm.patchValue({
                PlanMasterId: planMaster.PlanMasterId,
                PlanMasterName: planMaster.ProjectName,
              });
            }
          })
      }
      else if (mode.indexOf("Bom") !== -1) {
        this.serviceDialogs.dialogInfoBomLowLevel(this.viewContainerRef, { BillofMaterialId: -99 })
          .subscribe(resultBom => {
            if (resultBom) {
              this.reportForm.patchValue({
                BomId: resultBom.BillofMaterialId,
                BomName: resultBom.Name
              });
            }
          });
      }
    }
  }
}
