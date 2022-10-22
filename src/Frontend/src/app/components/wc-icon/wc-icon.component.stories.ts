import {Meta, Story} from "@storybook/angular/types-6-0";
import {WcIconComponent} from "./wc-icon.component";
import {moduleMetadata} from "@storybook/angular";
import {MatIconModule} from "@angular/material/icon";


export default {
  title: 'Components/Icon',
  component: WcIconComponent,
  decorators: [
    moduleMetadata({
      imports: [MatIconModule
      ]
    })
  ],
  argTypes: {
    buttonClick: {action: 'buttonClick'}
  },
} as Meta<WcIconComponent>;

const Template: Story<WcIconComponent> = args => ({
  props: args,
  template: `
    <div style="display: flex;">
        <wc-icon
        [hidden]="hidden"
        [fontIcon]="fontIcon">
        </wc-icon>
    </div>`
})

export const Icon = Template.bind({})
Icon.args = {
  hidden: false,
  fontIcon: "home"
};
