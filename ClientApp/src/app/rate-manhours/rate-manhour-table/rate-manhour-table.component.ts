import { Component, OnInit } from '@angular/core';
import { BaseTableComponent } from '../../shared/base-table.component';
import { RateManhour } from '../shared/rate-manhour.model';
import { RateManhourService } from '../shared/rate-manhour.service';
import { AuthService } from '../../core/auth/auth.service';

@Component({
  selector: 'app-rate-manhour-table',
  templateUrl: './rate-manhour-table.component.html',
  styleUrls: ['./rate-manhour-table.component.scss']
})
export class RateManhourTableComponent extends BaseTableComponent<RateManhour,RateManhourService> {

  constructor(
    service: RateManhourService,
    serviceAuth: AuthService,
  ) {
    super(service, serviceAuth);
    this.displayedColumns = ["select", "ForWorkGroupString", "RateBathPerManHour", "Description"];
  }
}
