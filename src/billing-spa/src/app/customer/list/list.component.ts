import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { Customer } from '../../core/models/customer';
import { DataService } from '../../core/services/data.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {

  searchText: string = '';
  customers: Customer[] = [];

  constructor(private dataService: DataService, private router: Router) { }

  ngOnInit(): void {
    this.dataService
      .getCustomers()
      .subscribe(result => this.customers = result);
  }

  showDetails(id: string): void {
    this.router.navigate(['customer', id]);
  }

  addCustomer(): void {
    this.router.navigate(['customer/add-customer']);
  }

  
  search(): void {
      console.log("search for '"+this.searchText+"'");
      this.dataService
        .searchCustomers(this.searchText)
        .subscribe(result => this.customers = result);
    

  }
}
