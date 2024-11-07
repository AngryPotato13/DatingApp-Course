import { Component, inject, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NavComponent } from "./nav/nav.component";
import { AccountService } from './_services/account.service';
import { HomeComponent } from "./home/home.component";
import { NgxSpinnerComponent } from 'ngx-spinner';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, NavComponent, HomeComponent, NgxSpinnerComponent],
  templateUrl: './app.component.html',     //this is the html template that this component is using
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit{       //this consturctor happens when the class is instantiated
  private accountService = inject(AccountService);

  ngOnInit(): void {       //This is called after angular has initialized all data-bound properties
    this.setCurrentUser();
  }

  setCurrentUser(){     //This checks to see whether the user has been logged in before and if they have it keeps them signed in
    const userString = localStorage.getItem('user');
    if(!userString) return;   //if userString is empty it'll stop here
    const user = JSON.parse(userString);   
    this.accountService.currentUser.set(user);
  }
}
