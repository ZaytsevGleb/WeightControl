import {Meta, Story} from "@storybook/angular/types-6-0";
import {WcInputLoginComponent} from "./wc-input-login.component";
import {moduleMetadata} from "@storybook/angular";
import {MatInputModule} from "@angular/material/input";
import {BrowserModule} from '@angular/platform-browser';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {ReactiveFormsModule} from '@angular/forms';


export default {
  title: "Components/InputAccount",
  component: WcInputLoginComponent,
  decorators: [
    moduleMetadata({
      imports: [
        MatInputModule,
        BrowserModule,
        BrowserAnimationsModule,
        ReactiveFormsModule,
      ],
    })
  ],
  argTypes: {},
} as Meta<WcInputLoginComponent>;

const Template: Story<WcInputLoginComponent> = args => ({
  props: args,
  template: `
  <div style="display: grid;">
    <wc-input-login
        [label]="label"
        [value]="value"
        [placeholder]="placeholder"
        [validError]="validError"
        [color]="color"
        [type]="type">

  </wc-input-login>
  </div>`
})

export const Email = Template.bind({});
Email.args = {
  label: "Email",
  placeholder: "Ex. pat@example.com",
  value: "",
  validError: "Please enter a valid email address",
  color: "primary",
  type: "email",
}

export const Password = Template.bind({});
Password.args = {
  label: "Password",
  color: "primary",
  type: "password",
  value: "",
}

