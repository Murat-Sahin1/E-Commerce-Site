import { Component } from '@angular/core';

@Component({ //Decorator
  selector: 'app-root',
  templateUrl: './app.component.html', //can access the properties of this component inside the templateUrl
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'E-Commerce';
}
