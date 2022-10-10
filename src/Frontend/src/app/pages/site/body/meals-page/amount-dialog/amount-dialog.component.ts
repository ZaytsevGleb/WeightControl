import { Component, EventEmitter, Inject, Input, OnInit, Output, ViewContainerRef } from '@angular/core';
@Component({
  selector: 'app-amount-dialog',
  templateUrl: './amount-dialog.component.html',
  styleUrls: ['./amount-dialog.component.scss']
})
export class AmountDialogComponent implements OnInit {

  amount:number = 1;
  public set _amount(n :number){
    if(n < 0 ){
      this.amount = 1;
    }
    else{
      this.amount =n;
    }
  }
  title = 'Enter the amount of food';
  @Output() close = new EventEmitter();
  @Output() accept = new EventEmitter();
  
  constructor(public containerRef: ViewContainerRef) { 
    containerRef.clear();
  }

  ngOnInit(): void {
  }
}
