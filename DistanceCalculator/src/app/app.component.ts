import { Component, OnInit } from '@angular/core';
import { DistanceCalculatorService } from './generated';
import { Formula } from './generated/model/formula';
import { MeasuringUnit } from './generated/model/measuringUnit';

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
      .distanceCalculatorGet("53.297975,-6.372663", "43.508133,16.440193", 6371, Formula.CosineLaw, MeasuringUnit.NauticalMile)
      .subscribe(result => {
        console.log(result);
      });
  }
}
