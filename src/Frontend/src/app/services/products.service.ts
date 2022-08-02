import { HttpClient } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';
import { startWith, map,tap, catchError, Observable } from 'rxjs';
import { Meal } from '../models/meal';
import { MealProduct } from '../models/mealproduct';
import { Product } from '../models/product';
import { HttpService } from './http.service';
import { ProductDto } from './models/product.dto';


@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  product!: Product;
  private  products: Array<Product> = [];


private readonly http : HttpClient;

  constructor(http: HttpClient) { 
    this.http = http;
    
  }

  filterProduct: Array<Product> = [];
  mealProduct: Array<MealProduct> = [];

  // Search(searchWord: string): Array<Product> {
  //   for (let product of this.products) {
  //     if ((product.name.toLowerCase().startsWith(searchWord.toLowerCase()) && searchWord != '')) {
  //       this.filterProduct.push(product);
  //     }
  //   }
  //   return this.filterProduct;
  // }

  getProducts(search: string):Observable<Product[]> {
    return this.http
      .get<ProductDto[]>(`https://localhost:49714/api/products?name=${search}`)
      .pipe(map(response => response.map(dto => new Product(dto.id, dto.name, dto.calories, dto.type, dto.unit))));
  }

  getProduct(id: number): Product {
    return this.products.find(p => p.id == id)!;
    // this.http.get<any>('https://localhost:49714/api/products/1').subscribe(data => {
    //   this.product = {id: data.id, name: data.name, calories: data.calories, type: data.type, unit: data.unit}
    // })
    // return this.product;
  }

}



