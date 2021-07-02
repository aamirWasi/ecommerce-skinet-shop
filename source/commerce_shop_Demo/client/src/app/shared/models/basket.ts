import {v4 as uuidv4} from 'uuid';

export interface IBasket {
  id:    string;
  items: IBasketItem[];
}

export interface IBasketTotal{
  shipping:number;
  subTotal:number;
  total:number;
}

export interface IBasketItem {
  id:          number;
  productName: string;
  quantity:    number;
  price:       number;
  pictureUrl:  string;
  brand:       string;
  type:        string;
}

export class Basket implements IBasket{
  id=uuidv4();
  items: IBasketItem[]=[];

}


