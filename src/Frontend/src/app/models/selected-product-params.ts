import { TypeOfMeal } from "./meal";

export interface SelectedProductParams{
    productId: number;
    typeofMeal: TypeOfMeal;
    amount: number;
}