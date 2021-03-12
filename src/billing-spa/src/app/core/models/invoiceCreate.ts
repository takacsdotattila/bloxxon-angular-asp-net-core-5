export interface InvoiceCreate {
    customerid: string;
    amount: number;
    deadline: Date;
}