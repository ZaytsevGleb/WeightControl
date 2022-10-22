import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';
import {HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http'
import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {HeaderComponent} from './pages/site/header/header.component';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {MenuComponent} from './pages/site/menu/menu.component';
import {PromptComponent} from './pages/site/prompt/prompt.component';
import {FooterComponent} from './pages/site/footer/footer.component';
import {ProductsPageComponent} from './pages/site/body/products-page/products-page.component';
import {GoalsPageComponent} from './pages/site/body/goals-page/goals-page.component';
import {SettingsPageComponent} from './pages/site/body/settings-page/settings-page.component';
import {HelpPageComponent} from './pages/site/body/help-page/help-page.component';
import {MealsPageComponent} from './pages/site/body/meals-page/meals-page.component';
import {MealsPartComponent} from './pages/site/body/meals-page/meals-part/meals-part.component';
import {ProductsPartComponent} from './pages/site/body/meals-page/products-part/products-part.component';
import {FormsModule} from '@angular/forms';
import {AmountDialogComponent} from './pages/site/body/meals-page/amount-dialog/amount-dialog.component';
import {ApiClient, API_BASE_URL} from './clients/api.client';
import {environment} from 'src/environments/environment';
import {RegisterPageModule} from "./pages/authentication/register-page/register-page.module";
import {WcComponentsModule} from "./components/wc-components.module";
import {LoginPageModule} from "./pages/authentication/login-page/login-page.module";
import {AuthLayoutComponent} from './layouts/auth-layout/auth-layout.component';
import {SiteLayoutComponent} from './layouts/site-layout/site-layout.component';
import {TokenInterceptor} from "./token.interceptor";
import {MatSnackBarModule} from "@angular/material/snack-bar";

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
    AuthLayoutComponent,
    SiteLayoutComponent,
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
    LoginPageModule,
    WcComponentsModule,
    RegisterPageModule,
    MatSnackBarModule
  ],
  providers: [
    ApiClient,
    {provide: HTTP_INTERCEPTORS, multi: true, useClass: TokenInterceptor},
    {provide: API_BASE_URL, useValue: environment.apiUrl}
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}
