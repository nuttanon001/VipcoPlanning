import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
// Modules
import { CustomMaterialModule } from '../shared/customer-material.module';
import { StandardTimeRoutingModule } from './standard-time-routing.module';
// Services
import { StandardTimeService } from './shared/standard-time.service';
import { GroupStandardTimeService } from './shared/group-standard-time.service';
import { StandardTimeCommuncateService } from './shared/standard-time-communcate.service';
// Components
import { StandardTimeCenterComponent } from './standard-time-center.component';
import { StandardTimeTableComponent } from './standard-time-table/standard-time-table.component';
import { StandardTimeMasterComponent } from './standard-time-master/standard-time-master.component';
import { StandardTimeInfoComponent } from './standard-time-info/standard-time-info.component';
import { StandardTimeForWorkgroupService } from './shared/standard-time-for-workgroup.service';

@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    CustomMaterialModule,
    StandardTimeRoutingModule
  ],
  declarations: [
    StandardTimeCenterComponent,
    StandardTimeTableComponent,
    StandardTimeMasterComponent,
    StandardTimeInfoComponent
  ],
  providers: [
    StandardTimeService,
    GroupStandardTimeService,
    StandardTimeCommuncateService,
    StandardTimeForWorkgroupService
  ]
})
export class StandardTimeModule { }
