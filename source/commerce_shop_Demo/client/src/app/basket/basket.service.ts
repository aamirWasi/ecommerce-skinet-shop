import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Basket, IBasket, IBasketItem, IBasketTotal } from '../shared/models/basket';
import { IProduct } from '../shared/models/product';

@Injectable({
  providedIn: 'root'
})
export class BasketService {

  baseUrl = environment.baseUrl;
  private basketSource = new BehaviorSubject<IBasket>(null);
  private basketTotalSource =new BehaviorSubject<IBasketTotal>(null);
  basket$ = this.basketSource.asObservable();
  basketTotal$ = this.basketTotalSource.asObservable();

  constructor(private http:HttpClient) { }

  getBasket(id:string){
    return this.http.get(this.baseUrl+'basket?id='+id).pipe(
      map((basket:IBasket)=>{
        this.basketSource.next(basket);
        this.calculateTotals();
      })
    )
  }

  setBasket(basket:IBasket){
    return this.http.post(this.baseUrl+'basket',basket).subscribe((basket:IBasket)=>{
      this.basketSource.next(basket);
      this.calculateTotals();
    },error=>{
      console.log(error);
    })
  }

  incrementItemQuantity(item:IBasketItem){
    const basket = this.getCurrentBasketvalue();
    const foundItemIndex = basket.items.findIndex(x=>x.id===item.id);
    basket.items[foundItemIndex].quantity++;
    this.setBasket(basket);
  }

  decrementItemQuantity(item:IBasketItem){
    const basket = this.getCurrentBasketvalue();
    const foundItemIndex = basket.items.findIndex(x=>x.id===item.id);
    if(basket.items[foundItemIndex].quantity>1){
      basket.items[foundItemIndex].quantity--;
      this.setBasket(basket);
    }
    else{
      this.removeItemFromBasket(item);
    }
  }
  removeItemFromBasket(item: IBasketItem) {
    const basket = this.getCurrentBasketvalue();
    if(basket.items.some(x=>x.id===item.id)){
      basket.items = basket.items.filter(x=>x.id!==item.id);
      if(basket.items.length>0){
        this.setBasket(basket);
      }
      else{
        this.deleteBasket(basket);
      }
    }
  }
  deleteBasket(basket: IBasket) {
    return this.http.delete(this.baseUrl+'basket?id='+basket.id).subscribe(()=>{
      this.basketSource.next(null);
      this.basketTotalSource.next(null);
      localStorage.removeItem('basket_id');
    },error=>{
      console.log(error);
    })
  }

  getCurrentBasketvalue(){
    return this.basketSource.value;
  }

  addItemToBasket(item:IProduct,quantity=1){
    const itemToAdd:IBasketItem=this.mapProductItemToBasketItem(item,quantity);
    const basket = this.getCurrentBasketvalue() ?? this.createBasket();
    basket.items = this.addOrUpdateBasketValue(basket.items,itemToAdd,quantity);
    this.setBasket(basket);
  }
  private addOrUpdateBasketValue(items: IBasketItem[], itemToAdd: IBasketItem, quantity: number): IBasketItem[] {
    const index = items.findIndex(x=>x.id === itemToAdd.id);
    if(index===-1){
      itemToAdd.quantity=quantity;
      items.push(itemToAdd);
    }
    else{
      items[index].quantity+=quantity;
    }
    return items;
  }
  private createBasket(): IBasket {
    var basket = new Basket();
    localStorage.setItem('basket_id',basket.id);
    return basket;
  }
  private mapProductItemToBasketItem(item: IProduct, quantity: number): IBasketItem {
    return{
      id : item.id,
      productName : item.name,
      price : item.price,
      quantity,
      type:item.productType,
      brand : item.productBrand,
      pictureUrl:item.pictureUrl
    };
  }

  private calculateTotals(){
    const basket = this.getCurrentBasketvalue();
    const shipping = 0;
    const subTotal = basket.items.reduce((a,b)=>
    (b.price*b.quantity)+a,0);
    const total = shipping+subTotal;
    this.basketTotalSource.next({shipping,total,subTotal});
  }

}
