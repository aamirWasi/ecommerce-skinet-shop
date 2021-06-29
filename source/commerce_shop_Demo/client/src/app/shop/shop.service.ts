import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { IPagination } from '../shared/models/product';
import { IProductBrand } from '../shared/models/productBrand';
import { IProductType } from '../shared/models/productType';

@Injectable({
  providedIn: 'root'
})
export class ShopService {

  baseUrl=environment.baseUrl;

  constructor(private http:HttpClient){}

  getProducts(){
    return this.http.get<IPagination>(this.baseUrl+'products?pageSize=50');
  }

  getTypes(){
    return this.http.get<IProductType[]>(this.baseUrl+'products/types');
  }

  getBrands(){
    return this.http.get<IProductBrand[]>(this.baseUrl+'products/brands');
  }
}
