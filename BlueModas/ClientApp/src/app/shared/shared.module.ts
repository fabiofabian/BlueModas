import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductListComponent } from './product/list/product-list.component';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule  } from '@angular/material/icon';
import { MatButtonToggleModule } from '@angular/material/button-toggle';

@NgModule({
  declarations: [ProductListComponent],
  imports: [
    CommonModule,
    MatButtonModule,
    MatIconModule,
    MatButtonToggleModule 
  ],
  exports: [
    ProductListComponent,
    MatButtonModule,
    MatIconModule,
    MatButtonToggleModule 
  ]
})
export class SharedModule { }
