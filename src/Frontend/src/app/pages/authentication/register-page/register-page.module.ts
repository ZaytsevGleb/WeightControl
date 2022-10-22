import {NgModule} from "@angular/core";
import {WcButtonRaisedModule} from "src/app/components/wc-buttons/wc-button-raised";
import {RegisterPageComponent} from "./register-page.component";
import {WcInputEmailModule} from "../../../components/wc-inputs/wc-input-email";
import {RouterLinkWithHref} from "@angular/router";
import {WcInputPasswordModule} from "../../../components/wc-inputs/wc-input-password";
import {WcInputNameModule} from "../../../components/wc-inputs/wc-input-name";


@NgModule({
  declarations: [RegisterPageComponent],
  imports: [WcButtonRaisedModule, WcInputEmailModule, RouterLinkWithHref, WcInputPasswordModule, WcInputNameModule],
  exports: [RegisterPageComponent]
})

export class RegisterPageModule {
}
