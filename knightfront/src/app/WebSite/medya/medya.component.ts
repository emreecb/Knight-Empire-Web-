import { Component, OnInit } from '@angular/core';
window["$"] = $;
window["jQuery"] = $;

@Component({
  selector: 'app-medya',
  templateUrl: './medya.component.html',
  styleUrls: ['./medya.component.scss']
})
export class MedyaComponent implements OnInit {

  constructor() { }

  ngOnInit() {
    // $(".fancybox").fancybox({
    //   openEffect: "none",
    //   closeEffect: "none"
    // });

    // $(".zoom").hover(function () {

    //   $(this).addClass('transition');
    // }, function () {

    //   $(this).removeClass('transition');
    // });
  }

}
