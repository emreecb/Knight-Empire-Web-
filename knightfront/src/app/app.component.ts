import { Component, OnInit } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
import { DashboardService } from './user-admin/Services/_authService/dashboard.service';
import { UserService } from './user-admin/Services/_authService/user.service';

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'body',
  template: '<router-outlet></router-outlet>',
})
export class AppComponent implements OnInit {
  title = 'digi[SOFT] webMaster';

  constructor(
    private router: Router,
    private dashService: DashboardService,
    private userService: UserService,
  ) {
    if (userService.isLoggedIn() === true) {
      dashService.getHomeDetails().subscribe((resp: any) => {
        localStorage.setItem('user', JSON.stringify(resp));
      });
    }
  }


  ngOnInit() {
    this.router.events.subscribe(evt => {
      if (!(evt instanceof NavigationEnd)) {
        return;
      }
      window.scrollTo(0, 0);
    });
  }
}
