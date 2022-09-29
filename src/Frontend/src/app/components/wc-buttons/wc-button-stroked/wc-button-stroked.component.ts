import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';

@Component({
  selector: 'wc-button-stroked',
  templateUrl: './wc-button-stroked.component.html',
  styleUrls: ['./wc-button-stroked.component.scss']
})
export class WcButtonStrokedComponent implements OnInit {

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
