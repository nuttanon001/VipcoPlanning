import { Component, OnInit } from '@angular/core';
import { BaseTableMk2Component } from '../../shared/base-table-mk2.component';
import { Workgroup } from '../shared/workgroup.model';
import { WorkgroupService } from '../shared/workgroup.service';
import { AuthService } from '../../core/auth/auth.service';

@Component({
  selector: 'app-workgroup-table',
  templateUrl: './workgroup-table.component.html',
  styleUrls: ['./workgroup-table.component.scss']
})
export class WorkgroupTableComponent extends BaseTableMk2Component<Workgroup, WorkgroupService>{
  constructor(service: WorkgroupService, serviceAuth: AuthService) {
    super(service, serviceAuth);
    this.columns = [
      //{ columnName: "", columnField: "select", cell: undefined },
      { columnName: "NickName", columnField: "NickName", cell: (row: Workgroup) => row.NickName },
      { columnName: "GroupCode", columnField: "GroupCode", cell: (row: Workgroup) => row.GroupCode },
      { columnName: "GroupName", columnField: "GroupName", cell: (row: Workgroup) => row.GroupName },
      { columnName: "ReferenceName", columnField: "ReferenceName", cell: (row: Workgroup) => row.ReferenceName },
      { columnName: "TypeName", columnField: "TypeName", cell: (row: Workgroup) => row.TypeName },
    ];
    this.displayedColumns = this.columns.map(x => x.columnField);
    this.displayedColumns.splice(0, 0, "select");
    this.displayedColumns.splice(0, 0, "Command");
    this.isDisabled = true;
  }
}
