import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule} from '@angular/common/http'
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './pages/header/header.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MenuComponent } from './pages/menu/menu.component';
import { PromptComponent } from './pages/prompt/prompt.component';
import { FooterComponent } from './pages/footer/footer.component';
import { ProductsPageComponent } from './pages/body/products-page/products-page.component';
import { GoalsPageComponent } from './pages/body/goals-page/goals-page.component';
import { SettingsPageComponent } from './pages/body/settings-page/settings-page.component';
import { HelpPageComponent } from './pages/body/help-page/help-page.component';
import { MealsPageComponent } from './pages/body/meals-page/meals-page.component';
import { MealsPartComponent } from './pages/body/meals-page/meals-part/meals-part.component';
import { ProductsPartComponent } from './pages/body/meals-page/products-part/products-part.component';
import { FormsModule } from '@angular/forms';
import { AmountDialogComponent } from './pages/body/meals-page/amount-dialog/amount-dialog.component';
import { ApiClient, API_BASE_URL } from './clients/api.client';
import { environment } from 'src/environments/environment';
import { LoginPageComponent } from './pages/body/login-page/login-page.component';
import { RegisterPageComponent } from './pages/body/register-page/register-page.component';
import {WcComponentsModule} from "./components/wc-components.module";
import {LoginPageModule} from "./pages/body/login-page/login-page.module";

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
    AmountDialogComponent,
    RegisterPageComponent
  ],
  entryComponents: [
    AmountDialogComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    HttpClientModule,
    WcComponentsModule,
    LoginPageModule
  ],
  providers: [
    ApiClient,
    { provide: API_BASE_URL, useValue: environment.apiUrl }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
