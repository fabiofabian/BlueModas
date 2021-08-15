import { ProductVariantViewModel } from "./productVariantViewModel";

export class ProductViewModel {
    id: string;
    name: string;
    description: string;

    variants: ProductVariantViewModel[]
}