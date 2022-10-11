import {Component, OnDestroy, OnInit} from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {Subscription, tap} from "rxjs";
import {ActivatedRoute, Router} from "@angular/router";
import {AuthService} from "../../../services/auth.service";
import {MatSnackBar} from "@angular/material/snack-bar";

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
  snackBar!: MatSnackBar;

  constructor(authService: AuthService, router: Router, route: ActivatedRoute, snackBar: MatSnackBar) {
    this.authService = authService;
    this.router = router;
    this.route = route;
    this.snackBar = snackBar;
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
    this.aSub = this.authService.register(this.form.value)
      .pipe(tap((res: any) => this.openSnackBar(res.error)))
      .subscribe({
        next: () => this.router.navigate(['/login'], {
          queryParams: {registered: true}
        }),
      })
  }

  openSnackBar(error: number) {
    let message: string;
    switch (error) {
      case 3:
        message = "Such user already exists";
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
