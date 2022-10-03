import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';

@Component({
  selector: 'wc-button-mini-fab',
  templateUrl: './wc-button-mini-fab.component.html',
  styleUrls: ['./wc-button-mini-fab.component.scss']
})
export class WcButtonMiniFabComponent implements OnInit {

  constructor() {
  }

  @Input()
  icon?: string;

  @Input()
  disabled?: boolean;

  @Input()
  color?: 'primary' | 'accent' | 'warn' | null;

  //Output
  @Output()
  buttonClick = new EventEmitter<void>();

  ngOnInit(): void {
  }

  onClick() {
    this.buttonClick.emit();
  }
}
