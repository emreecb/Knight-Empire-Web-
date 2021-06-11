import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/_Services/_authService/user.service';
import { Router } from '@angular/router';
import { ToastrService } from 'src/app/_Services/toastr.service';
import { UserRegistration } from 'src/app/_Services/_authService/user.registration.interface';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  errors: string;
  isRequesting: boolean;
  submitted = false;

  constructor(private userService: UserService, private router: Router, private toastrService: ToastrService) { }


  passcontrol: string;

  registerUser({ value, valid }: { value: UserRegistration, valid: boolean }) {
    this.submitted = true;
    this.isRequesting = true;
    this.errors = '';
    value.rolesId = '2';
    if (this.passcontrol === value.password) {
      if (valid) {
        this.userService.register(value.email, value.password, value.rolesId)
          .finally(() => this.isRequesting = false)
          .subscribe(
            result => {
              if (result) {
                this.router.navigate(['/login'], { queryParams: { brandNew: true, email: value.email } });
              }
            },
            errors => this.errors = errors);
      }
    } else {
      this.isRequesting = false;
      this.toastrService.hata();
    }
  }
  ngOnInit() {
  }
}
