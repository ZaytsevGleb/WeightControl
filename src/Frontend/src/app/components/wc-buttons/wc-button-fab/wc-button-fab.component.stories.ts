import {Meta, Story} from "@storybook/angular/types-6-0";
import {WcButtonFabComponent} from "./wc-button-fab.component";
import {moduleMetadata} from "@storybook/angular";
import {MatButtonModule} from "@angular/material/button";
import {MatIconModule} from "@angular/material/icon";

export default {
  title: 'Components/ButtonFab',
  component: WcButtonFabComponent,
  decorators: [
    moduleMetadata({
      imports: [MatButtonModule, MatIconModule]
    })
  ],
  argTypes: {
    buttonClick: {action: 'buttonClick'}
  },
} as Meta<WcButtonFabComponent>;

const Template: Story<WcButtonFabComponent> = args => ({
  props: args,
  template: `
    <div style="display: flex;">
        <wc-button-fab
            [icon]="icon"
            [disabled]="[disabled]"
            [color]="color"
            (buttonClick)="buttonClick()">
        </wc-button-fab>
    </div>`
})

export const Fab = Template.bind({})
Fab.args = {
  icon: 'bookmark',
  disabled: false,
  color: "accent"
};
