import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map, Observable } from 'rxjs';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  baseUrl = "https://localhost:7044/api/UserMasters";
  authUrl= "https://localhost:7214/validateUser";
  constructor(private http: HttpClient) { }

  //Get all Users
  getAllUsers():Observable<User[]>{
      return this.http.get<User[]>(this.baseUrl);
  }

  getUserByUserName(userName:string):Observable<User>{
    return this.http.get<User>(this.baseUrl+'/GetUserMasterByName?name='+userName);
  }

  saveUser(user: User):Observable<User> {
    return this.http.post<User>(this.baseUrl, user);
  }

  loginUser(user: User):Observable<any>{
    var request={
      userName:user.userName,
      password:user.userPassword
    }
    return this.http.post<any>(this.authUrl,request);
  }
}
