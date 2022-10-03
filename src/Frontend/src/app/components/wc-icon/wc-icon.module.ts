import {NgModule} from "@angular/core";
import {MatIconModule} from "@angular/material/icon";
import {WcIconComponent} from "./wc-icon.component";

@NgModule({
  declarations: [WcIconComponent],
  imports: [
    MatIconModule
  ],
  exports: [WcIconComponent]
})

export class WcIconModule {
}
