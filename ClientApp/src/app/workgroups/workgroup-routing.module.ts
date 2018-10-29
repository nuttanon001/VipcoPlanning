import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { WorkgroupCenterComponent } from './workgroup-center.component';
import { WorkgroupMasterComponent } from './workgroup-master/workgroup-master.component';

const routes: Routes = [{
  path: "",
  component: WorkgroupCenterComponent,
  children: [
    {
      path: ":key",
      component: WorkgroupMasterComponent,
    },
    {
      path: "",
      component: WorkgroupMasterComponent,
    }
  ]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class WorkgroupRoutingModule { }
