import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { IPagination, IProduct } from './shared/models/product';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{
  title = 'MY BRAND';
  baseUrl=environment.baseUrl;
  products:IProduct[];

  constructor(private http:HttpClient){}

  ngOnInit(): void {
    this.http.get(this.baseUrl+'products?pageSize=50').subscribe((response:IPagination)=>{
      this.products = response.data;
    },error=>{
      console.log(error);
    });
  }


}
