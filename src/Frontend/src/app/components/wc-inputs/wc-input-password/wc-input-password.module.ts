import {NgModule} from "@angular/core";
import {BrowserModule} from '@angular/platform-browser';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {WcInputPasswordComponent} from "./wc-input-password.component";
import {MatInputModule} from "@angular/material/input";
import {ReactiveFormsModule} from '@angular/forms';

@NgModule({
  declarations: [WcInputPasswordComponent],
  imports: [
    MatInputModule,
    BrowserAnimationsModule,
    BrowserModule,
    ReactiveFormsModule
  ],
  exports: [WcInputPasswordComponent]
})

export class WcInputPasswordModule {}
