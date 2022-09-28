import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';

@Component({
  selector: 'wc-button',
  templateUrl: './wc-button.component.html',
  styleUrls: ['./wc-button.component.scss']
})
export class WcButtonComponent implements OnInit {

  constructor() { }

  //Inputs
  @Input()
  label?: string;

  @Input()
  disabled?:boolean;

  @Input()
  color?: 'primary' | 'accent' | 'warn' | null;

  //Output
  @Output()
  buttonClick = new EventEmitter<void>();

  ngOnInit(): void {
  }

  onClick(){
    this.buttonClick.emit();
  }
}
