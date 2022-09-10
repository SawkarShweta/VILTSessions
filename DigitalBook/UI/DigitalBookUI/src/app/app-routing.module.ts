import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateBookComponent } from './controller/Book/createBook/create-book/create-book.component';
import { PurchasebookhistoryComponent } from './controller/Book/PurchaseBookHistory/purchasebookhistory/purchasebookhistory.component';
import { SearchBookComponent } from './controller/Book/search-book/search-book.component';
import { LoginComponent } from './controller/Header/Login/login/login.component';
import { RegisterComponent } from './controller/Header/Register/register/register.component';

const routes: Routes = [
  { path: 'searchBook', component: SearchBookComponent },
  {path:'login',component:LoginComponent},
  {path: 'register',component:RegisterComponent},
  {path:'createBook',component:CreateBookComponent},
  {path:'history',component:PurchasebookhistoryComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
