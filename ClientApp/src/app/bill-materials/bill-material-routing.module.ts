import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BillMaterialCenterComponent } from './bill-material-center.component';
import { BillMaterialMasterComponent } from './bill-material-master/bill-material-master.component';

const routes: Routes = [{
  path: "",
  component: BillMaterialCenterComponent,
  children: [
    {
      path: ":key",
      component: BillMaterialMasterComponent,
    },
    {
      path: "",
      component: BillMaterialMasterComponent,
    }
  ]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BillMaterialRoutingModule { }
