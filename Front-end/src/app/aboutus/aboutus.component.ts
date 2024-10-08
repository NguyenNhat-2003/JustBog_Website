import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-aboutus',
  standalone: true,
  imports: [],
  templateUrl: './aboutus.component.html',
  styleUrl: './aboutus.component.css'
})
export class AboutusComponent {
  constructor (private router: Router) {}
  OnClickWebname(): void {
    this.router.navigateByUrl('')
  }
  OnClickHome(): void {
    this.router.navigateByUrl('home')
  }
  OnClickPosts(): void {
    this.router.navigateByUrl('posts')
  }
  OnClickAboutus(): void {
    this.router.navigateByUrl('aboutus')
  }
  OnClickContact(): void {
    this.router.navigateByUrl('contact')
  }
}
