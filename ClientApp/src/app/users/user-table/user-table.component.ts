import { Component, OnInit } from '@angular/core';
import { BaseTableMk2Component } from '../../shared/base-table-mk2.component';
import { User } from '../shared/user.model';
import { UseridService } from '../shared/userid.service';
import { AuthService } from '../../core/auth/auth.service';

@Component({
  selector: 'app-user-table',
  templateUrl: './user-table.component.html',
  styleUrls: ['./user-table.component.scss']
})
export class UserTableComponent extends BaseTableMk2Component<User, UseridService>{

  constructor(service: UseridService, serviceAuth: AuthService) {

    super(service, serviceAuth);
    this.columns = [
      { columnName: "EmpCode.", columnField: "EmpCode", cell: (row: User) => row.EmpCode },
      { columnName: "UserName.", columnField: "UserName", cell: (row: User) => row.UserName },
      { columnName: "Name.", columnField: "NameThai", cell: (row: User) => row.NameThai },
      { columnName: "GroupCode", columnField: "GroupCode", cell: (row: User) => row.GroupCode },
      { columnName: "Group", columnField: "GroupName", cell: (row: User) => row.GroupName },
      { columnName: "LevelPlanning", columnField: "LevelPlanning", cell: (row: User) => row.LevelPlanning },
    ];
    this.displayedColumns = this.columns.map(x => x.columnField);
    this.displayedColumns.splice(0, 0, "select");
    this.displayedColumns.splice(0, 0, "Command");

    this.isDisabled = true;
  }
}
