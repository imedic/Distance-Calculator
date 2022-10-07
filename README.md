# Distance between two points
This application calculates a distance between two coordinates on a sphere with an option to use different formulas, sphere radius, and output measurement units.

The project consists of a .NET 6 Web API and an Angular 14 frontend application.

~~You can check the live app at https://distance.refactor.hr/~~ (The API is currently disabled)

## Getting started

Prerequisites:
- dotnet 6
- node v16
- Visual Studio 2022 (optional)
- Seq (optional)
- Java (optional - for running the openapi generator)


**Frontend setup:**
1. Navigate to `/DistanceCalculator`
2. Run `npm install`
3. Run `npm start` to serve the app immediately or `npm run build` to create a production build

**Backend setup using Visual Studio 2022:**
1. Open `DistanceCalculator.sln`
2. Build the solution
3. Run the solution by pressing the `Start` button in the Visual Studio top toolbar

**Backend setup using a console (alternative)**
1. Run `dotnet build`
2. Navigate to `/DistanceCalculator.API` and run `dotnet run`


## Project structure
```
.
├── Client
├──── DistanceCalculator
├── Server
├──── Tests
├────── DistanceCalculator.IntegrationTests
├────── DistanceCalculator.UnitTests
├──── DistanceCalculator.API
├──── DistanceCalculator.Core

```

1. **`client`**: This directory contains the entire client side of the application, a very basic Angular 14 application.
   
2. **`server`**: This directory contains all the backend code of the application.
   
3. **`Tests`**: The directory that contains two test projects: **`DistanceCalculator.IntegrationTests`** and **`DistanceCalculator.UnitTests`**.
   
4.  **`DistanceCalculator.API`**: The web API of the application.
   
5. **`DistanceCalculator.Core`**: All the application business logic and rules.


## Frontend
The frontend is a simple Angular 14 application setup using the default Visual Studio template. This application was created as a visual helper so the use of the API can be demonstrated. Not too much effort was put in since the focus was on backend.

### Code Generation
The `openapi-generator` is added to the frontend project that generates Angular services and models from the `swagger.json` file. If there were some API changes, you can run `npm run openapi` to update Angular services and models as well.

The `swagger.json` file is automatically updated on every backend build (PostBuild event in `DistanceCalculator.API`).

## Backend
The backend of the application is split into two simple projects: `DistanceCalculator.API` and `DistanceCalculator.Core` where the API project contains only the API, and Core the entire business logic.

### Tests
For testing, xUnit and moq libraries are used. There are two types of tests added: Unit and Integration tests.

To run the tests you can use:
- Visual Studio - Run -> Run All Tests
- Console - dotnet test

### Logging
For logging the library serilog is used. All logs are written to a text file and transmitted to a Seq server as well.
