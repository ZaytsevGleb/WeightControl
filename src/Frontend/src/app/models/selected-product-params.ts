import {TypeOfMeal} from "./meal";
import {Product} from "./product";

export interface SelectedProductParams {
  product: Product;
  typeofMeal: TypeOfMeal;
  amount: number;
}
