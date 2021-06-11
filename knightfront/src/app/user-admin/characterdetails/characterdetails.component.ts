import { DashboardService } from './../Services/_authService/dashboard.service';
import { Component, OnInit, ElementRef, OnDestroy } from '@angular/core';
import { GlobalService } from 'src/app/_Services/global.service';
import { Observable, Subscription } from 'rxjs/Rx';
import { CharacterMove } from './characterMove';

@Component({
  selector: 'app-characterdetails',
  templateUrl: './characterdetails.component.html',
  styleUrls: ['./characterdetails.component.scss']
})
export class CharacterdetailsComponent implements OnInit {

  private url = "/CharacterDetails"
  private url2 = "/Money"
  private url3 = "/CharacterMove"
  private urllevel = "/CharacterLevel"
  private url4 = "/CharacterMove/sonuclandir"
  private urlFuzzy="/Fuzzy"

  character: any;
  nation: any;
  money: any;
  needexp: any = 0;
  date: Date;
  datetime: any[] = [];

  trainingshow = true;
  restshow = true;
  workshow = true;
  degisken = true;
  finishedobj: any = {
    id: 0,
    type: 0,
    day: 0,
    hours: 0,
    minutes: 0
  }
  fuzzyobj:any;

  constructor(private globalService: GlobalService, private dashboardService: DashboardService, elm: ElementRef) {
    this.futureString = elm.nativeElement.getAttribute('inputDate');
  }

  training() {
    this.moveobject.type = 2;
    this.moveobject.startTime = new Date();
    this.globalService.Update(this.url3, this.moveobject).subscribe((resp: any) => {
      location.reload();
    })
  }
  finished(type) {
    this.finishedobj.type = type
    this.finishedobj.day = this.datetime[0]
    this.finishedobj.hours = this.datetime[1]
    this.finishedobj.minutes = this.datetime[2]
    this.globalService.Update(this.url4, this.finishedobj).subscribe(resp => {
      if (resp) {
        location.reload();
      }
    })
  }

  rest() {
    this.moveobject.type = 1;
    this.moveobject.startTime = new Date;
    this.globalService.Update(this.url3, this.moveobject).subscribe((resp: any) => {
      location.reload();
    })
  }
  work() {
    this.moveobject.type = 3;
    this.moveobject.startTime = new Date;
    this.globalService.Update(this.url3, this.moveobject).subscribe((resp: any) => {
      location.reload();
    })
  }

  moveobject: CharacterMove = {
    id: 0,
    characterDetailsId: 0,
    startTime: null,
    type: 0,
    deleteStatus: false
  }


  ngOnInit() {

    this.dashboardService.getHomeDetails()
      .subscribe((resp: any) => {
        this.character = resp;
        this.moveobject.characterDetailsId = resp.id;
        this.finishedobj.id = resp.id
        this.globalService.GetID(this.urlFuzzy,resp.id).subscribe((respfuzzy:any)=>{
          this.fuzzyobj=respfuzzy;
        })
        this.globalService.GetID(this.urllevel, resp.characterLevel).subscribe((response: any) => {
          this.needexp = response.experience
        })
        this.globalService.GetID(this.url3, resp.id).subscribe((resp: CharacterMove) => {
          if (resp != null) {
            this.moveobject = resp;
            this.degisken = false;
            if (resp.type == 1) {
              this.restshow = false;
              this.workshow = false;
            }
            if (resp.type == 2) {
              this.trainingshow = false;
              this.workshow = false;
            }
            if (resp.type == 3) {
              this.trainingshow = false;
              this.restshow = false;
            }
            this.future = new Date(resp.startTime);
            this.counter = Observable.interval(1000).map((x) => {
              return Math.floor((new Date().getTime() - this.future.getTime()) / 1000);
            });
            this.subscription = this.counter.subscribe((x: any) => { this.message = this.dhms(x) });
          }
        })

        if (this.character.nation) {
          this.nation = "El Morad"
        }
        else {
          this.nation = "Karus"
        }
        this.globalService.GetID(this.url2, resp.id).subscribe((response: any) => {
          this.money = response;
        })
      })
  }




  private future: Date;
  private futureString: string;
  private counter: Observable<number>;
  private subscription: Subscription;
  private message: string;

  dhms(t) {
    var days, hours, minutes, seconds;
    days = Math.floor(t / 86400);
    t -= days * 86400;
    hours = Math.floor(t / 3600) % 24;
    t -= hours * 3600;
    minutes = Math.floor(t / 60) % 60;
    t -= minutes * 60;
    seconds = t % 60;
    this.datetime[0] = days;
    this.datetime[1] = hours;
    this.datetime[2] = minutes;
    return [
      days + 'd',
      hours + 'h',
      minutes + 'm',
      seconds + 's'
    ].join(' ');
  }













}
