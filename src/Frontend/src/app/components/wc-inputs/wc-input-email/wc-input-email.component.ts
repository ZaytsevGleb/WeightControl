import {Component, Input, OnInit} from '@angular/core';
import {FormControl, FormGroupDirective, NgForm, Validators} from '@angular/forms';
import {ErrorStateMatcher} from '@angular/material/core';

export class EmailErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted = form && form.submitted;
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }
}

@Component({
  selector: 'wc-input-email',
  templateUrl: './wc-input-email.component.html',
  styleUrls: ['./wc-input-email.component.scss']
})
export class WcInputEmailComponent implements OnInit {

  constructor() {
  }


  @Input()
  value!: string;

  @Input()
  placeholder!: string;

  @Input()
  validError!: string;

  @Input()
  color!: 'primary' | 'accent' | 'warn';

  @Input()
  appearance!: 'fill' | 'legacy' | 'standard' | 'outline';

  @Input()
  emailFormControl = new FormControl('', [Validators.required, Validators.email]);

  @Input()
  matcher = new EmailErrorStateMatcher();

  ngOnInit(): void {
  }

}
