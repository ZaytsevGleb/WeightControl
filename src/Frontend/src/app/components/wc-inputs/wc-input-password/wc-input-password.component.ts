import {Component, Input, OnInit} from '@angular/core';
import {FormControl, FormGroupDirective, NgForm, Validators} from '@angular/forms';
import {ErrorStateMatcher} from '@angular/material/core';

export class PasswordErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted = form && form.submitted;
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }
}

@Component({
  selector: 'wc-input-password',
  templateUrl: './wc-input-password.component.html',
  styleUrls: ['./wc-input-password.component.scss']
})
export class WcInputPasswordComponent implements OnInit {

  constructor() { }


  @Input()
  value!: string;

  @Input()
  validError!: string;

  @Input()
  color!: 'primary' | 'accent' | 'warn';

  @Input()
  appearance!: 'fill' | 'legacy' | 'standard' | 'outline';

  @Input()
  passwordFormControl = new FormControl('', [Validators.minLength(5) ,Validators.required]);

  @Input()
  matcher = new PasswordErrorStateMatcher();

  ngOnInit(): void {
  }

}
