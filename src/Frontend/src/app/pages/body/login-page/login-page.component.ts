import {Component, OnInit} from '@angular/core';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss']
})
export class LoginPageComponent implements OnInit {

  constructor() {
  }

  ngOnInit(): void {
  }

  emailPlaceholder: string = "Ex. pat@example.com";
  emailValidError: string = "Please enter a valid email address";
  emailValue: string = "";

  passwordValidError: string = "Minimum length 5 characters";
  passwordValue: string = "";

  loginButtonText: string = "LOGIN";

  loginClick() {

  }

}
