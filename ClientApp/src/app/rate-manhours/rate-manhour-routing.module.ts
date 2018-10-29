import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RateManhourCenterComponent } from './rate-manhour-center.component';
import { RateManhourMasterComponent } from './rate-manhour-master/rate-manhour-master.component';

const routes: Routes = [{
  path: "",
  component: RateManhourCenterComponent,
  children: [
    {
      path: ":key",
      component: RateManhourMasterComponent,
    },
    {
      path: "",
      component: RateManhourMasterComponent,
    }
  ]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RateManhourRoutingModule { }
