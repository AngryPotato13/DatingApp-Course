import { CanActivateFn } from '@angular/router';
import { AccountService } from '../_services/account.service';
import { inject } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

export const authGuard: CanActivateFn = (route, state) => {   //this is just a function
  const accountService = inject(AccountService);
  const toastr = inject(ToastrService);

  if(accountService.currentUser()){
    return true;                         //if the user is signed it it takes them to the path they want to go to
  } else{
    toastr.error('You shall not pass!')
    return false;                        //if the user isn't signed in it shows an error message instead
  }
};
