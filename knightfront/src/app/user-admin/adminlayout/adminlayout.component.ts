import { Router } from '@angular/router';
import { DashboardService } from './../Services/_authService/dashboard.service';
import { UserService } from 'src/app/user-admin/Services/_authService/user.service';
import { Component, OnInit } from '@angular/core';
import { GlobalService } from 'src/app/_Services/global.service';
@Component({
  selector: 'app-adminlayout',
  templateUrl: './adminlayout.component.html',
  styleUrls: ['./adminlayout.component.scss']
})
export class AdminlayoutComponent implements OnInit {

  UserDetails: any;
  private url2="/Money"
  private url="/CharacterMove"
  private urllevel="/CharacterLevel"
  character:any;
  nation:any;
  money:any;
  manaoran:any;
  obje:any;
  constructor(private userService:UserService, private dashboardService:DashboardService, private router:Router,public globalService:GlobalService) {
    if (userService.isLoggedIn()) {
      this.dashboardService.getHomeDetails()
        .subscribe((resp: any) => {
          this. UserDetails=resp;
          globalService.GetID(this.urllevel,resp.characterLevel).subscribe((response:any)=>{
            globalService.funcmana(resp.mana,resp.experience,resp.characterLevel,response.experience)
          })
          if(this.UserDetails.nation){
            this.nation="Human"
          }
          else{
            this.nation="Karus"
          }
          globalService.GetID(this.url2,resp.id).subscribe((response:any)=>{
            this.money=response;
          })
        })
    }
    else {
      this.router.navigate(['/girisyap']);
    }
  }

  logout(){
    this.userService.logout();
  }

  ngOnInit() {}
}
