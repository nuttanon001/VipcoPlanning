import { Component,OnInit } from "@angular/core";
// Model
import { User } from "../../users/shared/user.model";
// Service
import { UserService } from "../../users/shared/user.service";
// moment
import * as moment from "moment";

@Component({
  selector: "app-home",
  templateUrl: "./home.component.html",
  providers: [UserService]
})
export class HomeComponent implements OnInit {
  constructor(
    private service:UserService
  ) {
    moment.locale('th-TH');
  }
  /**
   * Parameter
   */
  //firstDay: any;
  //lastDay: any;
  //week: number;
  /**
   * On angular core Init
   */
  ngOnInit(): void {
    //this.week = moment(new Date).week();
    //this.firstDay = moment(moment().startOf("W").day(0).week(this.week)).format("DD-MM-YYYY");
    //this.lastDay = moment(moment().startOf("W").day(6).week(this.week)).format("DD-MM-YYYY");
  }

  onOpenNewLink(): void {
    let link: string = "files/maintenance_doc.pdf";
    if (link) {
      window.open(link, "_blank");
    }
  }
}
