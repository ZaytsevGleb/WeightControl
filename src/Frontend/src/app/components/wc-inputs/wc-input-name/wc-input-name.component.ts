import {Component, Input, OnInit} from '@angular/core';
import {ErrorStateMatcher} from "@angular/material/core";
import {FormControl, FormGroupDirective, NgForm, Validators} from "@angular/forms";

export class NameErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted = form && form.submitted;
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }
}

@Component({
  selector: 'wc-input-name',
  templateUrl: './wc-input-name.component.html',
  styleUrls: ['./wc-input-name.component.scss']
})
export class WcInputNameComponent implements OnInit {

  constructor() {
  }

  @Input()
  value!: string;

  @Input()
  validError!: string;

  @Input()
  placeholder!: string;

  @Input()
  color!: 'primary' | 'accent' | 'warn';

  @Input()
  appearance!: 'fill' | 'legacy' | 'standard' | 'outline';

  @Input()
  nameFormControl = new FormControl('', [Validators.minLength(2), Validators.required]);

  @Input()
  matcher = new NameErrorStateMatcher();

  ngOnInit(): void {
  }

}
