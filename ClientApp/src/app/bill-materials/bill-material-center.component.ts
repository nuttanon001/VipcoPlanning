import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-bill-material-center',
  styleUrls: ["../shared/styles/center.style.scss"],
  template: `<router-outlet></router-outlet>`
})
export class BillMaterialCenterComponent implements OnInit {
  constructor() { }
  ngOnInit() {}
}
