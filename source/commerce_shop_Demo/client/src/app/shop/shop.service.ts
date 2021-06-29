import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { IPagination } from '../shared/models/product';
import { IProductBrand } from '../shared/models/productBrand';
import { IProductType } from '../shared/models/productType';
import {map} from 'rxjs/operators';
import { ShopParams } from '../shared/models/shopParams';

@Injectable({
  providedIn: 'root'
})
export class ShopService {

  baseUrl=environment.baseUrl;

  constructor(private http:HttpClient){}

  getProducts(shopParams:ShopParams){
    let params = new HttpParams();

    if(shopParams.brandId!==0)
      params =params.append('brandId',shopParams.brandId.toString());
    if(shopParams.typeId!==0)
      params =params.append('typeId',shopParams.typeId.toString());
      params = params.append('sort',shopParams.sort);
      params =params.append('pageIndex',shopParams.pageIndex.toString());
      params =params.append('pageSize',shopParams.pageSize.toString());

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
