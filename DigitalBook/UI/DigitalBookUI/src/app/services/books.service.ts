import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Book } from '../models/book';

@Injectable({
  providedIn: 'root'
})
export class BooksService {

  baseUrl = "https://localhost:7044/api/Books";

  constructor(private http: HttpClient) { }

  //Get all Books
  getAllBooks():Observable<Book[]>{
      return this.http.get<Book[]>(this.baseUrl);
  }

  //https://localhost:7044/api/Books/searchBook?title=abc&author=rr&publisher=string&releasedDate=2022-09-07
  searchBook(title:string,author:string,publisher:string,releasedDate:Date):Observable<Book[]>{
    return this.http.get<Book[]>(this.baseUrl+'/searchBook?title='+title+'&author='+author+'&publisher='+publisher+'&releasedDate='+releasedDate);
  }

  getAllCategories():Observable<any[]>{
    return this.http.get<any[]>(this.baseUrl+'/GetAllCategories');
  }

  saveBook(book: Book):Observable<Book> {
    return this.http.post<Book>(this.baseUrl, book);
  }
}
