import { Component, OnInit } from '@angular/core';
import { CartService } from '../services/cart.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {
  isExpanded = false;
  cartItens: number = 0;

  constructor(private cartService: CartService){}

  ngOnInit(): void {
    this.configureCartCount();
  }
  
  configureCartCount() {
    this.cartItens = this.cartService.get().length;

    this.cartService.watchStorage().subscribe((data: string) => {
      this.cartItens = this.cartService.get().length;
    });
    
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
