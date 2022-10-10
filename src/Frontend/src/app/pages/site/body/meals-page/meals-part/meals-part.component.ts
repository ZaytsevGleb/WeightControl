import {Component, DoCheck, OnDestroy, OnInit} from '@angular/core';
import {TypeOfMeal} from 'src/app/models/meal';
import {MealsController} from 'src/app/services/meals.controller';
import {SelectedProductParams} from 'src/app/models/selected-product-params';
import {ProductsService} from 'src/app/services/products.service';
import {Subject, takeUntil} from 'rxjs';
import {MealsService} from 'src/app/services/meals.service';
import {Product} from 'src/app/models/product';
import {MealProduct} from 'src/app/models/mealproduct';

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


  private mealProductId: number = 0;
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
    let mealProduct: MealProduct = {
      id: this.mealProductId,
      productId: this.product.id,
      date: this.date,
      amount: params.amount
    }
    this.mealProductId++;
    this.mealsService.addMealProduct(mealProduct, params.typeofMeal);
  }

  deleteMealProduct(id: number, typeofMeal: number, productId: number): void {
    this.mealsService.deleteMealProduct(id, typeofMeal, productId);
    let index = this.products.findIndex(p => p.id == productId);
    this.products.splice(index, 1);
  }

  showProductName(id: number): string {
    let value = this.products.find(p => p.id == id)!;
    return value.name;

  }

  showProductCalories(id: number, amount: number): number {
    let value = this.products.find(p => p.id == id)!;
    return value.calories * amount;
  }

  showProductUnit(id: number): string {
    let value = this.products.find(p => p.id == id)!;
    switch (value.unit) {
      case 0:
        return "Milliliters"
      case 1:
        return "Gram"
      case 2:
        return "Pieces"
      default:
        return "";
    }
  }

  setAmount(id: number, amount: number): number {
    let value = this.products.find(p => p.id == id)!;
    switch (value.unit) {
      case 0:
        return 100 * amount;
      case 1:
        return 100 * amount;
      case 2:
        return amount;
      default:
        return 0;
    }
  }
}
