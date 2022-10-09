import {Injectable} from '@angular/core';
import {Observable, tap} from 'rxjs';
import {ApiClient, LoginDto, LoginResultDto} from '../clients/api.client'
import {User} from "../models/user";

@Injectable({providedIn: 'root'})
export class AuthService {
  private readonly apiClient: ApiClient;

  private token!: string;

  constructor(apiClient: ApiClient) {
    this.apiClient = apiClient;
  }

  public login(user: User): Observable<LoginResultDto> {
    return this.apiClient.login(new LoginDto({
      email: user.email, password: user.password
    }))
      .pipe(tap((res) => {
        localStorage.setItem('auth-token', res.token!)
        this.setToken(res.token!)
      }));
  }

  register() {
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
}
