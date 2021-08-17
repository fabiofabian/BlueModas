import { ProductViewModel } from "./productViewModel";

export class OrderProductViewModel {
    productId: string;
    quantity: number;
    product?: ProductViewModel;
}