import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ActualCenterComponent } from './actual-center.component';
import { ActualMasterComponent } from './actual-master/actual-master.component';
import { ActualReportComponent } from './actual-report/actual-report.component';
import { ActualDailyComponent } from './actual-daily/actual-daily.component';

const routes: Routes = [{
  path: "",
  component: ActualCenterComponent,
  children: [
    {
      path: "data-daily",
      component: ActualDailyComponent,
    },
    {
      path: "chart-data/:mode",
      component: ActualReportComponent,
    },
    {
      path: ":key",
      component: ActualMasterComponent,
    },
    {
      path: "",
      component: ActualMasterComponent,
    }
  ]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ActualMasterRoutingModule { }
