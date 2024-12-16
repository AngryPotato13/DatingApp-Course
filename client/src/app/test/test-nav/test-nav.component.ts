import { Component, inject } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { empty } from 'rxjs';

declare function BurgerMenu(): void; 

@Component({
  selector: 'app-test-nav',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './test-nav.component.html',
  styleUrl: './test-nav.component.css'
})
export class TestNavComponent {
  private router = inject(Router);
  PageName = "My Campaigns";

  BurgerClick(){
    BurgerMenu();
  }

  MyCampaign(){
    this.PageName = "My Campaigns";
  }

  MyChosenCampaign(){
    this.PageName = "My Campaign - Chosen campaign"
  }

  MyTasks(){
    this.PageName = "My Tasks";
  }

  MediaConfiguration(){
    this.PageName = "Media Configuration";
  }

  Reports(){
    this.PageName = "Reports";
  }

  Stepbuilder(){
    this.PageName = "Step builder";
  }

  Templates(){
    this.PageName = "Templates";
  }

}
