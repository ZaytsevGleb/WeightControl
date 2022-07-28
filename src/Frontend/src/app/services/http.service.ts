import { startWith, map, tap, catchError, Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http'; 
import { Injectable, OnInit } from '@angular/core';
import { Product } from '../models/product';

@Injectable({
    providedIn: 'root'
})
export class HttpService implements OnInit {

private readonly http: HttpClient;

    ngOnInit(): void {
        
    }



constructor(http:HttpClient){
    this.http = http;
}

    getProducts(): Observable<Product[]> {
        return this.http.get('https://localhost:49714/api/products').pipe(map((data: any) => {
            let productList = data;
            return productList.map(function (product: any): Product {
                return new product(product.id, product.name, product.calories, product.type, product.unit);
            });
        }));
    }
}