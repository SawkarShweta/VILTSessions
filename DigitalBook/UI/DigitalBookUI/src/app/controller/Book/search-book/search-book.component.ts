import { Component, OnInit } from '@angular/core';
import { BooksService } from 'src/app/services/books.service';
import {Book} from 'src/app/models/book';
import {User} from 'src/app/models/user';

@Component({
  selector: 'app-search-book',
  templateUrl: './search-book.component.html',
  styleUrls: ['./search-book.component.css']
})
export class SearchBookComponent implements OnInit {
  user:User={
    userId:0,
    userName:'',
    firstName:'',
    lastName:'',
    emailId:'',
    userPassword:'',
    roleId:0,
    active:true
  }

  books:Book[] = [];
  book : Book = {
    bookId:0,
    categoryId :0,
    userId: 0,
    bookName:'',
    price:0,
    publisher:'',
    publishedDate:new Date(),
    content:'',
    active:true,
    createdDate:new Date(),
    createdby:0,
    modifiedDate:new Date(),
    modifiedby:0,
    user:this.user,
  }
  constructor(private booksService : BooksService) { }

  ngOnInit(): void {
    //this.getAllBooks();
  }

  getAllBooks() {
    this.booksService.getAllBooks()
    .subscribe(
      response => { this.books = response}
    );
  }

  onSubmit(){
    this.searchBook(this.book);
  }

  searchBook(book: Book){
    var uname=this.book.user==null?'':this.book.user.userName;
    this.booksService.searchBook(this.book.bookName,uname,this.book.publisher,this.book.publishedDate)
    .subscribe(
      response => {
         this.books = response
      }
    )
  }
}
