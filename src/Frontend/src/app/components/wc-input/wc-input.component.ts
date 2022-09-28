import {Component, Input, OnInit} from '@angular/core';

@Component({
  selector: 'wc-input',
  templateUrl: './wc-input.component.html',
  styleUrls: ['./wc-input.component.scss']
})
export class WcInputComponent implements OnInit {

  @Input()
  header?: string;

  @Input()
  value?: string;

  @Input()
  placeholder?: string;

  constructor() { }

  ngOnInit(): void {
  }

}
