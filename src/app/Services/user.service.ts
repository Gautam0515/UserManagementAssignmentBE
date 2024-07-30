import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http:HttpClient) { }

  private api = ""

  GetAllUsers():Observable<any>{
    return this.http.get(this.api)
  }

  LoginCheckPost(credentials:any):Observable<string>{
    return this.http.post<string>('https://localhost:7244/api/User/Login',credentials,{ responseType: 'text' as 'json' });
  }

  ForgotCredPost(Email:any):Observable<any>{
    return this.http.post('https://localhost:7244/api/User/Forgot',Email);
  }

  ResetPassPut(Password:any):Observable<any>{
    return this.http.put('https://localhost:7244/api/User/Reset',Password);
  }

}
