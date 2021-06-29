import { Component, OnInit } from '@angular/core';
import { IProduct } from '../shared/models/product';
import { IProductBrand } from '../shared/models/productBrand';
import { IProductType } from '../shared/models/productType';
import { ShopService } from './shop.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {

  products:IProduct[];
  types:IProductType[];
  brands:IProductBrand[];
  brandId=0;
  typeId=0;

  constructor(private shopService:ShopService) { }

  ngOnInit(): void {
    this.getProducts();
    this.getBrands();
    this.getTypes();
  }
  getProducts() {
    this.shopService.getProducts(this.brandId,this.typeId).subscribe((response)=>{
      this.products = response.data;
    },error=>{
      console.log(error);
    })
  }

  getTypes(){
    this.shopService.getTypes().subscribe(response=>{
this.types = [{id:0,name:'All'},...response];
    },error=>{
      console.log(error);
    })
  }

  getBrands(){
    this.shopService.getBrands().subscribe(response=>{
this.brands = [{id:0,name:'All'},...response];
    },error=>{
      console.log(error);
    })
  }

  onBrandSelected(brandId:number){
    this.brandId = brandId;
    this.getProducts();
  }

  onTypeSelected(typeId:number){
    this.typeId = typeId;
    this.getProducts();
  }

}
