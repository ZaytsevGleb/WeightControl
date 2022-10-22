import {Injectable} from '@angular/core';
import {map, Observable} from 'rxjs';
import {Product} from '../models/product';
import {ApiClient} from '../clients/api.client';

@Injectable({providedIn: 'root'})
export class ProductsService {

  private readonly apiClient: ApiClient;

  constructor(apiClient: ApiClient) {
    this.apiClient = apiClient;
  }

  public searchProducts(name: string): Observable<Product[]> {
    return this.apiClient
      .find(name)
      .pipe(map(response => response.map(dto => new Product(dto.id!, dto.name!, dto.calories!, dto.type!, dto.unit!))));
  }
}
