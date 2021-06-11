import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { Credentials } from '../../../_Services/_authService/credentials.interface';
import { UserService } from '../../../_Services/_authService/user.service';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from '../../../_Services/toastr.service';
import { DashboardService } from '../../../_Services/_authService/dashboard.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: 'login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  private subscription: Subscription;

  brandNew: boolean;
  errors: string;
  isRequesting: boolean;
  submitted = false;
  credentials: Credentials = { email: '', password: '' };

  constructor(private userService: UserService, private router: Router, private activatedRoute: ActivatedRoute, private dashService: DashboardService,
  private toastrService: ToastrService) {
    console.log('login', userService.isLoggedIn());

    if (userService.isLoggedIn()) {

      this.router.navigate(['/dashboard']);
    }
   }

    ngOnInit() {

    // subscribe to router event
    this.subscription = this.activatedRoute.queryParams.subscribe(
      (param: any) => {
         this.brandNew = param['brandNew'];
         this.credentials.email = param['email'];
      });
  }

  /* ngOnDestroy() {
    // prevent memory leak by unsubscribing
    this.subscription.unsubscribe();
  }*/

  login({ value, valid }: { value: Credentials, valid: boolean }) {
    console.log('login');
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
                this.router.navigate(['/dashboard'])
               /* if (resp.identity.rolesId === '2') {
                  console.log('if');
                  this.router.navigate(['/dashboard']);

                } else {
                  this.userService.logout();
                  this.toastrService.Warning();
                }*/
              }
            );
          }
        },
        error => this.errors = error);
    }
  }
}
