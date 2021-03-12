import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Customer } from 'src/app/core/models/customer';
import { Invoice } from 'src/app/core/models/invoice';
import { DataService } from 'src/app/core/services/data.service';
import { environment } from 'src/environments/environment';
import { CustomerCreate } from 'src/app/core/models/customerCreate';

@Component({
  selector: 'app-add-edit-delete',
  templateUrl: './add-edit-delete.component.html',
  styleUrls: ['./add-edit-delete.component.scss']
})
export class AddEditDeleteComponent implements OnInit {
  id: string = '';
  isAddMode: boolean = false;
  defaultProfilePicture = environment.defaultProfilePicture;
  invoices!: Invoice[]
  customer: Customer = {
    id: '',
    firstname: '',
    lastname: '',
    email: '',
    imgurl: ''
  }

  constructor(
    private route: ActivatedRoute,
    private dataService: DataService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];
    this.isAddMode = !this.id;

    if (!this.isAddMode) {
      this.dataService.getCustomerDetails(this.id)
        .subscribe(x => {
          this.customer = x.customer;
          this.invoices = x.invoices as Invoice[]
        });
    }
  }

  //Creating customer
  createNewCustomer() {
    this.dataService.createCustomer(this.customer as CustomerCreate)
      .subscribe(x => {
        alert("user created...");
        this.router.navigate(['customer', x.id]);
      });
  }

  //Update
  updateCustomer() {
    this.dataService.updateCustomer(this.customer)
      .subscribe(x => {
        this.customer = x as Customer;
        alert("save was successful");
      });
  }

  deleteCustomer() {
    this.dataService.deleteCustomer(this.customer.id)
      .subscribe(x => {
        alert("user deleted! You are gonna redirected to customer lists");
        this.router.navigate(["customer"]);
      });
  }

  addInvoice() {
    this.router.navigate(["invoice/addInvoice"])
  }

  //Delete invoice 
  deleteInvoice(id: string) {
    var delBtn = confirm(" Do you want to delete the invoide?");
    if (delBtn === true) {
      console.log("Deleting invoide: " + this.invoices.filter(x => x.id === id))
      this.dataService.deleteInvoice(id)
        .subscribe(x => {
          var index = this.invoices.findIndex(x => x.id === id);
          this.invoices.splice(index, 1);
        });
    }
  }


}
