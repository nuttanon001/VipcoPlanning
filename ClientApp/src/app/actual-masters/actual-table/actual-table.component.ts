import { Component, OnInit } from '@angular/core';
import { BaseTableMk2Component } from '../../shared/base-table-mk2.component';
import { ActualMaster } from '../shared/actual-master.model';
import { ActualMasterService } from '../shared/actual-master.service';
import { AuthService } from '../../core/auth/auth.service';

@Component({
  selector: 'app-actual-table',
  templateUrl: './actual-table.component.html',
  styleUrls: ['./actual-table.component.scss']
})
export class ActualTableComponent extends BaseTableMk2Component<ActualMaster, ActualMasterService>{
  constructor(service: ActualMasterService, serviceAuth: AuthService) {
    super(service, serviceAuth);
    this.columns = [
      //{ columnName: "", columnField: "select", cell: undefined },
      { columnName: "ProjectName", columnField: "ProjectName", cell: (row: ActualMaster) => row.ProjectName },
      { columnName: "ValidFrom", columnField: "ValidFrom", cell: (row: ActualMaster) => row.ValidFrom },
      { columnName: "ValidTo", columnField: "ValidTo", cell: (row: ActualMaster) => row.ValidTo },
    ];
    this.displayedColumns = this.columns.map(x => x.columnField);
    this.displayedColumns.splice(0, 0, "select");
    this.displayedColumns.splice(0, 0, "Command");
    this.isDisabled = true;
  }
}
