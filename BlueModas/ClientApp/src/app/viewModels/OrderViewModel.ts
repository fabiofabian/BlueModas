import { OrderProductViewModel } from "./orderProductViewModel";

export class OrderViewModel{
    id: string;
    number: number;
    name: string;
    email: string;
    phone: string;
    orderProducts: OrderProductViewModel[];
}