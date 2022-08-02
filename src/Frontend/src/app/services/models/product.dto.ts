export interface ProductDto {
    id: number;
    name: string;
    calories: number;
    type: TypeofFood;
    unit: unitType; // enum измерение
}

enum TypeofFood {
    meat,
    drink,
    cereal,
    vegetable,
    fruit,
    confection,
    bake
}

enum unitType {
    Milliliters,
    Gram,
    Pieces

}