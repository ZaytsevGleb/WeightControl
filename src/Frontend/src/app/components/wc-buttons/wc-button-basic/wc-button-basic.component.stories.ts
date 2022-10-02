import {Meta, Story} from "@storybook/angular/types-6-0";
import {WcButtonBasicComponent} from "./wc-button-basic.component";
import {moduleMetadata} from "@storybook/angular";
import {MatButtonModule} from "@angular/material/button";


export default {
  title: 'Components/ButtonBasic',
  component: WcButtonBasicComponent,
  decorators: [
    moduleMetadata({
      imports:[MatButtonModule]
    })
  ],
  argTypes: {
    buttonClick: {action:'buttonClick'}
  },
} as Meta<WcButtonBasicComponent>;

const Template: Story<WcButtonBasicComponent> = args => ({
  props: args,
  template: `
    <div style="display: flex;">
        <wc-button-basic
            [disabled]="[disabled]"
            [color]="color"
            [label]="label"
            (buttonClick)="buttonClick()">
        </wc-button-basic>
    </div>`
})

export const Default = Template.bind({})
Default.args = {
  label: "Button",
  color:'primary',
  disabled:false,

};
