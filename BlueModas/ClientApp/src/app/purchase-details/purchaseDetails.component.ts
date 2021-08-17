import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { OrderService } from '../services/order.service';
import { OrderProductViewModel } from '../viewModels/orderProductViewModel';
import { OrderViewModel } from '../viewModels/OrderViewModel';

@Component({
  selector: 'app-purchase-details',
  templateUrl: './purchaseDetails.component.html',
  styleUrls: ['./purchaseDetails.component.css']
})
export class PurchaseDetailsComponent implements OnInit {
  idOrder: string;
  order: OrderViewModel = new OrderViewModel();
  phoneMask: string;
  phoneMask10: string = '(00) 0000-0000';
  phoneMask11: string = '(00) 0 0000-0000';

  constructor(private orderService: OrderService, private route: ActivatedRoute){}

  ngOnInit(){
    this.idOrder = this.route.snapshot.queryParams.id;
    if(this.idOrder){
      this.orderService.get(this.idOrder).subscribe(
        res => {
          if(res.success){
            this.order = res.data;
            this.phoneMask = this.order.phone.length === 11 ? this.phoneMask11 : this.phoneMask10
          } else {
            console.log("Erro");
          }
        },
        err => console.log(err)
      )
    }
  }

  getSubtotal(orderProduct: OrderProductViewModel){
    return Math.round(orderProduct.quantity * orderProduct.product.price * 100) / 100
  }

  getTotal(){
    let total = 0;
    if(this.order.orderProducts){
      this.order.orderProducts.forEach(element => {
        total += this.getSubtotal(element);
      });
    }
    return Math.round(total * 100) / 100;
  }




  
}

