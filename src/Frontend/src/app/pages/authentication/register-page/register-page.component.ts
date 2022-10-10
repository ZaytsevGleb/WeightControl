import {Component, OnDestroy, OnInit} from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {Subscription} from "rxjs";
import {ActivatedRoute, Router} from "@angular/router";
import {AuthService} from "../../../services/auth.service";

@Component({
  selector: 'app-register-page',
  templateUrl: './register-page.component.html',
  styleUrls: ['./register-page.component.scss']
})
export class RegisterPageComponent implements OnInit, OnDestroy {

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
      name: this.nameFormControl,
      email: this.emailFormControl,
      password: this.passwordFormControl
    })
  }

  ngOnDestroy() {
    if (this.aSub) {
      this.aSub.unsubscribe();
    }
  }

  namePlaceholder: string = "Alex Evans";
  nameValidError: string = "Minimum length 2 characters";
  nameValue: string = "";
  nameFormControl = new FormControl('', [Validators.minLength(2), Validators.required]);

  emailPlaceholder: string = "Ex. pat@example.com";
  emailValidError: string = "Please enter a valid email address";
  emailValue: string = "";
  emailFormControl = new FormControl('', [Validators.required, Validators.email]);

  passwordValidError: string = "Minimum length 5 characters";
  passwordValue: string = "";
  passwordFormControl = new FormControl('', [Validators.minLength(5), Validators.required]);

  registerButtonText: string = "REGISTER";


  registerClick() {
    this.aSub = this.authService.register(this.form.value).subscribe({
      next: () => this.router.navigate(['/login'], {
        queryParams: {registered: true}
      }),
      error: (err) => console.log(err)
    })
  }
}
