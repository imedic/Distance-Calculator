import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  constructor(private httpClient: HttpClient) {
    
  }
  title = 'DistanceCalculator';

  ngOnInit(): void {
    this.httpClient.get("https://localhost:7248/WeatherForecast").subscribe(result => {
      console.log(result);
    })
  }
}
