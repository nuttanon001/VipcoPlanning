import { Component, OnInit, Input } from '@angular/core';
import { ActualFab } from '../shared/actual-fab.model';
import { MyColumn } from '../../shared/my-colmun.model';
import { SelectItem } from 'primeng/primeng';

@Component({
  selector: 'app-actual-report-table',
  templateUrl: './actual-report-table.component.html',
  styleUrls: ['./actual-report-table.component.scss']
})
export class ActualReportTableComponent implements OnInit {
  constructor() { }
  // Parameter
  @Input() datasource: Array<any>;
  @Input() modeColumn: number = 1;
  @Input() typeTable: number = 1;
  @Input() scrollHeight: string = "400px";
  columns: Array<MyColumn>;
  columnUppers: Array<MyColumn>;
  columnFooter: Array<MyColumn>;
  options: Array<SelectItem>;
  // OnInit
  ngOnInit() {
    this.columns = new Array;
    if (this.typeTable === 1) {
      if (this.modeColumn === 1 || this.modeColumn === 2) {
        this.columns = [
          { field: 'WorkShopName', header: this.modeColumn === 1 ? 'Shop' : 'BomCode', width: 150, type: 1 },
          { field: 'WorkGroup', header: this.modeColumn === 1 ? 'Group' : 'Equipment', width: this.modeColumn === 1 ? 150 : 250, type: 1 },
          { field: 'WeightString', header: 'Weight(Ton)', width: 125, type: 1 },

          { field: 'PlanMHString', header: 'PlanMH', width: 100, type: 1 },
          { field: 'ActualMHString', header: 'ActualMH', width: 100, type: 1 },
          { field: 'DiffString', header: 'Diff', width: 100, type: 1 },
          { field: 'ProgressMH', header: '% MH', width: 100, type: 1 },

          { field: 'PlanMHOTString', header: 'PlanMHOT', width: 100, type: 2 },
          { field: 'ActualMHOTString', header: 'ActualMHOT', width: 100, type: 2 },
          { field: 'DiffOTString', header: 'DiffOT', width: 100, type: 2 },
          { field: 'ProgressOTMH', header: '% OTMH', width: 100, type: 2 },

          { field: 'PlanKg', header: 'PlanKg', width: 100, type: 3 },
          { field: 'ActualKg', header: 'ActualKg', width: 100, type: 3 },
          { field: 'PlanMT', header: 'PlanMT', width: 125, type: 3 },
          { field: 'ActualMT', header: 'ActualMT', width: 125, type: 3 },
        ];

        this.columnFooter = [
          { header: 'Total', width: this.modeColumn === 1 ? 300 : 400, colspan: 2 },
          { field: 'Weight', width: 125, type: 1 },
          { field: 'PlanMH', width: 100, type: 1 },
          { field: 'ActualMH', width: 100, type: 1 },
          { field: 'Diff', width: 100, type: 1 },
          { field: "ProgressMH", width: 100, type: 2 },

          { field: 'PlanMHOT', width: 100, type: 1 },
          { field: 'ActualMHOT', width: 100, type: 1 },
          { field: 'DiffOT', width: 100, type: 1 },
          { field: 'ProgressOTMH', width: 100, type: 2 },

          { field: 'PlanKg', width: 100, type: 2 },
          { field: 'ActualKg', width: 100, type: 2 },
          { field: 'PlanMT', width: 125, type: 2 },
          { field: 'ActualMT', width: 125, type: 2 },
        ];

        let col1 = { header: "MANHOURS(OTx1)", colspan: 0, width: 0, type: 1 };
        let col2 = { header: "MANHOURS(OTxX)", colspan: 0, width: 0, type: 2 };
        let col3 = { header: "PRODUCTIVITY(OTx1)", colspan: 0, width: 0, type: 3 };

        this.columns.forEach(item => {
          if (item.type === 1) {
            col1.colspan++;
            col1.width += item.width;
          } else if (item.type === 2) {
            col2.colspan++;
            col2.width += item.width;
          } else if (item.type === 3) {
            col3.colspan++;
            col3.width += item.width;
          }
        });

        this.columnUppers = [col1, col2, col3];
      }
      else if (this.modeColumn === 3) {
        this.columns = [
          { field: 'WorkShopName', header: 'WorkShopName', width: 100, type: 1 },
          { field: 'WorkGroup', header: 'WorkGroup', width: 350, type: 1 },
          { field: 'NormalTimeString', header: 'NT', width: 125, type: 1 },
          { field: 'OverTimeString', header: 'OTx1', width: 125, type: 1 },
          { field: 'OverTimeXString', header: 'OTxX', width: 125, type: 1 },
        ];

        let col1 = { header: "Actual Manhour Summany", colspan: 0, width: 0, type: 1 };

        this.columns.forEach(item => {
          if (item.type === 1) {
            col1.colspan++;
            col1.width += item.width;
          }
        });
        this.columnUppers = [col1];
      }
      else if (this.modeColumn === 4) {
        this.columns = [
          { field: 'JobNo', header: 'JobNumberMode4', width: 150, type: 1 },
          { field: 'WorkShopName', header: 'WorkShopName', width: 100, type: 1 },
          { field: 'WorkGroup', header: 'WorkGroup', width: 350, type: 1 },
          { field: 'NormalTimeString', header: 'NT', width: 125, type: 1 },
          { field: 'OverTimeString', header: 'OTx1', width: 125, type: 1 },
          { field: 'OverTimeXString', header: 'OTxX', width: 125, type: 1 },
        ];

        if (this.datasource) {
          if (!this.options) {
            this.options = new Array;
            this.options.push({ value: undefined, label: "Selected Job-No" });
          }

          this.datasource.map(x => x["JobNo"]).forEach(item => {
            if (this.options.map(x => x.value).indexOf(item) === -1) {
              this.options.push({
                value: item,
                label: item
              });
            }
          });
        }

        let col1 = { header: "Actual Manhour Summany", colspan: 0, width: 0, type: 1 };

        this.columns.forEach(item => {
          if (item.type === 1) {
            col1.colspan++;
            col1.width += item.width;
          }
        });
        this.columnUppers = [col1];
      }
      else if (this.modeColumn === 5) {
        this.columns = [

          { field: 'JobNo', header: 'JobNumber', width: 125, type: 1 },
          { field: 'WorkShopName', header: 'BomCode', width: 125, type: 1 },
          { field: 'WorkGroup', header: 'Equipment', width: 225, type: 1 },
          { field: 'Status', header: 'Status', width: 85, type: 1 },
          { field: 'WeightString', header: 'Weight(Ton)', width: 125, type: 1 },

          { field: 'PlanMHString', header: 'PlanMH', width: 100, type: 1 },
          { field: 'ActualMHString', header: 'ActualMH', width: 100, type: 1 },
          { field: 'DiffString', header: 'Diff', width: 100, type: 1 },
          { field: 'ProgressMH', header: '% MH', width: 100, type: 1 },

          { field: 'PlanMHOTString', header: 'PlanMHOT', width: 100, type: 2 },
          { field: 'ActualMHOTString', header: 'ActualMHOT', width: 100, type: 2 },
          { field: 'DiffOTString', header: 'DiffOT', width: 100, type: 2 },
          { field: 'ProgressOTMH', header: '% OTMH', width: 100, type: 2 },

          { field: 'PlanKg', header: 'PlanKg', width: 100, type: 3 },
          { field: 'ActualKg', header: 'ActualKg', width: 100, type: 3 },
          { field: 'PlanMT', header: 'PlanMT', width: 125, type: 3 },
          { field: 'ActualMT', header: 'ActualMT', width: 125, type: 3 },
        ];

        this.columnFooter = [
          { header: 'Total', width: 560, colspan: 4 },
          { field: 'Weight', width: 125, type: 1 },
          { field: 'PlanMH', width: 100, type: 1 },
          { field: 'ActualMH', width: 100, type: 1 },
          { field: 'Diff', width: 100, type: 1 },
          { field: "ProgressMH", width: 100, type: 2 },

          { field: 'PlanMHOT', width: 100, type: 1 },
          { field: 'ActualMHOT', width: 100, type: 1 },
          { field: 'DiffOT', width: 100, type: 1 },
          { field: 'ProgressOTMH', width: 100, type: 2 },

          { field: 'PlanKg', width: 100, type: 2 },
          { field: 'ActualKg', width: 100, type: 2 },
          { field: 'PlanMT', width: 125, type: 2 },
          { field: 'ActualMT', width: 125, type: 2 },
        ];

        let col1 = { header: "MANHOURS(OTx1)", colspan: 0, width: 0, type: 1 };
        let col2 = { header: "MANHOURS(OTxX)", colspan: 0, width: 0, type: 2 };
        let col3 = { header: "PRODUCTIVITY(OTx1)", colspan: 0, width: 0, type: 3 };

        this.columns.forEach(item => {
          if (item.type === 1) {
            col1.colspan++;
            col1.width += item.width;
          } else if (item.type === 2) {
            col2.colspan++;
            col2.width += item.width;
          } else if (item.type === 3) {
            col3.colspan++;
            col3.width += item.width;
          }
        });

        this.columnUppers = [col1, col2, col3];
      }else if (this.modeColumn === 6) {
        this.columns = [

          { field: 'JobNo', header: 'No.', width: 75, type: 1 },
          { field: 'WorkShopName', header: 'Type of Work', width: 225, type: 1 },
          { field: 'WeightString', header: 'Weight(Ton)', width: 125, type: 1 },

          { field: 'PlanMHString', header: 'PlanMH', width: 100, type: 2 },
          { field: 'ActualMHString', header: 'ActualMH', width: 100, type: 2 },
          { field: 'DiffString', header: 'Diff', width: 100, type: 2 },
          { field: 'ProgressMH', header: '% MH', width: 100, type: 2 },

          { field: 'PlanKg', header: 'PlanKg', width: 100, type: 3 },
          { field: 'ActualKg', header: 'ActualKg', width: 100, type: 3 },
          { field: 'PlanMT', header: 'PlanMT', width: 125, type: 3 },
          { field: 'ActualMT', header: 'ActualMT', width: 125, type: 3 },
        ];

        this.columnFooter = [
          { header: 'Total', width: 300, colspan: 2 },
          { field: 'Weight', width: 125, type: 1 },
          { field: 'PlanMH', width: 100, type: 1 },
          { field: 'ActualMH', width: 100, type: 1 },
          { field: 'Diff', width: 100, type: 1 },
          { field: "ProgressMH", width: 100, type: 2 },

          { field: 'PlanKg', width: 100, type: 2 },
          { field: 'ActualKg', width: 100, type: 2 },
          { field: 'PlanMT', width: 125, type: 2 },
          { field: 'ActualMT', width: 125, type: 2 },
        ];

        let col1 = { header: "", colspan: 0, width: 0, type: 1 };
        let col2 = { header: "MANHOURS", colspan: 0, width: 0, type: 2 };
        let col3 = { header: "PRODUCTIVITY", colspan: 0, width: 0, type: 3 };

        this.columns.forEach(item => {
          if (item.type === 1) {
            col1.colspan++;
            col1.width += item.width;
          } else if (item.type === 2) {
            col2.colspan++;
            col2.width += item.width;
          } else if (item.type === 3) {
            col3.colspan++;
            col3.width += item.width;
          }
        });

        this.columnUppers = [col1, col2, col3];
      }
    }
    else if (this.typeTable === 2) {
      this.columns = [
        { field: 'Daily', header: 'Date', width: 110, type: 1 },
        { field: 'JobNo', header: 'Job', width: 90, type: 1 },
        { field: 'GroupCode', header: 'GroupCode', width: 90, type: 1 },
        { field: 'GroupName', header: 'WorkGroup', width: 250, type: 1 },
        { field: 'TotalManHour', header: 'NT', width: 100, type: 1 },
        { field: 'TotalManHourOT', header: 'OT', width: 100, type: 1 },
        { field: 'TotalManHourNTOT', header: 'OTx', width: 100, type: 1 },
      ];
    }
  }

  getSum(key: string): number {
    if (this.datasource && key) {
      let sum = this.datasource.map(x => x[key]).reduce((pValue, cValue) => pValue + cValue, 0);
      return sum;
    }
    return 0;
  }

  getPercent(key: string): string {
    if (this.datasource && key) {
      if (key.indexOf("ProgressMH") !== -1) {
        let plans = this.datasource.map(x => x["PlanMH"]).reduce((a, b) => a + b, 0);
        let actuals = this.datasource.map(x => x["ActualMH"]).reduce((a, b) => a + b, 0);

        return ((actuals / plans)*100).toFixed(1).toString() + "%";

      } else if (key.indexOf("ProgressOTMH") !== -1) {
        let plansOt = this.datasource.map(x => x["PlanMHOT"]).reduce((a, b) => a + b, 0);
        let actualsOt = this.datasource.map(x => x["ActualMHOT"]).reduce((a, b) => a + b, 0);
        return ((actualsOt / plansOt)*100).toFixed(1).toString() + "%";

      } else if (key.indexOf("PlanKg") !== -1) {
        let plans = this.datasource.map(x => x["PlanMH"]).reduce((a, b) => a + b, 0);
        let weight = this.datasource.map(x => x["Weight"]).reduce((a, b) => a + b, 0);
        return ((weight * 1000) / plans).toFixed(1).toString() + "Kg/MH";

      } else if (key.indexOf("ActualKg") !== -1) {
        let actuals = this.datasource.map(x => x["ActualMH"]).reduce((a, b) => a + b, 0);
        let weight = this.datasource.map(x => x["Weight"]).reduce((a, b) => a + b, 0);
        return (actuals && weight ? ((weight * 1000) / actuals).toFixed(1).toString() : "0") + "Kg/MH";

      } else if (key.indexOf("PlanMT") !== -1) {
        let plans = this.datasource.map(x => x["PlanMH"]).reduce((a, b) => a + b, 0);
        let weight = this.datasource.map(x => x["Weight"]).reduce((a, b) => a + b, 0);
        return (plans / weight).toFixed(1).toString() + "MH/MT";

      } else if (key.indexOf("ActualMT") !== -1) {
        let actuals = this.datasource.map(x => x["ActualMH"]).reduce((a, b) => a + b, 0);
        let weight = this.datasource.map(x => x["Weight"]).reduce((a, b) => a + b, 0);
        return (actuals && weight ? (actuals / weight).toFixed(1).toString() : "0") + "MH/MT";
      }
    }
    return "-";
  }
}
