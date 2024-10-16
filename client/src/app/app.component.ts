import { Component, inject, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NavComponent } from "./nav/nav.component";
import { AccountService } from './_services/account.service';
import { HomeComponent } from "./home/home.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, NavComponent, HomeComponent],
  templateUrl: './app.component.html',     //this is the html template that this component is using
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit{       //this consturctor happens when the class is instantiated
  private accountService = inject(AccountService);

  ngOnInit(): void {       //This is called after angular has initialized all data-bound properties
    this.setCurrentUser();
  }

  setCurrentUser(){
    const userString = localStorage.getItem('user');
    if(!userString) return;
    const user = JSON.parse(userString);
    this.accountService.currentUser.set(user);
  }
}
