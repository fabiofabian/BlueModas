import { Component, OnInit } from '@angular/core';
import { CartService } from '../services/cart.service';
import { ProductService } from '../services/product.service';
import { OrderProductViewModel } from '../viewModels/orderProductViewModel';
import { CartProductViewModel } from '../viewModels/cartProductViewModel';
import { ProductViewModel } from '../viewModels/productViewModel';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
  cart: OrderProductViewModel[];
  products: ProductViewModel[];
  cartProducts: CartProductViewModel[] = []; 

  constructor(private productService: ProductService, private cartService: CartService){

  }

  ngOnInit(){
    this.loadCart();
    this.loadProducts();
  }

  changeQuantity(productId: string, quantity: number){
    if(this.cart.find(x => x.productId == productId).quantity == 1 && quantity < 0){
      if(confirm("O produto será removido do carrinho.")){
        this.cartService.remove(productId);
      }
    }
    else {
      this.cartService.changeQuantity(productId, quantity);
    }
  }

  getSubtotal(cartItem: CartProductViewModel){
    return Math.round(cartItem.quantity * cartItem.price * 100) / 100
  }

  getTotal(){
    let total = 0;
    this.cartProducts.forEach(element => {
      total += this.getSubtotal(element);
    });
    return Math.round(total * 100) / 100;
  }

  private loadProducts(){
    this.productService.get().subscribe(
      res => {
        this.products = res.data;
        this.setCartProducts();
        this.setCartWatcher();
      },
      err => console.log(err)
    );
  }

  private loadCart(){
    this.cart = this.cartService.get();
  }

  private setCartProducts(){
    this.cartProducts = [];
    this.cart.forEach(cartItem => {
      this.cartProducts = this.cartProducts.concat({
        name: this.products.find(x => x.id == cartItem.productId).name,
        imagePath: this.products.find(x => x.id == cartItem.productId).imagePath,
        price: this.products.find(x => x.id == cartItem.productId).price,
        quantity: cartItem.quantity,
        productId: cartItem.productId
      } as CartProductViewModel)
    });
  }

  private setCartWatcher(){
    this.cartService.watchStorage().subscribe(_ => {
      this.loadCart();
      this.setCartProducts();
    });
  }
}
