import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';

@Component({
  selector: 'wc-button-fab',
  templateUrl: './wc-button-fab.component.html',
  styleUrls: ['./wc-button-fab.component.scss']
})
export class WcButtonFabComponent implements OnInit {

  constructor() { }

  //Inputs
  @Input()
  icon?: string;

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
