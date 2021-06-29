import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { IPagination } from '../shared/models/product';
import { IProductBrand } from '../shared/models/productBrand';
import { IProductType } from '../shared/models/productType';
import {map} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ShopService {

  baseUrl=environment.baseUrl;

  constructor(private http:HttpClient){}

  getProducts(barndId?:number,typeId?:number){
    let params = new HttpParams();

    if(barndId)
      params =params.append('brandId',barndId.toString());
    if(typeId)
      params =params.append('typeId',typeId.toString());

    return this.http.get<IPagination>(this.baseUrl+'products',{
      observe:'response',params
    }).pipe(map(response=>{
      return response.body
    }));
  }

  getTypes(){
    return this.http.get<IProductType[]>(this.baseUrl+'products/types');
  }

  getBrands(){
    return this.http.get<IProductBrand[]>(this.baseUrl+'products/brands');
  }
}
