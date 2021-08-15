import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
})
export class CheckoutComponent implements OnInit {
  checkoutForm: FormGroup;

  constructor(private fb: FormBuilder){}

  ngOnInit(){
    this.initializeForm();
  }

  onSubmit(){
    this.checkoutForm.markAllAsTouched();
    console.log(this.checkoutForm.controls.phone)
        if(this.checkoutForm.valid){
      console.log('valido')
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

