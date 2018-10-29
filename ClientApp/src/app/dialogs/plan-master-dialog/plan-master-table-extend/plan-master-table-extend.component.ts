import { Component, OnInit } from '@angular/core';
import { PlanTableComponent } from '../../../plans/plan-table/plan-table.component';
import { PlanService } from '../../../plans/shared/plan.service';
import { AuthService } from '../../../core/auth/auth.service';

@Component({
  selector: 'app-plan-master-table-extend',
  templateUrl: '../../../plans/plan-table/plan-table.component.html',
  styleUrls: ['./plan-master-table-extend.component.scss']
})
export class PlanMasterTableExtendComponent extends PlanTableComponent {

  constructor(
    service: PlanService,
    serviceAuth: AuthService,
  ) {
    super(service, serviceAuth);
    this.isDialog = true;
  }
}
