import {NgModule} from "@angular/core";
import {BrowserModule} from '@angular/platform-browser';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {WcInputEmailComponent} from "./wc-input-email.component";
import {MatInputModule} from "@angular/material/input";
import {ReactiveFormsModule} from '@angular/forms';

@NgModule({
  declarations: [WcInputEmailComponent],
  imports: [
    MatInputModule,
    BrowserAnimationsModule,
    BrowserModule,
    ReactiveFormsModule
  ],
  exports: [WcInputEmailComponent]
})

export class WcInputEmailModule {
}
