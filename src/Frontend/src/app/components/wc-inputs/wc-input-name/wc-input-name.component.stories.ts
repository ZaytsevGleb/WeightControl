import {Meta, Story} from "@storybook/angular/types-6-0";
import {WcInputNameComponent} from "./wc-input-name.component";
import {moduleMetadata} from "@storybook/angular";
import {MatInputModule} from "@angular/material/input";
import {BrowserModule} from '@angular/platform-browser';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {ReactiveFormsModule} from '@angular/forms';
import {WcInputEmailComponent} from "../wc-input-email";

export default {
  title: "Components/InputName",
  component: WcInputNameComponent,
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
    nameFormControl: {table: {disable: true}},
    matcher: {table: {disable: true}}
  },
} as Meta<WcInputNameComponent>;

const Template: Story<WcInputEmailComponent> = args => ({
  props: args,
  template: `
    <wc-input-name
        [value]="value"
        [placeholder]="placeholder"
        [validError]="validError"
        [color]="color"
        [appearance]="appearance">
    </wc-input-name>
  `
})

export const Name = Template.bind({});
Name.args = {
  placeholder: "Alex Evans",
  value: "",
  validError: "Minimum length 2 characters",
  color: "primary",
  appearance: "fill"
}
