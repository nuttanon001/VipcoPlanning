import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PlanCenterComponent } from './plan-center.component';
import { PlanMasterComponent } from './plan-master/plan-master.component';
import { PlanScheduleComponent } from './plan-schedule/plan-schedule.component';

const routes: Routes = [{
  path: "",
  component: PlanCenterComponent,
  children: [
    //{
    //  path: "plan-schedule",
    //  component: PlanScheduleComponent,
    //},
    {
      path: ":key",
      component: PlanMasterComponent,
    },
    {
      path: "",
      component: PlanMasterComponent,
    }
  ]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PlanRoutingModule { }
