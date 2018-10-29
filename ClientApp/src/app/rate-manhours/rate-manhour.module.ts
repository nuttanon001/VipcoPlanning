import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
// Modules
import { CustomMaterialModule } from '../shared/customer-material.module';
// Component
import { RateManhourRoutingModule } from './rate-manhour-routing.module';
import { RateManhourService } from './shared/rate-manhour.service';
import { RateManhourCommuncateService } from './shared/rate-manhour-communcate.service';
import { RateManhourCenterComponent } from './rate-manhour-center.component';
import { RateManhourTableComponent } from './rate-manhour-table/rate-manhour-table.component';
import { RateManhourMasterComponent } from './rate-manhour-master/rate-manhour-master.component';
import { RateManhourInfoComponent } from './rate-manhour-info/rate-manhour-info.component';

@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    CustomMaterialModule,
    RateManhourRoutingModule
  ],
  declarations: [
    RateManhourCenterComponent,
    RateManhourTableComponent,
    RateManhourMasterComponent,
    RateManhourInfoComponent
  ],
  providers: [
    RateManhourService,
    RateManhourCommuncateService
  ]
})
export class RateManhourModule { }
