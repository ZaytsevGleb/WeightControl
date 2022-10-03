import {NgModule} from "@angular/core";
import {WcButtonMiniFabComponent} from "./wc-button-mini-fab.component";
import {MatButtonModule} from '@angular/material/button';
import {MatIconModule} from "@angular/material/icon";

@NgModule({
  declarations: [WcButtonMiniFabComponent],
  imports: [MatButtonModule, MatIconModule],
  exports: [WcButtonMiniFabComponent]
})

export class WcButtonMiniFabModule {
}
