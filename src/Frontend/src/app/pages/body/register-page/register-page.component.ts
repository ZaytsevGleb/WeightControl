import {Component, OnInit} from '@angular/core';

@Component({
  selector: 'app-register-page',
  templateUrl: './register-page.component.html',
  styleUrls: ['./register-page.component.scss']
})
export class RegisterPageComponent implements OnInit {

  constructor() {
  }

  ngOnInit(): void {
  }

  namePlaceholder: string = "Alex Evans";
  nameValidError: string = "Minimum length 2 characters";
  nameValue: string = "";

  emailPlaceholder: string = "Ex. pat@example.com";
  emailValidError: string = "Please enter a valid email address";
  emailValue: string = "";

  passwordValidError: string = "Minimum length 5 characters";
  passwordValue: string = "";

  registerButtonText: string = "REGISTER";


  registerClick() {

  }

}
