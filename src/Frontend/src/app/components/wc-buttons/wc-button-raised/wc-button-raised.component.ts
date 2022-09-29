import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';

@Component({
  selector: 'wc-button-raised',
  templateUrl: './wc-button-raised.component.html',
  styleUrls: ['./wc-button-raised.component.scss']
})
export class WcButtonRaisedComponent implements OnInit {

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
