import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { CartItemViewModel } from '../viewModels/cartItemViewModel';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  private storageSub = new Subject<String>()

  constructor() { }

  watchStorage(): Observable<any> {
    return this.storageSub.asObservable();
  }

  get(): CartItemViewModel[]{
    this.verifyAndConfigure();
    return JSON.parse(localStorage.getItem('cart')) as CartItemViewModel[];
  }

  set(cart: CartItemViewModel[]) {
    localStorage.setItem('cart', JSON.stringify(cart));
    this.storageSub.next('changed');
  }

  add(productId: string){
    let cart = this.get();

    let index = cart.findIndex(x => x.productId == productId)
    if(index != -1){
      cart[index].quantity += 1;
    } else {
      cart = cart.concat({
        productId: productId,
        quantity: 1
      });
    }
    this.set(cart);
  }

  remove(productId: string){
    let cart = this.get();    
    let index = cart.findIndex(x => x.productId == productId);
    if(index != -1){
      cart.splice(index, 1);
    }
    this.set(cart);
  } 

  clear(){
    localStorage.setItem('cart', '[]');
    this.storageSub.next('cleared');
  }

  changeQuantity(productId: string, quantity: number){
    let cart = this.get();    
    let index = cart.findIndex(x => x.productId == productId);
    if(index != -1){
      if(quantity > 0 || quantity < 0 && cart[index].quantity > 1 ){
        cart[index].quantity += quantity;
      }
    }
    this.set(cart);
  }

  private verifyAndConfigure(){
    let cart = localStorage.getItem('cart');
    if(!cart){
      localStorage.setItem('cart', '[]');
    }
  }
}
