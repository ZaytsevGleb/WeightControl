import {Meta, Story} from "@storybook/angular/types-6-0";
import {WcButtonStrokedComponent} from "./wc-button-stroked.component";
import {moduleMetadata} from "@storybook/angular";
import {MatButtonModule} from "@angular/material/button";


export default {
  title: 'Components/ButtonStroked',
  component: WcButtonStrokedComponent,
  decorators: [
    moduleMetadata({
      imports:[MatButtonModule]
    })
  ],
  argTypes: {
    buttonClick: {action:'buttonClick'}
  },
} as Meta<WcButtonStrokedComponent>;

const Template: Story<WcButtonStrokedComponent> = args => ({
  props: args,
  template: `
    <div style="display: flex;">
        <wc-button-stroked
            [disabled]="[disabled]"
            [color]="color"
            [label]="label"
            (buttonClick)="buttonClick()">
        </wc-button-stroked>
    </div>`
})

export const Stroked = Template.bind({})
Stroked.args = {
  label: "Button",
  color:'primary',
  disabled:false
};
