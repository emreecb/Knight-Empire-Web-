import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs/internal/Subscription';
import { Credentials } from 'src/app/user-admin/Services/_authService/credentials.interface';
import { UserService } from 'src/app/user-admin/Services/_authService/user.service';
import { Router, ActivatedRoute } from '@angular/router';
import { DashboardService } from 'src/app/user-admin/Services/_authService/dashboard.service';
import { ToastrService } from 'src/app/_Services/toastr.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  private subscription: Subscription;

  brandNew: boolean;
  errors: string;
  isRequesting: boolean;
  submitted  = false;
  credentials: Credentials = { email: '', password: '' };

  // tslint:disable-next-line:max-line-length
  constructor(private userService: UserService, private router: Router, private activatedRoute: ActivatedRoute, private dashService: DashboardService,
    private toastrService: ToastrService) {
  }

  ngOnInit() {

    // subscribe to router event
    this.subscription = this.activatedRoute.queryParams.subscribe(
      (param: any) => {
        this.brandNew = param['brandNew'];
        this.credentials.email = param['email'];
      });
  }


  login({ value, valid }: { value: Credentials, valid: boolean }) {
    this.submitted = true;
    this.isRequesting = true;
    this.errors = '';
    if (valid) {
      this.userService.login(value.email, value.password)
        .finally(() => this.isRequesting = false)
        .subscribe(
          result => {
            if (result) {
              this.dashService.getHomeDetails().subscribe(
                (resp: any) => {
                  this.router.navigate(['User/characterdetails']);
                }
              );
            }
          },
          error => this.errors = error);
    }
  }
}
