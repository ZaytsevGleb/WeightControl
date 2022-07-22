import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { TypeOfMeal } from '../models/meal';
import { SelectedProductParams } from '../models/selected-product-params';
@Injectable({
    providedIn: 'root'
})

export class MealsController {

    public isFocused$ = new Subject<TypeOfMeal>();
    public porductSelected$ = new Subject<SelectedProductParams>();

    public setFocus(type: TypeOfMeal) {
        this.isFocused$.next(type);
    }

    public addProduct(productId: number, typeOfMeal: TypeOfMeal, amount: number) {
        this.porductSelected$.next({ productId: productId, typeofMeal: typeOfMeal, amount: amount });
    }
}