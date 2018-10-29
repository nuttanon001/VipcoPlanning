import { Component, OnInit } from '@angular/core';
import { ActualBom } from '../shared/actual-bom.model';
import { BaseTableDetailMk2Component } from '../../shared/base-table-detail-mk2.component';

@Component({
  selector: 'app-actutal-bom-table',
  templateUrl: './actutal-bom-table.component.html',
  styleUrls: ['./actutal-bom-table.component.scss']
})
export class ActutalBomTableComponent extends BaseTableDetailMk2Component<ActualBom>{

  constructor() {
    super();
    this.columns = [
      { columnName: "Group.", columnField: "GroupCode", cell: (row: ActualBom) => row.GroupCode },
      { columnName: "Code.", columnField: "BomCode", cell: (row: ActualBom) => row.BomCode },
      { columnName: "Name", columnField: "BomName", cell: (row: ActualBom) => row.BomName },
      { columnName: "Normal Time", columnField: "TotalManHour", cell: (row: ActualBom) => row.TotalManHour },
      { columnName: "Over Time", columnField: "TotalManHourOT", cell: (row: ActualBom) => row.TotalManHourOT },
      { columnName: "OT with multiply", columnField: "TotalManHourNTOT", cell: (row: ActualBom) => row.TotalManHourNTOT },
    ];
    this.displayedColumns = this.columns.map(x => x.columnField);
    this.displayedColumns.splice(0, 0, "Command");
  }
}
