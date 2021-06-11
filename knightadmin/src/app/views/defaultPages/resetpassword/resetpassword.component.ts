import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/_Services/_authService/user.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-resetpassword',
  templateUrl: './resetpassword.component.html',
  styleUrls: ['./resetpassword.component.scss']
})
export class ResetpasswordComponent implements OnInit {

  parametre: any;
  params: string;

  resetobje: any = {
    email: '',
    password: '',
    token: ''
  };
  password: string;


  constructor(
    private userService: UserService,
    private route: ActivatedRoute,
    private router: Router
  ) {

    this.parametre = this.route.snapshot.queryParams;
    this.resetobje.email = this.parametre.userId;
    this.resetobje.token = this.parametre.token.replace(/ /g, '+');
  }

  sifirla() {
    if (this.resetobje.password === this.password) {
      this.userService
        .resetpass(this.resetobje)
        .subscribe((resp: any) => {
          console.log('respreser', resp);
          if (resp) {
            this.router.navigate(['/login']);
          }
        },
          error => {
            alert('Hata oluştu');
          });
    } else {
      alert('şifreler uyuşmamaktadır');
    }
  }

  ngOnInit() {
  }

}
