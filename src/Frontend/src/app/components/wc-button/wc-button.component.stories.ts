import {Meta, Story} from "@storybook/angular/types-6-0";
import {WcButtonComponent} from "./wc-button.component";
import {moduleMetadata} from "@storybook/angular";
import {MatButtonModule} from "@angular/material/button";


export default {
  title: 'Components/Button',
  component: WcButtonComponent,
  decorators: [
    moduleMetadata({
      imports:[MatButtonModule]
    })
  ],
  argTypes: {
    backgroundColor: { control: 'color' },
    buttonClick: {action:'buttonClick'}
  },
} as Meta<WcButtonComponent>;

const Template: Story<WcButtonComponent> = args => ({
  props: args,
  template: `
    <div style="display: flex;">
        <wc-button
            [disabled]="[disabled]"
            [color]="color"
            [label]="label"
            (buttonClick)="buttonClick()">
        </wc-button>
    </div>`
})

export const Primary = Template.bind({})
Primary.args = {
  label: "Button",
  color:'primary',
  disabled:false

};
