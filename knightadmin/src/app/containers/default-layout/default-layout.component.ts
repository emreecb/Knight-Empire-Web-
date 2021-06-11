import { navItems } from './_nav';
import { Component, OnInit } from '@angular/core';
import * as $ from 'jquery';
import { DashboardService } from 'src/app/_Services/_authService/dashboard.service';
import { UserService } from 'src/app/_Services/_authService/user.service';
import { GlobalService } from 'src/app/_Services/global.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './default-layout.component.html',
  styleUrls: ['./default-layout.component.scss']
})
export class DefaultLayoutComponent implements OnInit {
  navItems_ = navItems;
  constructor(readonly service: GlobalService, private dashboardService: DashboardService, private userService: UserService) {
    //this.service.logogetir();
    if (userService.isLoggedIn() === true) {
      dashboardService.getHomeDetails().subscribe((resp: any) => {
        localStorage.setItem('user', JSON.stringify(resp));
      });
    }
  }


  subNavToggle(event) {
    const elem = $(event.target).parent().find('.droppedLink');

    const elemheight = elem.find('li').css('height');
    const hcors = elem.find('li').length;
    if (parseInt(elem.css('height')) === 0) {
      elem.css('height', parseInt(elemheight) * hcors);
    } else {
      elem.css('height', 0);
    }
  }

  logout() {
    localStorage.removeItem('user');
    this.userService.logout();
  }



  ngOnInit() {

    $(document).ready(function () {

      $('#leftNavTrigger').click(function () {
        $('#leftSideMenu,#leftFixed').toggleClass('hide');
        console.log('aasddasads');
      });


      $('#rightNavTrigger').click(function () {
        $('#rightSideMenu, #rightFixed').toggleClass('hide');
      });



    });
  }
}
