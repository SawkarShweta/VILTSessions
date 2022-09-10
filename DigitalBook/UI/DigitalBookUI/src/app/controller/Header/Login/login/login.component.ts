import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/app/models/user';
import { UsersService } from 'src/app/services/users.services';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  displayStyle = "block";
  users: User[] = [];
  user: User = {
    userId: 0,
    userName: '',
    firstName: '',
    lastName: '',
    emailId: '',
    userPassword: '',
    roleId: 0,
    active: true
  }

 token:string='';
 isAuthenticated:boolean=false;

  constructor(private router:Router,private usersService:UsersService) { }

  ngOnInit(): void {
    this.openPopup();
  }
  
  openPopup() {
    this.displayStyle = "block";
  }
  closePopup() {
    this.displayStyle = "none";
    //location.href='../';
    this.router.navigateByUrl('/');
  }

  onSubmit() {
    this.usersService.loginUser(this.user)
      .subscribe(
        (response: { token: string; isAuthenticated: boolean; }) => { 
          if(response.isAuthenticated ==true){
            localStorage.setItem("Token",response.token);
            this.usersService.getUserByUserName(this.user.userName).subscribe(
              response => { 
                this.user = response;
                localStorage.setItem("User",JSON.stringify(this.user));
                alert("Welcome "+this.user.firstName +" "+this.user.lastName);
              }
            )
          }
          else
            localStorage.removeItem("Token");
        }
      );
  }
}
