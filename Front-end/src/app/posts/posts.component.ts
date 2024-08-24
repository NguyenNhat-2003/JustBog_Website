import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-posts',
  standalone: true,
  imports: [],
  templateUrl: './posts.component.html',
  styleUrl: './posts.component.css'
})
export class PostsComponent {
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
  OnClickBlogView(): void {
    this.router.navigateByUrl('blogview')
  }
}
