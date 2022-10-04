import {Meta, Story} from "@storybook/angular/types-6-0";
import {WcInputSearchComponent} from "./wc-input-search.component";
import {moduleMetadata} from "@storybook/angular";
import {MatInputModule} from "@angular/material/input";
import {BrowserModule} from '@angular/platform-browser';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {ReactiveFormsModule} from '@angular/forms';

export default {
  title: "Components/InputSearch",
  component: WcInputSearchComponent,
  decorators: [
    moduleMetadata({
      imports: [
        MatInputModule,
        BrowserModule,
        BrowserAnimationsModule,
        ReactiveFormsModule,
      ]
    })
  ],
  argTypes: {},
} as Meta<WcInputSearchComponent>;

const Template: Story<WcInputSearchComponent> = args => ({
  props: args,
  template: `
    <wc-input-search
        [label]="label"
        [value]="value"
        [placeholder]="placeholder"
        [color]="color"
        [appearance]="appearance">
    </wc-input-search>`
})

export const Search = Template.bind({});
Search.args = {
  label: "Favorite food",
  placeholder: "Ex. Pizza",
  value: "Sushi",
  color: "primary",
  appearance: "fill"
}
