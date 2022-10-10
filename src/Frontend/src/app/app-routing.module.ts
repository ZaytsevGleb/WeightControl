import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductsPageComponent } from './pages/body/products-page/products-page.component';
import { MealsPageComponent } from './pages/body/meals-page/meals-page.component';
import { GoalsPageComponent } from './pages/body/goals-page/goals-page.component';
import { SettingsPageComponent } from './pages/body/settings-page/settings-page.component';
import { HelpPageComponent } from './pages/body/help-page/help-page.component';
import {LoginPageComponent} from "./pages/body/login-page/login-page.component";
import {RegisterPageComponent} from "./pages/body/register-page/register-page.component";

const routes: Routes = [
  {path: '', redirectTo: '/login', pathMatch: 'full' },
  {path: 'products', component: ProductsPageComponent},
  {path: 'meals', component: MealsPageComponent},
  {path: 'goals', component: GoalsPageComponent},
  {path: 'settings', component: SettingsPageComponent},
  {path: 'help', component: HelpPageComponent},
  {path: 'login', component:LoginPageComponent},
  {path: 'register', component: RegisterPageComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
