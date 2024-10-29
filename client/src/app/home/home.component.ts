import { Component, inject, OnInit } from '@angular/core';
import { RegisterComponent } from "../register/register.component";
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [RegisterComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit{
  http = inject(HttpClient);
  registerMode = false;
  users: any;

  ngOnInit(): void {    //Does this when the application is started
    this.getUsers();
  }


  registerToggle(){    //This is a conditional to whether to display the register form or not
    this.registerMode = !this.registerMode;
  }

  cancelRegisterMode(event: boolean){
    this.registerMode = event;
  }

  getUsers(){       //This gets all the users from the database
    this.http.get('https://localhost:5001/api/users').subscribe({
      next: Response => this.users = Response,
      error : error => console.log(error),
      complete: () => console.log('Request has completed')
    })
  }
}
