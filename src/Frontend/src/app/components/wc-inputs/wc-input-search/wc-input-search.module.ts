import {NgModule} from "@angular/core";
import {WcInputSearchComponent} from "./wc-input-search.component";
import {MatInputModule} from "@angular/material/input";
import {BrowserModule} from '@angular/platform-browser';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {MatNativeDateModule} from '@angular/material/core';


@NgModule({
  declarations: [WcInputSearchComponent],
  imports: [
    MatInputModule,
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    MatNativeDateModule,
  ],
  exports: [WcInputSearchComponent]
})

export class WcInputSearchModule {
}
