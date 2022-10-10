import {Injectable} from "@angular/core";
import {AuthService} from "./services/auth.service";
import {HttpEvent, HttpHandler, HttpInterceptor, HttpRequest} from "@angular/common/http";
import {Observable} from "rxjs";

@Injectable()
export class TokenInterceptor implements HttpInterceptor{

  private authService: AuthService;

  constructor(authService: AuthService) {
    this.authService = authService;
  }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    if(this.authService.isAuthenticated()){
      req = req.clone({
        setHeaders: {
          Authorization: 'Bearer ' +  this.authService.getToken()
        }
      })
    }
    return next.handle(req)
  }
}
