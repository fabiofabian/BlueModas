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
  productsRows: ProductViewModel[][] = [];
  productsPerRow: number = 4;

  constructor(private productService: ProductService, private cartService: CartService) { }

  ngOnInit() {

    this.productService.get().subscribe(
      res => {
        this.products = res.data;
        this.createProductRows();
        console.log(res.data);
      },
      err => console.log(err)
    );

  }

  createProductRows() {
    let iterations = Math.ceil(this.products.length / this.productsPerRow);    

    for(let i = 0; i < iterations; i++){
      let row = this.products.splice(0, this.productsPerRow)      
      this.productsRows[i] = row;      
    }
  }

  addToCart(productId: string){
    this.cartService.add(productId);
    console.log(this.cartService.get());
  }

}
