import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/user-admin/Services/_authService/user.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-confirm',
  templateUrl: './confirm.component.html',
  styleUrls: ['./confirm.component.scss']
})
export class ConfirmComponent implements OnInit {
  private parametre;
  confirmed = false;

  constructor(
    private servis: UserService,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.parametre = this.route.snapshot.queryParams;
    const userId = this.parametre.userId.replace(/ /g, '+');
    const code = this.parametre.code.replace(/ /g, '%2B').replace(/=/g, '%3D');

    this.kontrol(userId, code);
  }

  kontrol(val1, val2) {
    const url =
      'http://localhost:54000/api/accounts?userId=' +
      val1 +
      '&' +
      'code=' +
      val2;

    this.servis.confirm(url).subscribe(
      (resp: any) => {
        console.log('deneme');
        if (resp) {
          this.confirmed = true;
          this.nav();
        }
      },
      error => {
        alert('hatalı link');
        this.nav();
      }
    );
  }

  nav() {
    setTimeout(() => {
      this.router.navigate(['/adminpanel']);
    }, 5000);
  }

  ngOnInit() {}
}
