import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { catchError, Observable, throwError } from 'rxjs';
import { purchase } from '../models/purchase';

@Injectable({
  providedIn: 'root'
})
export class HeaderService {

   baseUrl="https://localhost:7044/api/Purchases";

  constructor(private router:Router,private http:HttpClient) { }

  CheckUserLoggedInOrNot():boolean{
        if (localStorage.getItem('Token')) {
            return true;
        }

        //this.router.navigate(['/searchBook']);     
        return false;
    }

    GetBookListReader(emailId :string):Observable<any>{
        return this.http.get<any>(this.baseUrl +"/GetBooksWithStatus?emailId="+emailId).pipe(
            catchError((error:any)=>{return this.errorHandler(error)})
          );
    }

    PurchaseBook(purchases : purchase):Observable<purchase>{
        return this.http.post<purchase>(this.baseUrl,purchases).pipe(
            catchError((error:any)=>{return this.errorHandler(error)})
          );
    }

    GetBookHistory(emailId :string):Observable<any>{
        return this.http.get<any>(this.baseUrl +"/GetBookHistory?emailId="+emailId).pipe(
            catchError((error:any)=>{return this.errorHandler(error)})
          );
    }

    errorHandler(error: { error: { message: string;detail:string }; status: any; message: any; }) {
        let errorMessage = '';
        if(error.error instanceof ErrorEvent) {
          errorMessage = error.error.message;
        } else {
          errorMessage = error.error.detail;
        }
        alert(errorMessage);
        return throwError(errorMessage);
      }

}
