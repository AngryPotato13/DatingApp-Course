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
    this.accountService.login(this.model).subscribe({
      next: response => {console.log(response);},
      error: error => console.log(error)
      
    })
  }

  logout(){
    this.accountService.logout();
  }

}
