import { ProductVariantImageViewModel } from "./productVariantImageViewModel";

export class ProductVariantViewModel {
    id: string;
    productId: string;
    price: number;
    quantity: number;
    name: string;
    description: string;

    images: ProductVariantImageViewModel[]
}