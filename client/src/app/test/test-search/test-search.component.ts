import { Component } from '@angular/core';
import { AccordionModule } from 'ngx-bootstrap/accordion';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';

@Component({
  selector: 'app-test-search',
  standalone: true,
  imports: [AccordionModule, BsDropdownModule, BsDatepickerModule],
  templateUrl: './test-search.component.html',
  styleUrl: './test-search.component.css'
})
export class TestSearchComponent {

}
