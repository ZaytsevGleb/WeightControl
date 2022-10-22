import {NgModule} from "@angular/core";
import {WcButtonBasicComponent} from "./wc-button-basic.component";
import {MatButtonModule} from "@angular/material/button";

@NgModule({
  declarations: [WcButtonBasicComponent],
  imports:[MatButtonModule],
  exports:[WcButtonBasicComponent]
})

export class WcButtonBasicModule {}
