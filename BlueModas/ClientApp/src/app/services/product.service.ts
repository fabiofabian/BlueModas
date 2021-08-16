import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ProductViewModel } from '../viewModels/productViewModel';
import { map } from "rxjs/operators";

interface ApiResponse<T> {
  data: T[];
  success: boolean;
}

interface ObjectResponse<T>{
  data: T;
  success: boolean;
}

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  
  constructor(private http: HttpClient) { }
  
  public get() {
    return this.http.get(`api/Product`).pipe(map((response: ApiResponse<ProductViewModel>) =>
      ({
        data: response.data, success: response.success
      })
    ));
    
  }
  
}
