import { HttpClient } from '@angular/common/http';
import { inject, Injectable, signal } from '@angular/core';
import { User } from '../_models/user';
import { map } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'    //is a singleton and is instantiated when the user uses the application and disposed of when the application is
})
export class AccountService {
  private http = inject(HttpClient);
  baseUrl = environment.apiUrl;    //Uses the url from environment.ts
  currentUser = signal<User | null>(null);   //User is imported from user.ts and (null) is it's initial value

  login(model:any){             //uses login from nav.component.ts (Think this is wrong)
    return this.http.post<User>(this.baseUrl + 'account/login', model).pipe(   //this is a http post request
      map(user => {      //this returns the user from the api
        if (user){
          this.setCurrentUser(user);
        }
      })
    )
  }

  register(model:any){             
    return this.http.post<User>(this.baseUrl + 'account/register', model).pipe(
      map(user => {
        if (user){
          this.setCurrentUser(user);
        }
        return user;
      })
    )
  }

  setCurrentUser(user: User){
    localStorage.setItem('user', JSON.stringify(user));   //stores user as a stringify in local storage and user is the key for it
    this.currentUser.set(user);   //this sets the currentUser as user
  }


  logout(){
    localStorage.removeItem('user');
    this.currentUser.set(null);
  }

}
