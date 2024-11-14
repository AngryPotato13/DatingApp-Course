import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AccountService } from '../_services/account.service';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { Router, RouterLink, RouterLinkActive } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-nav',
  standalone: true,
  imports: [FormsModule, BsDropdownModule, RouterLink, RouterLinkActive],
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.css'
})
export class NavComponent {
  accountService = inject(AccountService);   //injects the data from account.service.ts
  private router = inject(Router);
  private toastr = inject(ToastrService);
  model: any ={};

  login(){
    this.accountService.login(this.model).subscribe({   //calls the login method from account.service.ts
      next: _ => {this.router.navigateByUrl('/members')},   //what to do next and when the user logs in it takes them to the members page
      error: error => this.toastr.error(error.error)   //what to do if theres an error and displays an error box if the users puts a wrong ussername or password
      
    })
  }

  logout(){
    this.accountService.logout();
    this.router.navigateByUrl('/')   //When logged out it takes the user back to the home page
  }

}
