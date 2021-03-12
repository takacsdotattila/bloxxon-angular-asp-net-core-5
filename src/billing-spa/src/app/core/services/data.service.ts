import { Injectable } from '@angular/core';

import { Observable, of, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Customer } from '../models/customer';
import { InvoiceWithCustomer } from '../models/invoiceListItem';
import { CustomerDetails } from '../models/customerDetails';
import { InvoiceCreate } from '../models/invoiceCreate';
import { CustomerCreate } from '../models/customerCreate';
import { environment } from '../../../environments/environment';


@Injectable({
  providedIn: 'root'
})
export class DataService {

  endpoint: string;

  constructor(private httpClient: HttpClient) {
    this.endpoint = environment.baseUrl;
  }

  httpHeader = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }

  //Create customer
  createCustomer(customer: CustomerCreate): Observable<Customer> {
    console.log("[dataService] Creating customer: " + customer);
    return this.httpClient.post<Customer>(this.endpoint + 'api/customer/addcustomer', customer)
      .pipe(
        retry(1),
        catchError(this.processError)
      )
  }

  //Read customer

  getCustomers(): Observable<Customer[]> {
    console.log("[dataService] Get customer list.");
    return this.httpClient.get<Customer[]>(this.endpoint + 'api/customer/getAll')
      .pipe(
        retry(1),
        catchError(this.processError)
      )
  }

  getCustomerDetails(id: string): Observable<CustomerDetails> {
    console.log("[dataService] Getting customer details for customer with id: " + id);
    return this.httpClient.get<CustomerDetails>(this.endpoint + 'api/customer/getCustomerDetails?id=' + id)
      .pipe(
        retry(1),
        catchError(this.processError)
      )
  }

  searchCustomers(crit: string): Observable<Customer[]> {
    console.log("[dataService] Search: " + crit);
    return this.httpClient.get<Customer[]>(this.endpoint + 'api/customer/search?crit=' + crit)
      .pipe(
        retry(1),
        catchError(this.processError)
      )
  }

  //Update customer
  updateCustomer(customer: Customer) {
    console.log("[dataService] Update customer: " + customer);
    return this.httpClient.put(this.endpoint + 'api/customer/updateCustomer', customer)
      .pipe(
        retry(1),
        catchError(this.processError)
      )
  }

  //Delete customer
  deleteCustomer(id: string): Observable<{}> {
    console.log("Delete customer with id " + id);
    return this.httpClient.delete(this.endpoint + 'api/customer/deleteCustomer?id=' + id)
      .pipe(
        retry(1),
        catchError(this.processError)
      )
  }


  //Create invoice
  createNewInvoice(invoice: InvoiceCreate) {
    console.log("[dataService] Create new invoice: " + invoice);
    return this.httpClient.post<InvoiceWithCustomer>(this.endpoint + 'api/invoice/AddInvoice', invoice)
      .pipe(
        retry(1),
        catchError(this.processError)
      )
  }

  //Read invoice
  getInvoices() {
    console.log("[dataService] Get all invoices.");
    return this.httpClient.get<InvoiceWithCustomer[]>(this.endpoint + 'api/invoice/getAll')
      .pipe(
        retry(1),
        catchError(this.processError)
      )
  }

  //(Update invoice) - no update

  // Delete invoice
  deleteInvoice(id: string): Observable<{}> {
    console.log("[dataService] Deleting invoice with id :" + id);
    return this.httpClient.delete(this.endpoint + 'api/invoice/DeleteInvoice?id=' + id)
      .pipe(
        retry(1),
        catchError(this.processError)
      )
  }

  processError(err: any) {
    let message = '';
    if (err.error instanceof ErrorEvent) {
      message = err.error.message;
    } else {
      message = `Error Code: ${err.status}\nMessage: ${err.message}`;
    }
    console.log(message);
    alert("Whoops! The request failed...");
    return throwError(message);
  }
}