import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AccountService } from '../_services/account.service';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { concat } from 'rxjs';
import { NgIf } from '@angular/common';

@Component({
  selector: 'app-nav',
  standalone: true,
  imports: [FormsModule, BsDropdownModule],
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.css'
})
export class NavComponent {
  accountService = inject(AccountService);   //injects the data from account.service.ts
  model: any ={};

  login(){
    this.accountService.login(this.model).subscribe({   //calls the login method from account.service.ts
      next: response => {console.log(response);},   //what to do next
      error: error => console.log(error)   //what to do if theres an error
      
    })
  }

  logout(){
    this.accountService.logout();
  }

}
