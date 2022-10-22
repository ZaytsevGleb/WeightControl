import {Meta, Story} from "@storybook/angular/types-6-0";
import {WcInputPasswordComponent} from "./wc-input-password.component";
import {moduleMetadata} from "@storybook/angular";
import {MatInputModule} from "@angular/material/input";
import {BrowserModule} from '@angular/platform-browser';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {ReactiveFormsModule} from '@angular/forms';

export default {
  title: "Components/InputPassword",
  component: WcInputPasswordComponent,
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
  argTypes: {
    passwordFormControl: {table: {disable: true}},
    matcher: {table: {disable: true}}
  },
} as Meta<WcInputPasswordComponent>;

const Template: Story<WcInputPasswordComponent> = args => ({
  props: args,
  template: `
    <wc-input-password
        [value]="value"
        [color]="color"
        [validError]="validError"
        [appearance]="appearance">
    </wc-input-password>`
})

export const Password = Template.bind({});
Password.args = {
  value: "",
  color: "primary",
  validError: "Minimum length 5 characters",
  appearance: "fill"
}
