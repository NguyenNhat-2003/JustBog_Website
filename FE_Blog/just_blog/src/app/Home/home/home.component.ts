import { CommonModule } from '@angular/common';
import { Component, HostListener, inject } from '@angular/core';
import { RouterModule } from '@angular/router';
import {MatDialog, MatDialogModule} from '@angular/material/dialog';
import { CreatePostComponent } from '../../Post/post/create-post/create-post.component';
@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule,
    RouterModule,MatDialogModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent {
  @HostListener('document:DOMContentLoaded', ['$event'])
  onDomContentLoaded(event: Event) {
    let scrollPos = 0;
    const mainNav = document.getElementById('mainNav');
    const headerHeight = mainNav?.clientHeight;
    window.addEventListener('scroll', function () {
      const currentTop = document.body.getBoundingClientRect().top * -1;
      if (currentTop < scrollPos) {
        // Scrolling Up
        if (currentTop > 0 && mainNav?.classList.contains('is-fixed')) {
          mainNav.classList.add('is-visible');
        } else {
          console.log(123);
          mainNav?.classList.remove('is-visible', 'is-fixed');
        }
      } else {
        // Scrolling Down
        mainNav?.classList.remove('is-visible');
        if (currentTop > headerHeight! && !mainNav?.classList.contains('is-fixed')) {
          mainNav?.classList.add('is-fixed');
        }
      }
      scrollPos = currentTop;
    });
  }

  readonly dialog = inject(MatDialog);

  openDialog() {
    const dialogRef = this.dialog.open(CreatePostComponent);

    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
    });
  }
}
