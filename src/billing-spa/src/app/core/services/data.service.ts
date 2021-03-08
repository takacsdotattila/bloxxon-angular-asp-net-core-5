import { Injectable } from '@angular/core';

import { EMPTY, Observable, of, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Customer } from '../models/customer';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  endpoint = 'http://localhost:5000/';
  
  constructor(private httpClient: HttpClient) { }

  httpHeader = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  } 

  
  // TODO: Get the customer data from the billing-api
  

  getCustomers(): Observable<Customer[]> {
    return this.httpClient.get<Customer[]>(this.endpoint + 'api/customer/getAll')
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

  // TODO: Get the customer data from the billing-api
  getCustomerDetails(id: string): Observable<Customer> {
    return this.httpClient.get<Customer>(this.endpoint + 'api/customer/search?id='+id)
    .pipe(
      retry(1),
      catchError(this.processError)
    )
    // const customer = Customers.find(x => x.id === id);
    // if (customer)
    //   return of(customer);

    // return EMPTY;
  }

  createCustomer(customer:Customer):Observable<Customer> {
    return this.httpClient.post<Customer>(this.endpoint + 'api/customer/addcustomer', JSON.stringify(customer) )
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
    return throwError(message);
 }
}

const Customers: Customer[] = [
  { id: "0001", firstname: "Tony", lastname: "Stark", email: "t.start@bloxxon.co", },
  { id: "0002", firstname: "Peter", lastname: "Parker", email: "p.parker@bloxxon.co", },
  { id: "0003", firstname: "Bruce", lastname: "Banner", email: "b.banner@bloxxon.co", },
];
