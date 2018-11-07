import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UserCenterComponent } from './user-center.component';
import { UserMasterComponent } from './user-master/user-master.component';

const routes: Routes = [{
  path: "",
  component: UserCenterComponent,
  children: [
    {
      path: ":key",
      component: UserMasterComponent,
    },
    {
      path: "",
      component: UserMasterComponent,
    }
  ]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UseridRoutingModule { }
