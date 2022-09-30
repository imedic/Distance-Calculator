import { Component, OnInit } from '@angular/core';
import { DistanceCalculatorService } from './generated';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  constructor(private distanceCalculatorService: DistanceCalculatorService) {}
  title = 'DistanceCalculator';

  ngOnInit(): void {
    this.distanceCalculatorService
      .distanceCalculatorGet()
      .subscribe(result => {
        console.log(result);
      });
  }
}
