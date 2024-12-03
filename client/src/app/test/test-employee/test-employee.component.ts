 import { Component, inject } from '@angular/core';
import { Router } from '@angular/router';
import { AccordionModule } from 'ngx-bootstrap/accordion';
import { TooltipModule } from 'ngx-bootstrap/tooltip';


@Component({
  selector: 'app-test-employee',
  standalone: true,
  imports: [AccordionModule, TooltipModule],
  templateUrl: './test-employee.component.html',
  styleUrl: './test-employee.component.css'
})
export class TestEmployeeComponent {

  private router = inject(Router);
  
}
