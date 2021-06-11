import { Component, OnInit } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import * as $ from 'jquery';


@Component({
  // tslint:disable-next-line:component-selector
  selector: 'body',
  template: '<router-outlet></router-outlet>',
  //  templateUrl: './app.component.html', 
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  constructor(private router: Router) {
    console.log('Knight Empire')
   }

  ngOnInit() {
    this.router.events.subscribe((evt) => {
      if (!(evt instanceof NavigationEnd)) {
        return;
      }
      window.scrollTo(0, 0);
    });
  }
}
