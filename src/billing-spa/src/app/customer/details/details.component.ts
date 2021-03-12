import { HttpResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { of } from 'rxjs';
import { switchMap } from 'rxjs/operators';
import { Customer } from 'src/app/core/models/customer';
import { CustomerDetails } from 'src/app/core/models/customerDetails';
import { Invoice } from 'src/app/core/models/invoice';
import { DataService } from 'src/app/core/services/data.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.scss']
})
export class DetailsComponent implements OnInit {
  customerDetails!: CustomerDetails;
  defaultProfilePicture : string = environment.defaultProfilePicture;
  exists: boolean = false;

  constructor(
    private activatedRoute: ActivatedRoute,
    private dataService: DataService,    
     private router: Router) { }

  ngOnInit(): void {    
    this.activatedRoute.paramMap
      .pipe(
        switchMap(params => {
          let id = params.get("id");
          console.log(id);
          return this.dataService.getCustomerDetails(id as string);
        }
        )
      )
      .subscribe(x => {
        console.log("asdasdasd:", x);
        if (x === null) {
          this.exists = false;
        }
        else {
          this.exists = true;
        }
        this.customerDetails = x as CustomerDetails;
      })
  }

  updateCustomer(customer: Customer) {
    this.dataService.updateCustomer(customer)
      .subscribe(x => {
        this.customerDetails = x as CustomerDetails;
        alert("save was successful");
      });
  }

  deleteCustomer(id: string) {
    this.dataService.deleteCustomer(id)
      .subscribe(x => {
        alert("user deleted! You are gonna redirected to customer lists");
        this.router.navigate(["customer"]);
      });
  }

  deleteInvoice(id: string): void {
    console.log("delete invoice: " + id);

    var delBtn = confirm(" Do you want to delete ?");
    if (delBtn === true) {
      this.dataService.deleteInvoice(id)
        .subscribe();
      if (this.customerDetails.invoices) {

        var index = this.customerDetails.invoices.findIndex(x => x.id === id);
        this.customerDetails.invoices.splice(index, 1);
      }

    }
  }
}