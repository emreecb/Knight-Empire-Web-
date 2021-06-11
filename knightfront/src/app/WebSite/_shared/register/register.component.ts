import { Component, OnInit } from '@angular/core';
import { UserRegistration } from 'src/app/user-admin/Services/_authService/user.registration.interface';
import { UserService } from 'src/app/user-admin/Services/_authService/user.service';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'src/app/_Services/toastr.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  errors: string;
  isRequesting: boolean;
  submitted = false;
  param:any;

  constructor(private userService: UserService, private router: Router, private toastrService: ToastrService,private root: ActivatedRoute) {
    this.root.params.subscribe((respx: any) => {
      this.param = this.root.snapshot.paramMap.get("id");
      if(this.param ==1 || this.param==2 ){
        
      }
      else{
        if(userService.isLoggedIn)
        router.navigate(['/adminpanel'])
        else
        this.router.navigate([''])
      }
      this.ngOnInit();
    });
   }


  passcontrol: string;

  registerUser({ value, valid }: { value: UserRegistration, valid: boolean }) {
    this.submitted = true;
    this.isRequesting = true;
    this.errors = '';
    if(this.param==1){
      value.nation=true
    }
    else{
      value.nation=false;
    }
    console.log('passcontrol', this.passcontrol);
    console.log('pass', value.password);
    if (this.passcontrol === value.password) {
      console.log('if');
      if (valid) {
        console.log(value);
        this.userService.register(value)
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
      console.log('else');
      this.isRequesting = false;
      this.toastrService.hata('HATA GİRİŞ YSAhksdfjhksdfjhksdfjkh');
    }
  }

  ngOnInit() {
  }

}
