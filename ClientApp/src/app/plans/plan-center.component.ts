import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-plan-center',
  styleUrls: ["../shared/styles/center.style.scss"],
  template: `<router-outlet></router-outlet>`
})
export class PlanCenterComponent implements OnInit {
  constructor() { }
  ngOnInit() {}
}
