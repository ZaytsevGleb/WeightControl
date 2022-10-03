import {Component, Input, OnInit} from '@angular/core';

@Component({
  selector: 'wc-icon',
  templateUrl: './wc-icon.component.html',
  styleUrls: ['./wc-icon.component.scss']
})
export class WcIconComponent implements OnInit {

  constructor() { }

  @Input()
  hidden!: boolean;

  @Input()
  fontIcon!: string;

  ngOnInit(): void {
  }

}
