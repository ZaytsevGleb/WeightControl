import {Meta, Story} from "@storybook/angular/types-6-0";
import {WcButtonRaisedComponent} from "./wc-button-raised.component";
import {moduleMetadata} from "@storybook/angular";
import {MatButtonModule} from "@angular/material/button";


export default {
  title: 'Components/ButtonRaised',
  component: WcButtonRaisedComponent,
  decorators: [
    moduleMetadata({
      imports: [MatButtonModule]
    })
  ],
  argTypes: {
    buttonClick: {action: 'buttonClick'}
  },
} as Meta<WcButtonRaisedComponent>;

const Template: Story<WcButtonRaisedComponent> = args => ({
  props: args,
  template: `
    <div style="display: flex;">
        <wc-button-raised
            [disabled]="[disabled]"
            [color]="color"
            [label]="label"
            (buttonClick)="buttonClick()">
        </wc-button-raised>
    </div>`
})

export const Raised = Template.bind({})
Raised.args = {
  label: "Button",
  color: 'primary',
  disabled: false
};
