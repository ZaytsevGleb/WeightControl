import {Injectable} from '@angular/core';
import {Observable, tap} from 'rxjs';
import {ApiClient, LoginDto, LoginResultDto, RegisterDto, RegisterResultDto} from '../clients/api.client'
import {UserLogin} from "../models/user-login";
import {UserRegister} from "../models/user-register";

@Injectable({providedIn: 'root'})
export class AuthService {
  private readonly apiClient: ApiClient;

  private token!: string;

  constructor(apiClient: ApiClient) {
    this.apiClient = apiClient;
  }

  public login(user: UserLogin): Observable<LoginResultDto> {
    return this.apiClient.login(new LoginDto({
      email: user.email,
      password: user.password
    }))
      .pipe(tap((res) => {
        localStorage.setItem('auth-token', res.token!)
        this.setToken(res.token!)
      }));
  }

  register(user: UserRegister): Observable<RegisterResultDto> {
    return this.apiClient.register(new RegisterDto({
      name: user.name,
      email: user.email,
      password: user.password
    }))
      .pipe(tap((res) => {
        localStorage.setItem('auth-token', res.token!)
        this.setToken(res.token!)
      }));
  }

  logout() {
    this.setToken(null!);
    localStorage.clear();
  }

  setToken(token: string) {
    this.token = token;
  }

  getToken() {
    return this.token;
  }

  isAuthenticated(): boolean {
    return !!this.token;
  }
}
