import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CartService } from '../services/cart.service';
import { OrderService } from '../services/order.service';
import { OrderViewModel } from '../viewModels/OrderViewModel';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent implements OnInit {
  checkoutForm: FormGroup;

  constructor(private fb: FormBuilder, private orderService: OrderService, private cartService: CartService, private router: Router){}

  ngOnInit(){
    this.initializeForm();
  }

  onSubmit(){
    this.checkoutForm.markAllAsTouched();
    if(this.checkoutForm.valid){
      let order = {
        name: this.checkoutForm.controls.name.value,
        email: this.checkoutForm.controls.email.value,
        phone: this.checkoutForm.controls.phone.value,
        orderProducts: this.cartService.get()
      } as OrderViewModel;
      this.orderService.create(order).subscribe(
        res => {
          if(res.success){
            this.cartService.clear();
            this.router.navigate(['detalhes-compra'], { queryParams: res.data });
          }
        },
        err => console.log(err)
      );
    }
  }

  private initializeForm() {
    this.checkoutForm = this.fb.group({
      name: ['', Validators.required],
      email: ['', [Validators.email, Validators.required]],
      phone: ['', [Validators.required]]
    });  
  }

}

