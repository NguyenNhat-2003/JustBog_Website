import { HttpClient } from '@angular/common/http';
import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
OnClickHome() {
  this.router.navigateByUrl('')
}
  logibObj:any = {
    "EmailId": "",
    "Password": ""
  };
  
  constructor (private router: Router) {
  }
  
  
  http= inject(HttpClient);

  onLogin() {
    debugger;
    this.http.post("https://freeapi.miniprojectideas.com/api/User/Login", this.logibObj).subscribe((res:any) => {
      if (res.result) {
        alert("Login Sucess");
      } else {
        alert("Check username or password");
      }
    })
  }
}
