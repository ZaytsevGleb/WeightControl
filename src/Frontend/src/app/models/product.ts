export class Product {
    id: number;
    name: string;
    calories: number;
    type: TypeofFood;
    unit: unitType; 
    constructor(id: number, name: string, calories:number, type:number, unit:number){
        this.id = id;
        this.name = name;
        this.calories = calories;
        this.type = type;
        this.unit = unit;
    }
}

enum TypeofFood {
    Meat,
    Drink,
    Cereal,
    Vegetable,
    Fruit,
    Confection,
    Bake,
    Garnish, 
    Berrie, 
}

enum unitType {
    Milliliters,
    Gram,
    Pieces
}