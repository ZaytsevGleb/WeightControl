import {NgModule} from "@angular/core";
import {BrowserModule} from '@angular/platform-browser';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {WcInputLoginComponent} from "./wc-input-login.component";
import {MatInputModule} from "@angular/material/input";
import {ReactiveFormsModule} from '@angular/forms';

@NgModule({
  declarations: [WcInputLoginComponent],
  imports: [
    MatInputModule,
    BrowserAnimationsModule,
    BrowserModule,
    ReactiveFormsModule
  ],
  exports: [WcInputLoginComponent]
})

export class WcInputLoginModule {
}
