import { Component, OnInit } from '@angular/core';
import { BaseTableDetailMk2Component } from '../../shared/base-table-detail-mk2.component';
import { PlanShipment } from '../shared/plan-shipment.model';
import * as moment from "moment";

@Component({
  selector: 'app-plan-shipment-table',
  templateUrl: './plan-shipment-table.component.html',
  styleUrls: ['./plan-shipment-table.component.scss']
})
export class PlanShipmentTableComponent extends BaseTableDetailMk2Component<PlanShipment>{

  constructor() {
    super();
    this.columns = [
      // { columnName: "No", columnField: "SequenceNo", cell: (row: PlanShipment) => row.SequenceNo },
      { columnName: "Date", columnField: "DateShipment", cell: (row: PlanShipment) => moment(row.DateShipment).format("DD-MM-YYYY")  },
    ];
    this.displayedColumns = this.columns.map(x => x.columnField);
    this.displayedColumns.splice(0, 0, "Command");
  }
}
