import {Component, OnDestroy, OnInit} from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {AuthService} from "../../../services/auth.service";
import {Subscription} from "rxjs";
import {ActivatedRoute, Params, Router} from "@angular/router";

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss']
})
export class LoginPageComponent implements OnInit, OnDestroy {

  private authService: AuthService
  form!: FormGroup;
  aSub!: Subscription;
  router!: Router;
  route!: ActivatedRoute;

  constructor(authService: AuthService, router: Router, route: ActivatedRoute) {
    this.authService = authService;
    this.router = router;
    this.route = route;
  }

  ngOnInit(): void {
    this.form = new FormGroup({
      email: this.emailFormControl,
      password: this.passwordFormControl
    })
    this.route.queryParams.subscribe((params: Params) =>{
      if(params['registered']){

      }
      else if (params['accessDenied']){

      }
    })
  }

  ngOnDestroy() {
    if (this.aSub) {
      this.aSub.unsubscribe()
    }
  }

  emailPlaceholder: string = "Ex. pat@example.com";
  emailValidError: string = "Please enter a valid email address";
  emailValue: string = "";
  emailFormControl = new FormControl('', [Validators.required, Validators.email]);

  passwordValidError: string = "Minimum length 5 characters";
  passwordValue: string = "";
  passwordFormControl = new FormControl('', [Validators.minLength(5), Validators.required]);

  loginButtonText: string = "LOGIN";

  loginClick() {
    this.aSub = this.authService.login(this.form.value).subscribe({
      next: () => this.router.navigate(['/meals']),
      error: (err) => console.log(err),
    })
  }
}
