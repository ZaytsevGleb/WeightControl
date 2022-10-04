import {NgModule} from "@angular/core";
import {WcButtonRaisedModule} from "src/app/components/wc-buttons/wc-button-raised";
import {LoginPageComponent} from "./login-page.component";
import {WcInputEmailModule} from "../../../components/wc-inputs/wc-input-email";
import {RouterLinkWithHref} from "@angular/router";
import {WcInputPasswordModule} from "../../../components/wc-inputs/wc-input-password";


@NgModule({
  declarations: [LoginPageComponent],
  imports: [WcButtonRaisedModule, WcInputEmailModule, RouterLinkWithHref, WcInputPasswordModule],
  exports: [LoginPageComponent]
})

export class LoginPageModule {
}
