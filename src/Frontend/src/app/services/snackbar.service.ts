import {Injectable} from "@angular/core";
import {MatSnackBar} from "@angular/material/snack-bar";

@Injectable({
  providedIn: 'root'
})

export class SnackbarService {

  snackBar!: MatSnackBar;

  constructor(snackBar: MatSnackBar) {
    this.snackBar = snackBar;
  }

  openLoginSnackBar(error: number) {
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
    this.openSnackBar(message)
  }

  openRegisterSnackBar(error: number) {
    let message: string;
    switch (error) {
      case 3:
        message = "Such user already exists";
        break;
      default:
        message = "Successfully"
        break;
    }
    this.openSnackBar(message)
  }

  private openSnackBar(message: string) {
    this.snackBar.open(message, 'Accept', {
      horizontalPosition: 'center',
      verticalPosition: 'top',
      duration: 2000,
    })
  }
}
