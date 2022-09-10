import { Component, OnInit } from '@angular/core';
import { BooksService } from 'src/app/services/books.service';
import {Book} from 'src/app/models/book';
import {User} from 'src/app/models/user';

@Component({
  selector: 'app-create-book',
  templateUrl: './create-book.component.html',
  styleUrls: ['./create-book.component.css']
})
export class CreateBookComponent implements OnInit {
  msg: string='';

  constructor(private booksService : BooksService) { }
  user:User=JSON.parse(localStorage.getItem('User') || '{}');

  books:Book[] = [];
  book : Book = {
    bookId:0,
    categoryId :0,
    userId: this.user.userId,
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
    user:undefined
  }

  categories: any=this.getAllCategories();

  ngOnInit(): void {
    //this.getAllCategories();
  }

  getAllCategories() {
    this.booksService.getAllCategories()
    .subscribe(
      response => { this.categories = response}
    );
  }

  getAllBooks() {
    this.booksService.getAllBooks()
    .subscribe(
      response => { this.books = response}
    );
  }

  onSubmit(){
    if (this.book.bookId === 0) {
      this.booksService.saveBook(this.book)
        .subscribe(
          response => {
            if(response.bookId>0)
            {
              this.msg="Book Saved Successfully";
              alert(this.msg);
            }
            this.getAllBooks();
            this.book = {
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
              user:this.user
            };
          }
        );
     }
     else {
       //this.updateCard(this.card);
     }
  }

}
