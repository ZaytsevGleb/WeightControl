import {NgModule} from "@angular/core";
import {WcButtonFabComponent} from "./wc-button-fab.component";
import {MatButtonModule} from '@angular/material/button';
import {MatIconModule} from "@angular/material/icon";

@NgModule({
  declarations:[WcButtonFabComponent],
  imports:[MatButtonModule, MatIconModule],
  exports:[WcButtonFabComponent]
})

export class WcButtonRaisedModule {}
