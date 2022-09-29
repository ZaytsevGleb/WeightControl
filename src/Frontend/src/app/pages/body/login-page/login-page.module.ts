import {NgModule} from "@angular/core";
import { WcButtonRaisedModule } from "src/app/components/wc-buttons/wc-button-raised";
import {LoginPageComponent} from "./login-page.component";

@NgModule({
  declarations:[LoginPageComponent],
  imports:[WcButtonRaisedModule],
  exports:[LoginPageComponent]
})

export class LoginPageModule {}
