import { Customer } from "./customer";
import { Invoice } from "./invoice";

export interface CustomerDetails {
    customer: Customer;
    invoices? : Invoice[];
}