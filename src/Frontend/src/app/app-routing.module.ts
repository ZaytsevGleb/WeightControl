import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {ProductsPageComponent} from './pages/site/body/products-page/products-page.component';
import {MealsPageComponent} from './pages/site/body/meals-page/meals-page.component';
import {GoalsPageComponent} from './pages/site/body/goals-page/goals-page.component';
import {SettingsPageComponent} from './pages/site/body/settings-page/settings-page.component';
import {HelpPageComponent} from './pages/site/body/help-page/help-page.component';
import {LoginPageComponent} from "./pages/authentication/login-page/login-page.component";
import {RegisterPageComponent} from "./pages/authentication/register-page/register-page.component";
import {SiteLayoutComponent} from "./layouts/site-layout/site-layout.component";
import {AuthLayoutComponent} from "./layouts/auth-layout/auth-layout.component";
import {AppAuthGuard} from "./app-auth.guard";

const routes: Routes = [
  {
    path: '', component: AuthLayoutComponent, children: [
      {path: 'login', component: LoginPageComponent},
      {path: 'register', component: RegisterPageComponent}
    ]
  },
  {
    path: '', component: SiteLayoutComponent, canActivate: [AppAuthGuard], children: [
      {path: '', redirectTo: '/login', pathMatch: 'full'},
      {path: 'products', component: ProductsPageComponent},
      {path: 'meals', component: MealsPageComponent},
      {path: 'goals', component: GoalsPageComponent},
      {path: 'settings', component: SettingsPageComponent},
      {path: 'help', component: HelpPageComponent}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
