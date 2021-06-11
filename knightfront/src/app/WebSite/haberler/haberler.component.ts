import { Component, OnInit } from '@angular/core';
import { GlobalService } from 'src/app/_Services/global.service';

@Component({
  selector: 'app-haberler',
  templateUrl: './haberler.component.html',
  styleUrls: ['./haberler.component.scss']
})
export class HaberlerComponent implements OnInit {

  private url="/Haber"

  haberlist:any[]=[];
  constructor(private globalService:GlobalService) {
    globalService.Get(this.url).subscribe((resp:any)=>{
      this.haberlist=resp;
    })
   }

  ngOnInit() {
  }

}
