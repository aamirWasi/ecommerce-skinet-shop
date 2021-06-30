import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IProduct } from 'src/app/shared/models/product';
import { ShopService } from '../shop.service';
import { BreadcrumbService } from 'xng-breadcrumb';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {
  product:IProduct;

  constructor(private activateRoute:ActivatedRoute,private shopService:ShopService,private bcService:BreadcrumbService) {
    this.bcService.set('@productDetails',' ');
  }

  ngOnInit(): void {
    this.loadProduct();
  }
  loadProduct() {
    this.shopService.getProduct(+this.activateRoute.snapshot.paramMap.get('id')).subscribe(product=>{
      this.product = product;
      this.bcService.set('@productDetails',product.name);
    },error=>{
      console.log(error);
    });
  }

}
