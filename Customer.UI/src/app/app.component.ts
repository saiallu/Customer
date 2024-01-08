import { Component, ViewChild } from '@angular/core';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { SafeResourceUrl } from '@angular/platform-browser';
import { CustomerService } from './services/customer.service';
import { MatPaginator } from '@angular/material/paginator';
import { Customer } from './models/Customer';
import { MatSort } from '@angular/material/sort';
import { MatDialog } from '@angular/material/dialog';
import { CustomerComponent } from './customer/customer.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Customer.UI';
  CustomerData: any;
  displayedColumns: string[] = ['id', 'firstName', 'lastName', 'email', 'statusDescription', 'action' ];
  dataSource: any;
  
  @ViewChild(MatPaginator) paginator !:MatPaginator;
  @ViewChild(MatSort) sorting !:MatSort;

  constructor(private customerService: CustomerService, private matDialog: MatDialog) { }

  ngOnInit(): void {
    this.customerService.getCustomers().subscribe(data => {
      this.CustomerData = data
      this.dataSource = new MatTableDataSource<Customer>(this.CustomerData);
      this.dataSource.paginator = this.paginator; 
      this.dataSource.sort = this.sorting;
    });
  }

  getRow(row: any) {
    console.log(row);
  }

  createCustomer() {
    this.matDialog.open(CustomerComponent,{width: '60%',height: '500px'});
  }
  editRow(row: any) {
    this.matDialog.open(CustomerComponent,{width: '60%',height: '500px', data: row});
  }
}