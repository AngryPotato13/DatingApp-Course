import { Component, inject } from '@angular/core';
import { MembersService } from '../../_services/members.service';
import { CarouselConfig, CarouselModule } from 'ngx-bootstrap/carousel';
import { Router } from '@angular/router';

@Component({
  selector: 'app-test-home', 
  standalone: true,
  imports: [CarouselModule],
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
