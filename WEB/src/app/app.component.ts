import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IProduct } from './models/products';


@Component({ //Decorator
  selector: 'app-root',
  templateUrl: './app.component.html', //can access the properties of this component inside the templateUrl
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'E-Commerce';
  products: IProduct[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.http.get<IProduct[]>('https://localhost:5001/api/products').subscribe(
      (response: IProduct[]) => {
        this.products = response;
        console.log(this.products);
      });
  }
}
