import {Meta, Story} from "@storybook/angular/types-6-0";
import {WcInputComponent} from "./wc-input.component";
import {moduleMetadata} from "@storybook/angular";
import {MatInputModule} from "@angular/material/input";

export default {
  title: "Components/Input",
  component: WcInputComponent,
  decorators: [
    moduleMetadata({
      imports: [MatInputModule]
    })
  ],
  argTypes: {},
} as Meta<WcInputComponent>;

const Template: Story<WcInputComponent> = args => ({
  props: args,
  template: `
  <div style="display: flex;">
    <wc-input
        [header]="header"
        [value]="value"
        [placeholder]="placeholder">
  </wc-input>
  </div>`
})

export const Basic = Template.bind({});
Basic.args = {
  header: "Favorite food",
  placeholder: "Ex. Pizza",
  value: "Sushi"
}
