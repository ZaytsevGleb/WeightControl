import {NgModule} from "@angular/core";
import {WcInputComponent} from "./wc-input.component";
import {MatInputModule} from "@angular/material/input";

@NgModule({
  declarations:[WcInputComponent],
  imports: [ MatInputModule],
  exports: [WcInputComponent]
})

export class WcInputModule {}
