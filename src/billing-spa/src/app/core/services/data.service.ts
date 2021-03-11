import { Injectable } from '@angular/core';

import { EMPTY, Observable, of, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Customer } from '../models/customer';
import { InvoiceWithCustomer } from '../models/invoiceListItem';
import { CustomerDetails } from '../models/customerDetails';
import { InvoiceCreate } from '../models/invoiceCreate';
import { Invoice } from '../models/invoice';
import { CustomerCreate } from '../models/customerCreate';
import { environment } from '../../../environments/environment';


@Injectable({
  providedIn: 'root'
})
export class DataService {
  
  endpoint : string;
  
  constructor(private httpClient: HttpClient) { 
    this.endpoint = environment.baseUrl;
  }

  httpHeader = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  } 

  
  // TODO: Get the customer data from the billing-api
  
  
  getCustomers(): Observable<Customer[]> {
    console.log("asd>"+this.endpoint);
    console.log("asd2>"+environment.baseUrl);
    return this.httpClient.get<Customer[]>(this.endpoint + 'api/customer/getAll')
    .pipe(
      retry(1),
      catchError(this.processError)
    )
  }

  updateCustomer(customer: Customer) {
    return this.httpClient.put(this.endpoint + 'api/customer/updateCustomer',customer)
    .pipe(
      retry(1),
      catchError(this.processError)
    )
  }

  deleteCustomer(id: string) : Observable<{}>{
    console.log("deleteCustomer is called with "+id+" id")
    return this.httpClient.delete(this.endpoint + 'api/customer/deleteCustomer?id='+id ) //{observe: 'response'}
    .pipe(
      retry(1),
      catchError(this.processError)
    )
  }

  searchCustomers(crit: string): Observable<Customer[]> {
    return this.httpClient.get<Customer[]>(this.endpoint + 'api/customer/search?crit='+crit)
    .pipe(
      retry(1),
      catchError(this.processError)
      )
    }
    
    getInvoices() {
      return this.httpClient.get<InvoiceWithCustomer[]>(this.endpoint + 'api/invoice/getAll')
      .pipe(
        retry(1),
        catchError(this.processError)
      )
    }

    createNewInvoice(invoice: InvoiceCreate) {
      return this.httpClient.post<InvoiceWithCustomer>(this.endpoint + 'api/invoice/AddInvoice', invoice)
      .pipe(
        retry(1),
        catchError(this.processError)
      )
    }

  deleteInvoice(id: string) : Observable<{}> {
    console.log("deleteInvoice is called with "+id+" id")
    return this.httpClient.delete(this.endpoint + 'api/invoice/DeleteInvoice?id='+id)
    .pipe(
      retry(1),
      catchError(this.processError)
    )
  }

  // TODO: Get the customer data from the billing-api
  getCustomerDetails(id: string): Observable<CustomerDetails> {
    return this.httpClient.get<CustomerDetails>(this.endpoint + 'api/customer/getCustomerDetails?id='+id)
    .pipe(
      retry(1),
      catchError(this.processError)
    )
    // const customer = Customers.find(x => x.id === id);
    // if (customer)
    //   return of(customer);

    // return EMPTY;
  }

  createCustomer(customer:CustomerCreate) : Observable<Customer> {
    return this.httpClient.post<Customer>(this.endpoint + 'api/customer/addcustomer', customer )
    .pipe(
      retry(1),
      catchError(this.processError)
    )
  }


  // TODO: We should be able to see a list of invoices for each customer
  // TODO: We should be able to create new customers and invoices
  // TODO: We should be able to delete invoices and customers
  // BONUS: We should be able to search for customers by name or email
  processError(err : any) {
    let message = '';
    if(err.error instanceof ErrorEvent) {
     message = err.error.message;
    } else {
     message = `Error Code: ${err.status}\nMessage: ${err.message}`;
    }
    console.log(message);
    alert("whoops! request failed: "+ err);
    return throwError(message);
 }
}

const Customers: Customer[] = [
  { id: "0001", firstname: "Tony", lastname: "Stark", email: "t.start@bloxxon.co", },
  { id: "0002", firstname: "Peter", lastname: "Parker", email: "p.parker@bloxxon.co", },
  { id: "0003", firstname: "Bruce", lastname: "Banner", email: "b.banner@bloxxon.co", },
];
