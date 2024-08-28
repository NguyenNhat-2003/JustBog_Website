import { Routes } from '@angular/router';
import { LoginComponent } from './Auth/login/login.component';
import { HomeComponent } from './Home/home/home.component';
import { AboutComponent } from './About/about/about.component';
import { ContactComponent } from './Contact/contact/contact.component';
import { PostComponent } from './Post/post/post.component';

export const routes: Routes = [
    {
        path: '',
        redirectTo: 'home',
        pathMatch: 'full'
    },
    {
        path: 'login',
        component: LoginComponent
    },
    {
        path: 'about',
        component: AboutComponent
    },
    {
        path: 'home',
        component: HomeComponent
    },
    {
        path: 'contact',
        component: ContactComponent
    },
    {
        path: 'post',
        component: PostComponent
    },
];
