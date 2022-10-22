import {NgModule} from "@angular/core";
import {WcInputSearchComponent} from "./wc-input-search.component";
import {MatInputModule} from "@angular/material/input";
import {BrowserModule} from '@angular/platform-browser';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {ReactiveFormsModule} from '@angular/forms';

@NgModule({
  declarations: [WcInputSearchComponent],
  imports: [
    MatInputModule,
    BrowserAnimationsModule,
    BrowserModule,
    ReactiveFormsModule
  ],
  exports: [WcInputSearchComponent]
})

export class WcInputSearchModule {
}
