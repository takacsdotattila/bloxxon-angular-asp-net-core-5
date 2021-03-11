import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { pipe } from 'rxjs';
import { CustomerCreate } from 'src/app/core/models/customerCreate';
import { DataService } from 'src/app/core/services/data.service';

@Component({
  selector: 'app-add-customer',
  templateUrl: './add-customer.component.html',
  styleUrls: ['./add-customer.component.scss']
})
export class AddCustomerComponent implements OnInit {
  customer : CustomerCreate = {
    firstname : '',
    lastname : '',
    email : '',
    imgurl : ''
  };

  constructor(private dataService : DataService, private router: Router) { }

  ngOnInit(): void {
  }

  createNewCustomer(){
    this.dataService.createCustomer(this.customer)
    .subscribe(x=>{
      alert("user created...");
      this.router.navigate(['customer', x.id]);
    });
  }
}
