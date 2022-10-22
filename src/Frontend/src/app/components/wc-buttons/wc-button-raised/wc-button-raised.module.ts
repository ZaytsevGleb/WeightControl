import {NgModule} from "@angular/core";
import {WcButtonRaisedComponent} from "./wc-button-raised.component";
import {MatButtonModule} from '@angular/material/button';

@NgModule({
  declarations: [WcButtonRaisedComponent],
  imports: [MatButtonModule],
  exports: [WcButtonRaisedComponent]
})

export class WcButtonRaisedModule {
}
