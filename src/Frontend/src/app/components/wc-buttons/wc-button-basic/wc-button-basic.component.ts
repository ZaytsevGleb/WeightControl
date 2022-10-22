import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';

@Component({
  selector: 'wc-button-basic',
  templateUrl: './wc-button-basic.component.html',
  styleUrls: ['./wc-button-basic.component.scss']
})
export class WcButtonBasicComponent implements OnInit {

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
