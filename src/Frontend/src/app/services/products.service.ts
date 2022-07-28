import { HttpClient } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';
import { startWith, map,tap, catchError, Observable } from 'rxjs';
import { Meal } from '../models/meal';
import { MealProduct } from '../models/mealproduct';
import { Product } from '../models/product';
import { HttpService } from './http.service';

@Injectable({
  providedIn: 'root'
})
export class ProductsService implements OnInit {

product!: Product;
  private  products: Array<Product> = [];

  ngOnInit() {
   this.httpService.getProducts().subscribe((data: Array<Product>) => this.products = data);
  }

private readonly http : HttpClient;
private readonly httpService : HttpService;

  constructor(http: HttpClient, httpService: HttpService) { 
    this.http = http;
    this.httpService = httpService;
    
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
    // this.http.get<any>('https://localhost:49714/api/products/1').subscribe(data => {
    //   this.product = {id: data.id, name: data.name, calories: data.calories, type: data.type, unit: data.unit}
    // })
    // return this.product;
  }

}



