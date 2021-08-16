import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { OrderViewModel } from '../viewModels/OrderViewModel';

interface ApiResponse<T> {
  data: T[];
  success: boolean;
}

interface ApiInsertResponse {
  data: { id: string };
  success: boolean;
}

interface ObjectResponse<T>{
  data: T;
  success: boolean;
}

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  constructor(private http: HttpClient) { }

  create(order: OrderViewModel) {
    return this.http.post(`api/Order`, order).pipe(map((response: ApiInsertResponse) =>
      ({
        data: response.data, success: response.success
      })
    ));
  }

  get(orderId: string){
    return this.http.get(`api/Order?id=${orderId}`).pipe(map((response: ObjectResponse<OrderViewModel>) => 
      ({
        data: response.data, success: response.success
      })
    ));
  }
}
