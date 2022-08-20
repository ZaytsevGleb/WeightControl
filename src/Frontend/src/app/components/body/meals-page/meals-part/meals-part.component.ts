import { Component, DoCheck, OnDestroy, OnInit } from '@angular/core';
import { Meal, TypeOfMeal } from 'src/app/models/meal';
import { MealsController } from 'src/app/services/meals.controller';
import { SelectedProductParams } from 'src/app/models/selected-product-params';
import { ProductsService } from 'src/app/services/products.service';
import { Subject, takeUntil } from 'rxjs';
import { MealsService } from 'src/app/services/meals.service';
import { Product } from 'src/app/models/product';
import { MealProduct } from 'src/app/models/mealproduct';

@Component({
  selector: 'app-meals-part',
  templateUrl: './meals-part.component.html',
  styleUrls: ['./meals-part.component.scss']
})
export class MealsPartComponent implements OnInit, OnDestroy, DoCheck {
  product!: Product;
  public date = new Date;
  products: Array<Product> = [];
  breakfast: Array<MealProduct> = [];
  lunch: Array<MealProduct> = [];
  dinner: Array<MealProduct> = [];
  snack: Array<MealProduct> = [];


  private mealproductId: number = 0;
  private destroy$ = new Subject();
  private readonly mealsController: MealsController;
  private readonly productService: ProductsService
  private readonly mealsService: MealsService;

  constructor(mealsController: MealsController, productService: ProductsService, mealsService: MealsService) {
    this.mealsController = mealsController;
    this.productService = productService;
    this.mealsService = mealsService;
  }

  ngDoCheck(): void {
    this.breakfast = this.mealsService.breakfast;
    this.lunch = this.mealsService.lunch;
    this.dinner = this.mealsService.dinner;
    this.snack = this.mealsService.snack;
  }

  ngOnInit(): void {
    this.mealsController.porductSelected$.pipe(takeUntil(this.destroy$))
    .subscribe(params => this.addProduct(params));
  }

  ngOnDestroy() {
    this.destroy$.next(true);
    this.destroy$.complete();
  }

  public showProducts(typeofMeal: TypeOfMeal): void {
    this.mealsController.setFocus(typeofMeal);
  }

  private addProduct(params: SelectedProductParams): void {
    this.product = params.product;
    this.products.push(this.product);
    let mealProduct: MealProduct = { id: this.mealproductId, productId: this.product.id, date: this.date, amount: params.amount }
    this.mealproductId++;
    this.mealsService.addMealProduct(mealProduct, params.typeofMeal);
  }

  deleteMealProduct(id: number, typeofMeal: number, productId: number): void {
    this.mealsService.deleteMealProduct(id, typeofMeal, productId);
    // this.products = this.products.filter(p => p.id !== productId, 1);
    let index = this.products.findIndex(p => p.id ==productId);
    this.products.splice(index, 1);
  }
  //тоже берд какая-то, мне кажется что так не должно быть, но тем не менее имеем что имеем
  showProductName(id: number): string {
    let value = this.products.find(p => p.id == id)!;
      return value.name;
    
  }

  showProductCalories(id: number, amount: number): number {
    let value = this.products.find(p => p.id == id)!;
    return value.calories * amount;
  }
  //это можно попровать сделать через Subject и слушать в product-part
  showProductUnit(id: number): string {
    let value = this.products.find(p => p.id == id)!;
    switch (value.unit) {
      case 0:
        return "Milliliters"
        break;
      case 1:
        return "Gram"
        break;
      case 2:
        return "Pieces"
        break;
      default:
        return "";
        break;
    }
  }
  setAmount(id: number, amount: number): number {
    let value = this.products.find(p => p.id == id)!;
    switch (value.unit) {
      case 0:
        return 100 * amount;
        break;
      case 1:
        return 100 * amount;
        break;
      case 2:
        return 1 * amount;
        break;
      default:
        return 0;
        break;
    }
  }
}
