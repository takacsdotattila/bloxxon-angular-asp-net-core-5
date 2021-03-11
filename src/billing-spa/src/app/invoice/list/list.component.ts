import { Component, OnInit } from '@angular/core';
import { InvoiceCreate } from 'src/app/core/models/invoiceCreate';
import { InvoiceWithCustomer } from 'src/app/core/models/invoiceListItem';
import { DataService } from 'src/app/core/services/data.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {

  invoices: InvoiceWithCustomer[] = [];

  constructor(private dataService: DataService) { }

  ngOnInit(): void {
    this.dataService
      .getInvoices()
      .subscribe(result => this.invoices = result);
  }

  addInvoice(invoice: InvoiceWithCustomer){
    console.log("emitted stuff:" + invoice);
    this.invoices.push(invoice)
  }

  delete(id: string): void {
    var delBtn = confirm(" Do you want to delete ?");
    if ( delBtn === true ) {
      this.dataService.deleteInvoice(id)
      .subscribe();

      var index = this.invoices.findIndex(x=>x.id===id);
      this.invoices.splice(index,1);
    console.log("delete invoice: "+id);
  }
  

  }

}
