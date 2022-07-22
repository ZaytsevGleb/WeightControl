import { DEFAULT_CURRENCY_CODE, Injectable, OnDestroy, OnInit, Output } from '@angular/core';
import { last, Subject, Subscription, takeUntil } from 'rxjs';
import { MealProduct } from '../models/mealproduct'
import { Meal, TypeOfMeal } from '../models/meal';
import { MealsController } from './meals.controller';

@Injectable({
  providedIn: 'root'
})
export class MealsService {
  mealId: number = 0;
  public date = new Date;
  breakfast: Array<MealProduct> = [];
  lunch: Array<MealProduct> = [];
  dinner: Array<MealProduct> = [];
  snack: Array<MealProduct> = [];
  meals: Array<Meal> = [];
  meal!: Meal;
  private readonly mealsController: MealsController;
  private destroy$ = new Subject();


  constructor(mealsController: MealsController) {
    this.mealsController = mealsController;
  }

  addMeal(typeOfMeal: TypeOfMeal, date: Date, mealproducts: Array<MealProduct>): void {
    if (this.date.toLocaleDateString() == date.toLocaleDateString() &&
        this.meals.find(p => p.date.toLocaleDateString() == date.toLocaleDateString())
        && this.meals.find(p=> p.type == typeOfMeal)) {

      this.meals.find(p => p.date.toLocaleDateString() == date.toLocaleDateString()
        && p.type == typeOfMeal)!.products = mealproducts;
    }
    else {
      this.meal = { id: this.mealId, type: typeOfMeal, date: this.date, products: mealproducts }
      this.meals.push(this.meal);
      this.mealId++;
    }
    console.log(this.meals)
    console.log(this.breakfast)
  }

  deleteMeal(id: number,date: Date): void {
    let index = this.meals.findIndex( p =>p.products == this.breakfast );
    this.meals.find(p =>p.products == this.breakfast && p.date.toLocaleDateString() == date.toLocaleDateString()
     && p.products.find(m=> m.id == id))?.products.splice(index,1);
    console.log(this.meals)
    console.log(this.breakfast, "delete")
  }

  deleteMealProduct(id: number, typeofMeal: number, prodictId: number): void {
    switch (typeofMeal) {
      case 0:
        this.deleteMeal(id, this.breakfast[0].date);
        this.breakfast = this.breakfast.filter(p => p.id !== id);
        break;
      case 1:
        this.deleteMeal(id, this.lunch[0].date);
        this.lunch = this.lunch.filter(p => p.id !== id);
        break;
      case 2:
        this.deleteMeal(id, this.dinner[0].date);
        this.dinner = this.dinner.filter(p => p.id !== id);
        break;
      case 3:
        this.deleteMeal(id, this.snack[0].date);
        this.snack = this.snack.filter(p => p.id !== id);
        break;
    }
  }

  addMealProduct(mealProduct: MealProduct, type: TypeOfMeal): void {
    switch (type) {
      case 0:
        this.breakfast.push(mealProduct);
        this.addMeal(type, this.breakfast[0].date, this.breakfast)
        break;
      case 1:
        this.lunch.push(mealProduct);
        this.addMeal(type, this.lunch[0].date, this.lunch)
        break;
      case 2:
        this.dinner.push(mealProduct);
        this.addMeal(type, this.dinner[0].date, this.dinner)
        break;
      case 3:
        this.snack.push(mealProduct);
        this.addMeal(type, this.snack[0].date, this.snack)
        break;
    }
  }

}