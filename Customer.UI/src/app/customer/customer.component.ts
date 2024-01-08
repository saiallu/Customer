import { Component, OnInit, Inject } from '@angular/core';
import { MaterialModule } from 'src/material.module';
import { CustomerService } from '../services/customer.service';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Customer } from '../models/Customer';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.scss']
})
export class CustomerComponent implements OnInit {
  public customer: any;
  constructor(@Inject(MAT_DIALOG_DATA) public data: any, private customerService: CustomerService) { }

  ngOnInit(): void {
    debugger;
    if (this.data == null) {      
      this.customer = this.customerService.getEmptyCustomer();
    }
    else {
      this.customer = this.data;
    }

  }

  saveCustomer() {
    debugger;
    if (this.customer.id == undefined || this.customer.id == null || this.customer.id == '') {
      this.customer.createdBy = 'sai.allu';
      this.customerService.createCustomer(this.customer);
    }
    else {
      this.customer.updatedBy = 'sai.allu.update';
      this.customerService.updateCustomer(this.customer);
    }

    
  }

}
