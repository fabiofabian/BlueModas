import { Component, OnInit } from '@angular/core';
import { CartService } from 'src/app/services/cart.service';
import { ProductService } from 'src/app/services/product.service';
import { ProductViewModel } from 'src/app/viewModels/productViewModel';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  products: ProductViewModel[];

  constructor(private productService: ProductService, private cartService: CartService) { }

  ngOnInit() {

    this.productService.get().subscribe(
      res => {
        this.products = res.data;
        console.log(res.data);
      },
      err => console.log(err)
    );

  }

  addToCart(productId: string){
    this.cartService.add(productId);
    console.log(this.cartService.get());
  }

}
