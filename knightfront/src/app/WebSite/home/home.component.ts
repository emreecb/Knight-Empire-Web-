import { Component, OnInit, ViewChild } from '@angular/core';
import { UserService } from 'src/app/user-admin/Services/_authService/user.service';
import { DashboardService } from 'src/app/user-admin/Services/_authService/dashboard.service';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  userobj:any;
  goster=true;
  constructor(private user:UserService, private dash:DashboardService){
    if(user.isLoggedIn()){
      dash.getHomeDetails().subscribe((home:any)=>{
        this.goster=false;
        console.log("home",home)
        this.userobj=home;
      })
    }
  }
  ngOnInit() {


  }
}
