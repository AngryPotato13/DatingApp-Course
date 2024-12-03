import { Component, inject } from '@angular/core';
import { Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-test-nav',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './test-nav.component.html',
  styleUrl: './test-nav.component.css'
})
export class TestNavComponent {
  private router = inject(Router);

}
