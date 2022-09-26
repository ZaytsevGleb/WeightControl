import {NgModule} from "@angular/core";
import { WcButtonModule } from "src/app/components/wc-button";
import {LoginPageComponent} from "./login-page.component";

@NgModule({
  declarations:[LoginPageComponent],
  imports:[WcButtonModule],
  exports:[LoginPageComponent]
})

export class LoginPageModule {}
