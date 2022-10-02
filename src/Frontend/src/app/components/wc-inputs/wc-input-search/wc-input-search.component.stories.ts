import {Meta, Story} from "@storybook/angular/types-6-0";
import {WcInputSearchComponent} from "./wc-input-search.component";
import {moduleMetadata} from "@storybook/angular";
import {MatInputModule} from "@angular/material/input";
import {BrowserModule} from '@angular/platform-browser';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {MatNativeDateModule} from '@angular/material/core';
import {MatFormFieldModule} from "@angular/material/form-field";

export default {
  title: "Components/InputSearch",
  component: WcInputSearchComponent,
  decorators: [
    moduleMetadata({
      imports: [
        MatInputModule,
        BrowserModule,
        BrowserAnimationsModule,
        FormsModule,
        ReactiveFormsModule,
        MatNativeDateModule,
        MatFormFieldModule
      ]
    })
  ],
  argTypes: {},
} as Meta<WcInputSearchComponent>;

const Template: Story<WcInputSearchComponent> = args => ({
  props: args,
  template: `
  <div style="display: flex;">
    <wc-input-search
        [label]="label"
        [value]="value"
        [placeholder]="placeholder"
        [color]="color">

  </wc-input-search>
  </div>`
})

export const Search = Template.bind({});
Search.args = {
  label: "Favorite food",
  placeholder: "Ex. Pizza",
  value: "Sushi",
  color: "primary"
}
