import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule} from '@angular/common/http'
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/header/header.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MenuComponent } from './components/menu/menu.component';
import { PromptComponent } from './components/prompt/prompt.component';
import { FooterComponent } from './components/footer/footer.component';
import { ProductsPageComponent } from './components/body/products-page/products-page.component';
import { GoalsPageComponent } from './components/body/goals-page/goals-page.component';
import { SettingsPageComponent } from './components/body/settings-page/settings-page.component';
import { HelpPageComponent } from './components/body/help-page/help-page.component';
import { MealsPageComponent } from './components/body/meals-page/meals-page.component';
import { MealsPartComponent } from './components/body/meals-page/meals-part/meals-part.component';
import { ProductsPartComponent } from './components/body/meals-page/products-part/products-part.component';
import { FormsModule } from '@angular/forms';
import { AmountDialogComponent } from './components/body/meals-page/amount-dialog/amount-dialog.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    MenuComponent,
    PromptComponent,
    FooterComponent,
    ProductsPageComponent,
    MealsPageComponent,
    GoalsPageComponent,
    SettingsPageComponent,
    HelpPageComponent,
    MealsPartComponent,
    ProductsPartComponent,
    AmountDialogComponent
  ],
  
    entryComponents: [
    AmountDialogComponent,
    
  ],

  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
