import { MeasuringUnit } from './../../generated/model/measuringUnit';
import { Formula } from './../../generated/model/formula';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { DistanceCalculatorService } from 'src/app/generated';
import { catchError, throwError } from 'rxjs';

@Component({
  selector: 'app-distance-calculator',
  styleUrls: ['distance-calculator.component.css'],
  templateUrl: 'distance-calculator.component.html',
})
export class DistanceCalculatorComponent implements OnInit {
  constructor(
    private distanceCalculatorService: DistanceCalculatorService,
    private fb: FormBuilder
  ) {}

  distance: Number | null = null;
  error: string | null = null;

  form: FormGroup = this.fb.group({
    startCoordinates: '53.297975,-6.372663',
    endCoordinates: '43.508133,16.440193',
    radius: 6371,
    formula: Formula.CosineLaw,
    unit: MeasuringUnit.Kilometer,
  });

  ngOnInit(): void {}

  calculateDistance() {
    this.distance = null;
    this.error = null;

    this.distanceCalculatorService
      .distanceCalculatorGet(
        this.form.controls['startCoordinates'].value,
        this.form.controls['endCoordinates'].value,
        this.form.controls['radius'].value,
        this.form.controls['formula'].value,
        this.form.controls['unit'].value
      )
      .pipe(
        catchError((e) => {
          if (e.status === 400) {
            this.handleErrors(e.error.errors);
          }
          return throwError(() => e);
        })
      )
      .subscribe((result) => {
        this.distance = result;
      });
  }

  handleErrors(errors: Object) {
    let errorMessages: Array<string> = [];
    Object.entries(errors).forEach(([key, value]) =>
      errorMessages.push(...(value as string))
    );

    this.error = errorMessages.reduce(
      (prev, current) => prev + current + ' ',
      ''
    );
  }
}
