import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
// Modules
import { UseridRoutingModule } from './userid-routing.module';
// Services
import { SharedModule } from '../shared/shared.module';
import { UseridService } from './shared/userid.service';
import { CustomMaterialModule } from '../shared/customer-material.module';
import { UseridCommunicateService } from './shared/userid-communicate.service';
// Components
import { UserCenterComponent } from './user-center.component';
import { UserInfoComponent } from './user-info/user-info.component';
import { UserTableComponent } from './user-table/user-table.component';
import { UserMasterComponent } from './user-master/user-master.component';

@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    UseridRoutingModule,
    CustomMaterialModule,
    SharedModule
  ],
  declarations: [
    UserCenterComponent,
    UserTableComponent,
    UserMasterComponent,
    UserInfoComponent
  ],
  providers: [
    UseridService,
    UseridCommunicateService
  ]
})
export class UseridModule { }
