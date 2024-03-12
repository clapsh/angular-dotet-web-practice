import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../user';
import { RestService } from '../service/rest.service';

@Component({
  selector: 'app-user-form',
  templateUrl: './user-form.component.html',
  styleUrls: ['./user-form.component.css']
})
export class UserFormComponent implements OnInit {

  constructor(
    private http:HttpClient, 
    private restSevice: RestService,
    ) { }

  ngOnInit(): void {
  }

  // dummy data
  model = new User("" ,"");

  submitted = false;

  onSubmit(data:User) {
    
    
    // service 
    this.restSevice.addUser(data.id, data.username)
    .then(resp=> {
      console.log("response: ",resp);
    });

    this.submitted = true;
  }

  newUser() {
    this.model = new User("","");
  }

}
