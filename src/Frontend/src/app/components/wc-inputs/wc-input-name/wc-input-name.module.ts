import {NgModule} from "@angular/core";
import {BrowserModule} from '@angular/platform-browser';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {WcInputNameComponent} from "./wc-input-name.component";
import {MatInputModule} from "@angular/material/input";
import {ReactiveFormsModule} from '@angular/forms';

@NgModule({
  declarations:[WcInputNameComponent],
  imports: [
    MatInputModule,
    BrowserModule,
    BrowserAnimationsModule,
    ReactiveFormsModule
  ],
  exports: [WcInputNameComponent]
})

export class WcInputNameModule {}
