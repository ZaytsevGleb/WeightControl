import {Component, Input} from '@angular/core';
import {FormControl, FormGroupDirective, NgForm, Validators} from '@angular/forms';
import {ErrorStateMatcher} from '@angular/material/core';

export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted = form && form.submitted;
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }

}

@Component({
  selector: 'wc-input-login',
  templateUrl: './wc-input-login.component.html',
  styleUrls: ['./wc-input-login.component.scss']
})
export class WcInputLoginComponent {

  constructor() {
  }

  @Input()
  label!: string;

  @Input()
  value!: string;

  @Input()
  placeholder!: string;

  @Input()
  validError!: string;

  @Input()
  type!: 'password' | 'email';

  @Input()
  color!: 'primary' | 'accent' | 'warn' | null;


  @Input()
  emailFormControl = new FormControl('', [Validators.required, Validators.email]);

  @Input()
  passwordFormControl = new FormControl('', [Validators.required]);

  @Input()
  matcher = new MyErrorStateMatcher();
}
