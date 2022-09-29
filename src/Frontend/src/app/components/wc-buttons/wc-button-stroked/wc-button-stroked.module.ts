import {NgModule} from "@angular/core";
import {WcButtonStrokedComponent} from "./wc-button-stroked.component";
import {MatButtonModule} from '@angular/material/button';

@NgModule({
  declarations:[WcButtonStrokedComponent],
  imports:[MatButtonModule],
  exports:[WcButtonStrokedComponent]
})

export class WcButtonRaisedModule {}
