import { Component, OnInit } from '@angular/core';
import { BaseTableComponent } from '../../shared/base-table.component';
import { PlanMaster } from '../shared/plan-master.model';
import { PlanService } from '../shared/plan.service';
import { AuthService } from '../../core/auth/auth.service';

@Component({
  selector: 'app-plan-table',
  templateUrl: './plan-table.component.html',
  styleUrls: ['./plan-table.component.scss']
})
export class PlanTableComponent extends BaseTableComponent<PlanMaster,PlanService> {
  constructor(
    service: PlanService,
    serviceAuth:AuthService,
  ) {
    super(service, serviceAuth);
    this.displayedColumns = ["select","ProjectName" , "Revised", "DeliveryDate", "ManagementByString"];
  }
}
