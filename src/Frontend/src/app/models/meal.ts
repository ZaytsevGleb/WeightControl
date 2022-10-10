import {MealProduct} from "./mealproduct";

export interface Meal {
  id: number;
  type: TypeOfMeal;
  date: Date;
  products: Array<MealProduct>;
}

export enum TypeOfMeal {
  breakfast,
  lunch,
  dinner,
  snack
}
