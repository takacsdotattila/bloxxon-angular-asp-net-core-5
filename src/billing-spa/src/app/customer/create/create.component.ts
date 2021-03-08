import { Component, OnInit } from '@angular/core';
import { Customer } from 'src/app/core/models/customer';
import { DataService } from 'src/app/core/services/data.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss']
})
export class CreateComponent implements OnInit {
  customer : Customer = {
    id: '',
    firstname: '',
    lastname: '',
    email: '',
    imgUrl: ''
  };
  submitted = false;
  constructor(private dataService:DataService) { }

  ngOnInit(): void {
  }


  saveCustomer(): void {
    // const data = {
    //   title: this.customer.firstname,
    //   description: this.customer.lastname
    // };

    this.dataService.createCustomer(this.customer)
      .subscribe(
        (response : any) => {
          console.log(response);
          this.submitted = true;
        },
        (error :any)=> {
          console.log(error);
        });
  }
  newTutorial(): void {
    this.submitted = false;
    this.customer = {
      id: '',
      firstname: '',
      lastname: '',
      email: '',
      imgUrl: ''
    };
  }
  

}
