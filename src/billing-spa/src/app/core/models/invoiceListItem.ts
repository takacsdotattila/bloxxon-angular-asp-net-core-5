import { Customer } from "./customer";

export interface InvoiceWithCustomer {
    id: string;
    customerid: string;
    amount: number;
    deadline: Date;
    customer: Customer;
}