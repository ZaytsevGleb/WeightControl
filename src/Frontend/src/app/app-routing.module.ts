import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductsPageComponent } from './components/body/products-page/products-page.component';
import { MealsPageComponent } from './components/body/meals-page/meals-page.component';
import { GoalsPageComponent } from './components/body/goals-page/goals-page.component';
import { SettingsPageComponent } from './components/body/settings-page/settings-page.component';
import { HelpPageComponent } from './components/body/help-page/help-page.component';

const routes: Routes = [
  {path: '', redirectTo: '/meals', pathMatch: 'full' },
  {path: 'products', component: ProductsPageComponent},
  {path: 'meals', component: MealsPageComponent},
  {path: 'goals', component: GoalsPageComponent},
  {path: 'settings', component: SettingsPageComponent},
  {path: 'help', component: HelpPageComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
