import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-standard-time-center',
  styleUrls: ["../shared/styles/center.style.scss"],
  template: `<router-outlet></router-outlet>`
})
export class StandardTimeCenterComponent implements OnInit {
  constructor() { }
  ngOnInit() {}
}
