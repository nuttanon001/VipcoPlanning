import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ActualCenterComponent } from './actual-center.component';
import { ActualMasterComponent } from './actual-master/actual-master.component';
import { ActualChartComponent } from './actual-chart/actual-chart.component';
import { ActualReportComponent } from './actual-report/actual-report.component';

const routes: Routes = [{
  path: "",
  component: ActualCenterComponent,
  children: [
    {
      path: "chart-data",
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
