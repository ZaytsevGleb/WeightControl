import {NgModule} from "@angular/core";
import {WcButtonRaisedModule} from "src/app/components/wc-buttons/wc-button-raised";
import {LoginPageComponent} from "./login-page.component";
import {WcInputEmailModule} from "../../../components/wc-inputs/wc-input-login";
import {RouterLinkWithHref} from "@angular/router";


@NgModule({
  declarations: [LoginPageComponent],
  imports: [WcButtonRaisedModule, WcInputEmailModule, RouterLinkWithHref],
  exports: [LoginPageComponent]
})

export class LoginPageModule {
}
