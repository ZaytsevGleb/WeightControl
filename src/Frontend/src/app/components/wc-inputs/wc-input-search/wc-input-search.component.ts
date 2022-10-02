import {Component, Input} from '@angular/core';

@Component({
  selector: 'wc-input-search',
  templateUrl: './wc-input-search.component.html',
  styleUrls: ['./wc-input-search.component.scss']
})
export class WcInputSearchComponent {

  constructor() {
  }

  @Input()
  label!: string;

  @Input()
  value!: string;

  @Input()
  placeholder!: string;

  @Input()
  color!: 'primary' | 'accent' | 'warn' | null;
}
