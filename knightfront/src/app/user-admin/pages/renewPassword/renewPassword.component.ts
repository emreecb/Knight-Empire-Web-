import { Component, OnInit } from '@angular/core';
import { Changepassword } from '../../models/Changepassword';
import { UserService } from '../../Services/_authService/user.service';
import { DashboardService } from '../../Services/_authService/dashboard.service';
import { ToastrService } from 'src/app/_Services/toastr.service';

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'app-renewPassword',
  templateUrl: './renewPassword.component.html',
  styleUrls: ['./renewPassword.component.scss']
})
export class RenewPasswordComponent implements OnInit {
  user: any;

  changepass: Changepassword = {
    userName: '',
    oldPassword: '',
    newPassword: ''
  };
  password = '';

  constructor(
    private userService: UserService,
    private dashService: DashboardService,
    private toastr: ToastrService
  ) {
    const UserDetail = JSON.parse(localStorage.getItem('user'));

    this.changepass.userName = UserDetail.identity.userName;
  }

  kaydet() {
    if (this.changepass.newPassword === this.password) {
      console.log(this.changepass);
      this.userService
        .changepassword(this.changepass)
        .subscribe((resp: any) => {
          this.toastr.Success('İşlem Başarılı');
          if (resp) {
            localStorage.removeItem('user');
            this.userService.logout();
          }
        });
    } else {
      alert('şifreleriniz uyuşmamaktadır.');
    }
  }

  ngOnInit() {
  }
}
