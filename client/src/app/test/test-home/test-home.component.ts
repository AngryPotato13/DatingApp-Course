import { Component, inject } from '@angular/core';
import { MembersService } from '../../_services/members.service';
import { CarouselConfig, CarouselModule } from 'ngx-bootstrap/carousel';
import { Router, RouterLink } from '@angular/router';
import { AccordionModule } from 'ngx-bootstrap/accordion';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';

@Component({
  selector: 'app-test-home', 
  standalone: true,
  imports: [CarouselModule, AccordionModule, BsDropdownModule, BsDatepickerModule, RouterLink],
  templateUrl: './test-home.component.html',
  styleUrl: './test-home.component.css',
  providers: [
    { provide: CarouselConfig, useValue: { interval: 3000, noPause: true, showIndicators: false } }
  ]
})
export class TestHomeComponent {
  memberService = inject(MembersService);
  private router = inject(Router);
  users: any;



  MeowButton(){
    this.memberService.getMembers();
  }

}
