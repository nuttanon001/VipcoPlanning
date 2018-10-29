import { Component, OnInit } from '@angular/core';
import { BaseTableDetailMk2Component } from '../../shared/base-table-detail-mk2.component';
import { ActualDetail } from '../shared/actual-detail.model';

@Component({
  selector: 'app-actual-detail-table',
  templateUrl: './actual-detail-table.component.html',
  styleUrls: ['./actual-detail-table.component.scss']
})
export class ActualDetailTableComponent extends BaseTableDetailMk2Component<ActualDetail>{
  constructor() {
    super();
    this.columns = [
      { columnName: "Code.", columnField: "GroupCode", cell: (row: ActualDetail) => row.GroupCode },
      { columnName: "GroupName", columnField: "GroupName", cell: (row: ActualDetail) => row.GroupName },
      { columnName: "NickName", columnField: "NickName", cell: (row: ActualDetail) => row.NickName },
      { columnName: "Normal Time", columnField: "TotalManHour", cell: (row: ActualDetail) => row.TotalManHour },
      { columnName: "Over Time", columnField: "TotalManHourOT", cell: (row: ActualDetail) => row.TotalManHourOT },
      { columnName: "OT with multiply", columnField: "TotalManHourNTOT", cell: (row: ActualDetail) => row.TotalManHourNTOT },
      { columnName: "ActualType", columnField: "ActualTypeString", cell: (row: ActualDetail) => row.ActualTypeString },
    ];
    this.displayedColumns = this.columns.map(x => x.columnField);
    this.displayedColumns.splice(0, 0, "Command");
  }
}
