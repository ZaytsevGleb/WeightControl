import {NgModule} from "@angular/core";
import {WcButtonComponent} from "./wc-button.component";
import {MatButtonModule} from '@angular/material/button';

@NgModule({
  declarations:[WcButtonComponent],
  imports:[MatButtonModule],
  exports:[WcButtonComponent]
})

export class WcButtonModule {}
