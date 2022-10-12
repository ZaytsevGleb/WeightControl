import {Component, OnDestroy, OnInit} from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {AuthService} from "../../../services/auth.service";
import {Subscription} from "rxjs";
import {ActivatedRoute, Router} from "@angular/router";
import {MatSnackBar} from "@angular/material/snack-bar";

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
  snackBar!: MatSnackBar;

  constructor(authService: AuthService, router: Router, route: ActivatedRoute, snackBar: MatSnackBar) {
    this.authService = authService;
    this.router = router;
    this.route = route;
    this.snackBar = snackBar;
  }

  ngOnInit(): void {
    this.form = new FormGroup({
      email: this.emailFormControl,
      password: this.passwordFormControl
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
    this.aSub = this.authService.login(this.form.value)
      .subscribe(res => {
        if (res.token != null) {
          this.openSnackBar(res.error!)
          this.router.navigate(['/meals'])
        } else {
          this.openSnackBar(res.error!)
        }
      })
  }

  openSnackBar(error: number) {
    let message: string;
    switch (error) {
      case 0:
        message = "User not found";
        break;
      case 1:
        message = "Incorrect password";
        break;
      default:
        message = "Successfully"
        break;
    }

    this.snackBar.open(message, 'Accept', {
      horizontalPosition: 'center',
      verticalPosition: 'top',
      duration: 2000,
    })
  }
}
