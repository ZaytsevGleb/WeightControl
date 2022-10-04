import {Meta, Story} from "@storybook/angular/types-6-0";
import {WcInputEmailComponent} from "./wc-input-email.component";
import {moduleMetadata} from "@storybook/angular";
import {MatInputModule} from "@angular/material/input";
import {BrowserModule} from '@angular/platform-browser';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {ReactiveFormsModule} from '@angular/forms';


export default {
  title: "Components/InputEmail",
  component: WcInputEmailComponent,
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
    emailFormControl: {table: {disable: true}},
    matcher: {table: {disable: true}}
  },
} as Meta<WcInputEmailComponent>;

const Template: Story<WcInputEmailComponent> = args => ({
  props: args,
  template: `
    <wc-input-email
        [value]="value"
        [placeholder]="placeholder"
        [validError]="validError"
        [color]="color"
        [appearance]="appearance">
    </wc-input-email>
  `
})

export const Email = Template.bind({});
Email.args = {
  placeholder: "Ex. pat@example.com",
  value: "",
  validError: "Please enter a valid email address",
  color: "primary",
  appearance: "fill"
}
