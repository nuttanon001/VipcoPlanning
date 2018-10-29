import { Component, OnInit, Input } from '@angular/core';
import { ActualFab } from '../shared/actual-fab.model';

@Component({
  selector: 'app-actual-report-table',
  templateUrl: './actual-report-table.component.html',
  styleUrls: ['./actual-report-table.component.scss']
})
export class ActualReportTableComponent implements OnInit {
  constructor() { }
  // Parameter
  @Input() datasource: Array<ActualFab>;
  columns: Array<any>;
  columnUppers: Array<any>;
  // OnInit
  ngOnInit() {
    this.columns = new Array;
    this.columns = [
      { field: 'WorkShopName', header: 'Shop', width: 150, type: 1},
      { field: 'WorkGroup', header: 'Group', width: 150, type: 1},
      { field: 'WeightString', header: 'Weight', width: 100, type: 1},

      { field: 'PlanMHString', header: 'PlanMH', width: 80, type: 1},
      { field: 'ActualMHString', header: 'ActualMH', width: 80, type: 1},
      { field: 'DiffString', header: 'Diff', width: 80, type: 1},
      { field: 'ProgressMH', header: '% MH', width: 80, type: 1 },

      { field: 'PlanMHOTString', header: 'PlanMHOT', width: 100, type: 2 },
      { field: 'ActualMHOTString', header: 'ActualMHOT', width: 100, type: 2 },
      { field: 'DiffOTString', header: 'DiffOT', width: 100, type: 2 },
      { field: 'ProgressOTMH', header: '% OTMH', width: 100, type: 2 },

      { field: 'PlanKg', header: 'PlanKg', width: 100, type: 3 },
      { field: 'ActualKg', header: 'ActualKg', width: 100, type: 3 },
      { field: 'PlanMT', header: 'PlanMT', width: 100, type: 3 },
      { field: 'ActualMT', header: 'ActualMT', width: 100, type: 3 },
    ];

    let col1 = { header: "MANHOURS(OTx1)", colspan: 0, width: 0, type: 1};
    let col2 = { header: "MANHOURS(OTxX)", colspan: 0, width: 0, type: 2 };
    let col3 = { header: "PRODUCTIVITY(OTx1)", colspan: 0, width: 0, type: 3};

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
