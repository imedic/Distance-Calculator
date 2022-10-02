import { CalculatorFormComponent } from './components/calculator-form/calculator-form.component';
import { SphereGraphicComponent } from './components/sphere-graphic/sphere-graphic.component';
import { DistanceCalculatorComponent } from './components/distance-calculator/distance-calculator.component';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { environment } from '../environments/environment.prod';
import { BASE_PATH } from './generated';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [AppComponent, DistanceCalculatorComponent, SphereGraphicComponent, CalculatorFormComponent],
  imports: [BrowserModule, HttpClientModule, ReactiveFormsModule],
  providers: [
    {
      provide: BASE_PATH,
      useValue: environment.baseApiUrl,
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
