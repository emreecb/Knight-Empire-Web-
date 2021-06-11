import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/user-admin/Services/_authService/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-forgotpass',
  templateUrl: './forgotpass.component.html',
  styleUrls: ['./forgotpass.component.scss']
})
export class ForgotpassComponent implements OnInit {
  forget: any = {
    email: ''
  };

  constructor(private userService: UserService, private router: Router) {}

  gonder() {
    console.log('email', this.forget);
    this.userService.forgetpass(this.forget).subscribe(
      resp => {
        console.log('resp', resp);
        if (resp) { this.router.navigate(['']); }
      },
      error => {
        alert('hatalı mail');
      }
    );
  }

  ngOnInit() {}
}
