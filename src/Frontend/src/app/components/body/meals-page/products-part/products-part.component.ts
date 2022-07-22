import { Component, ComponentRef, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { ProductsService } from 'src/app/services/products.service';
import { Product } from 'src/app/models/product';
import { AmountDialogComponent } from '../amount-dialog/amount-dialog.component';
import { ViewContainerRef } from '@angular/core';
import { MealsController } from 'src/app/services/meals.controller';
import { TypeOfMeal } from 'src/app/models/meal';
import { Subject, Subscription, takeUntil } from 'rxjs';

@Component({
  selector: 'app-products-part',
  templateUrl: './products-part.component.html',
  styleUrls: ['./products-part.component.scss']
})
export class ProductsPartComponent implements OnInit, OnDestroy {
  amount!: number;
  private destroy$ = new Subject();
  private targetTypeOfMeal!: TypeOfMeal;
  searchInput!: string;
  isFocused: boolean = false;
  @ViewChild('amount', { read: ViewContainerRef })
  private viewRef?: ViewContainerRef;
  private componentRef?: ComponentRef<AmountDialogComponent>;
  products: Array<Product> = [];

  private readonly productService: ProductsService;
  private readonly mealsController: MealsController;
 
  constructor(productService: ProductsService, mealsController: MealsController) {
    this.productService = productService;
    this.mealsController = mealsController;
  }

  ngOnInit(): void {
    this.mealsController.isFocused$.pipe(takeUntil(this.destroy$)).subscribe(type => this.setFocus(type));
  }

  ngOnDestroy() {
    this.destroy$.next(true);
    this.destroy$.complete();
    this.componentRef?.destroy();
    this.viewRef?.detach();
  }

  public getProducts() {
    this.products = this.productService.getProducts(this.searchInput);
  }

  public showAmountDialog(id: number) {
    this.viewRef?.clear();
    this.componentRef = this.viewRef?.createComponent(AmountDialogComponent);
    this.componentRef?.instance.close.subscribe(() => {
      this.viewRef?.clear();
    });

    this.componentRef?.instance.accept.subscribe(() => {
      this.viewRef?.clear();
      this.amount = this.componentRef?.instance.amount!;
      this.mealsController.addProduct(id, this.targetTypeOfMeal, this.amount);
    })
  }

  private setFocus(type: TypeOfMeal) {
    this.targetTypeOfMeal = type;
    this.isFocused = true;
  }
  //Всё что идёт ниже в идеале переделать нормально
  showProductUnit(unit: number): string{
    switch (unit) {
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
  setAmount(unit: number): number{
    switch (unit) {
      case 0:
        return 100
        break;
      case 1:
        return 100
        break;
      case 2:
        return 1
        break;
      default:
        return 0;
        break;
    }
  }
}
