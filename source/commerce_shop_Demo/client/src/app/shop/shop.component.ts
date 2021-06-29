import { stringify } from '@angular/compiler/src/util';
import { Component, OnInit } from '@angular/core';
import { IProduct } from '../shared/models/product';
import { IProductBrand } from '../shared/models/productBrand';
import { IProductType } from '../shared/models/productType';
import { ShopParams } from '../shared/models/shopParams';
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
  totalCount:number;
  shopParams = new ShopParams();
  sortOptions = [
    {name:'Alphabetical',value:'name'},
    {name:'Price : Low to High',value:'priceAsc'},
    {name:'Price : High to Low',value:'priceDesc'}
  ]

  constructor(private shopService:ShopService) { }

  ngOnInit(): void {
    this.getProducts();
    this.getBrands();
    this.getTypes();
  }
  getProducts() {
    this.shopService.getProducts(this.shopParams).subscribe((response)=>{
      this.products = response.data;
      this.shopParams.pageIndex = response.pageIndex;
      this.shopParams.pageSize = response.pageSize;
      this.totalCount = response.count;
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
    this.shopParams.brandId = brandId;
    this.shopParams.pageIndex=1;
    this.getProducts();
  }

  onTypeSelected(typeId:number){
    this.shopParams.typeId = typeId;
    this.shopParams.pageIndex=1;
    this.getProducts();
  }

  onSortSelected(sort:string){
    this.shopParams.sort = sort;
    this.getProducts();
  }

  onPageChanged(event:any){
    this.shopParams.pageIndex=event.page;
    this.getProducts();
  }

}