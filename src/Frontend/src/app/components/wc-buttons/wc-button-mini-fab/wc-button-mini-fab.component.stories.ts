import {Meta, Story} from "@storybook/angular/types-6-0";
import {WcButtonMiniFabComponent} from "./wc-button-mini-fab.component";
import {moduleMetadata} from "@storybook/angular";
import {MatButtonModule} from "@angular/material/button";
import {MatIconModule} from "@angular/material/icon";

export default {
  title: 'Components/ButtonMiniFab',
  component: WcButtonMiniFabComponent,
  decorators: [
    moduleMetadata({
      imports: [MatButtonModule, MatIconModule]
    })
  ],
  argTypes: {
    buttonClick: {action: 'buttonClick'}
  },
} as Meta<WcButtonMiniFabComponent>;

const Template: Story<WcButtonMiniFabComponent> = args => ({
  props: args,
  template: `
    <div style="display: flex;">
        <wc-button-mini-fab
            [icon]="icon"
            [disabled]="[disabled]"
            [color]="color"
            (buttonClick)="buttonClick()">
        </wc-button-mini-fab>
    </div>`
})

export const MiniFab = Template.bind({})
MiniFab.args = {
  icon: 'bookmark',
  disabled: false,
  color: "accent"
};
