import { Component, OnInit } from '@angular/core';
import { GlobalService } from 'src/app/_Services/global.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-haberdetay',
  templateUrl: './haberdetay.component.html',
  styleUrls: ['./haberdetay.component.scss']
})
export class HaberdetayComponent implements OnInit {

  private url="/Haber"
  private parametre;
  haberobj:any;

  constructor(private route: ActivatedRoute, private globalService:GlobalService
    ) {
    this.parametre = this.route.snapshot.paramMap.get('id');
    globalService.GetID(this.url,this.parametre).subscribe((resp:any)=>{
      this.haberobj=resp;
    })


  }


  ngOnInit() {
  }

}
