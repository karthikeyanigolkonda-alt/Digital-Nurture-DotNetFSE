import { Directive, HostListener, Input, ElementRef } from '@angular/core';

@Directive({
  selector: '[appHighlight]'
})
export class HighlightDirective {

  @Input() appHighlight = 'yellow';

  constructor(private el: ElementRef) {}

  @HostListener('mouseenter')
  onEnter(): void {
    this.el.nativeElement.style.backgroundColor = this.appHighlight;
  }

  @HostListener('mouseleave')
  onLeave(): void {
    this.el.nativeElement.style.backgroundColor = '';
  }
}