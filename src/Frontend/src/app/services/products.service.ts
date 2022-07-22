import { Injectable } from '@angular/core';
import { startWith } from 'rxjs';
import { Meal } from '../models/meal';
import { MealProduct } from '../models/mealproduct';
import { Product } from '../models/product';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  private readonly products: Array<Product> = [
    { id: 1, name: 'Tea', calories: 20, type: 0, unit:0 },
    { id: 2, name: 'Cake', calories: 269, type: 5, unit: 1 },
    { id: 3, name: 'Coffe', calories: 100, type: 1, unit: 0 },
    { id: 4, name: 'Bread', calories: 265, type: 6, unit: 1 },
    { id: 5, name: 'Egg', calories: 157, type: 0, unit: 2 },
    { id: 6, name: 'Potato', calories: 76, type: 3, unit: 1 },
    { id: 7, name: 'Bacon', calories: 500, type: 0, unit: 1 },
    { id: 8, name: 'Apple', calories: 47, type: 4, unit: 2 },
    { id: 9, name: 'Banana', calories: 96, type: 4, unit: 2 },
    { id: 10, name: 'Fish', calories: 112, type: 0, unit: 1 },
  ];

  constructor() { 
    
  }
  filterProduct: Array<Product> = [];
  mealProduct: Array<MealProduct> = [];

  Search(searchWord: string): Array<Product> {
    for (let product of this.products) {
      if ((product.name.toLowerCase().startsWith(searchWord.toLowerCase()) && searchWord != '')) {
        this.filterProduct.push(product);
      }
    }
    return this.filterProduct;
  }

  getProducts(search: string): Array<Product> {
    this.filterProduct = [];
    return this.Search(search);
  }

  getProduct(id: number): Product {
    return this.products.find(p => p.id == id)!;
  }

}



