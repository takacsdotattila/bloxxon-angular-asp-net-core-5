export interface InvoiceCreate {
    customerId: string;
    amount: number;
    deadline: Date;
}