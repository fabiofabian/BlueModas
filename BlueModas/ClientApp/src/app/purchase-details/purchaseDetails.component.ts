import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { OrderService } from '../services/order.service';
import { OrderViewModel } from '../viewModels/OrderViewModel';

@Component({
  selector: 'app-purchase-details',
  templateUrl: './purchaseDetails.component.html',
})
export class PurchaseDetailsComponent implements OnInit {
  idOrder: string;
  order: OrderViewModel;

  constructor(private orderService: OrderService, private route: ActivatedRoute){}

  ngOnInit(){
    this.idOrder = this.route.snapshot.queryParams.id;
    if(this.idOrder){
      this.orderService.get(this.idOrder).subscribe(
        res => {
          if(res.success){
            this.order = res.data;
            console.log(this.order);
          } else {
            console.log("Erro");
          }
        },
        err => console.log(err)
      )
    }
  }




  
}

