import { Component, inject } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { AccordionModule } from 'ngx-bootstrap/accordion';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { TestNavComponent } from '../test-nav/test-nav.component';
import { NavComponent } from '../../nav/nav.component';

@Component({
  selector: 'app-test-my-campaign',
  standalone: true,
  imports: [AccordionModule, BsDropdownModule, BsDatepickerModule, TooltipModule, RouterLink, TestNavComponent],
  templateUrl: './test-my-campaign.component.html',
  styleUrl: './test-my-campaign.component.css'
})
export class TestMyCampaignComponent {
  private router = inject(Router);
 
  

}



 // private Hello = inject(TestNavComponent);


  // ChangeName(){
  //   this.navThing.PageName = "";
  // }