import { Directive, ElementRef, Renderer, OnInit } from '@angular/core';
// tslint:disable-next-line:directive-selector
@Directive({ selector: '[Myfocus]' })
// tslint:disable-next-line:class-name
// tslint:disable-next-line:directive-class-suffix
export class Myfocus implements OnInit {
  constructor(private el: ElementRef, private renderer: Renderer) {
    // focus won't work at construction time - too early
  }
  ngOnInit() {
    this.renderer.invokeElementMethod(this.el.nativeElement, 'focus', []);
  }
}
