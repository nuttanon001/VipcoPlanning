import { Component, OnInit, ViewContainerRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActualMasterService } from '../shared/actual-master.service';
import { DialogsService } from '../../dialogs/shared/dialogs.service';
import { ChartOption } from '../shared/chart-option.model';
import { ChartData, ChartData2 } from '../shared/chart-data.model';
import { ActualFab } from '../shared/actual-fab.model';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';

@Component({
  selector: 'app-actual-report',
  templateUrl: './actual-report.component.html',
  styleUrls: ['./actual-report.component.scss']
})
export class ActualReportComponent implements OnInit {
  constructor(
    private service: ActualMasterService,
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
      this.onValueChanged();
    }, error => console.error(error));

    this.buildForm();
  }

  // build form
  buildForm(): void {
    this.reportForm = this.fb.group({
      PlanMasterId: [this.chartOption.PlanMasterId],
      PlanMasterName: ["", [ Validators.required ]],
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
    if (this.reportForm.valid) {
      // get data
      this.onGetChartData();
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
    }

    this.service.getChartResult(option, subString)
      .subscribe(ChartResult => {
        if (ChartResult && ChartResult.ProjectName && ChartResult.ActualFabTables) {
          //debug here
          // console.log(JSON.stringify(ChartResult));

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
          this.setChartData();
        }
      }, error => {
        this.isLoading = false;
        this.setChartData();
      },() => this.isLoading = false);
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
    }
  }
}
