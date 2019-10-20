import { Component } from '@angular/core';
import { Product } from './product';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'inventify';

  products: Product[];

  constructor() {
    this.products = [
      new Product(0, 'Apple', 'Red Apple'),
      new Product(1, 'Orange', 'Orange Orange')
    ];
  }

  onButtonClick() {
    alert('Hello!');
  }
}
