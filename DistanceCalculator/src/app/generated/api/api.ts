export * from './distanceCalculator.service';
import { DistanceCalculatorService } from './distanceCalculator.service';
export * from './weatherForecast.service';
import { WeatherForecastService } from './weatherForecast.service';
export const APIS = [DistanceCalculatorService, WeatherForecastService];
