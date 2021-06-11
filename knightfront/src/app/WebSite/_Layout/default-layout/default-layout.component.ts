import { Router } from "@angular/router";
import { DashboardService } from "./../../../user-admin/Services/_authService/dashboard.service";
import { Component, OnInit } from "@angular/core";
import { UserService } from "src/app/user-admin/Services/_authService/user.service";

@Component({
  selector: "app-dashboard",
  templateUrl: "./default-layout.component.html",
  styleUrls: ["./default-layout.component.scss"]
})
export class DefaultLayoutComponent implements OnInit {

  constructor(
    readonly userService: UserService,
    private router: Router,
    readonly dashboardService: DashboardService
  ) {
    if (userService.isLoggedIn) {
     // this.router.navigate(["User/characterdetails"]);
    }
  }

  ngOnInit() {}
}
