import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Customer } from '../models/Customer';
import { enableDebugTools } from '@angular/platform-browser';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  constructor(private http: HttpClient) { }

  public getCustomers(): Observable<Customer> {
    return this.http.get<Customer>("https://localhost:7208/Customer/GetCustomers");
  }

  public getEmptyCustomer(): Observable<Customer> {
    return this.http.get<Customer>("https://localhost:7208/Customer/GetEmptyCustomer");
  }

  public createCustomer(customer: Customer) {    
    return this.http.post("https://localhost:7208/Customer/CreateCustomer", customer).subscribe();
  }

  public updateCustomer(customer: Customer) {    
    return this.http.post("https://localhost:7208/Customer/UpdateCustomer", customer).subscribe();
  }
}