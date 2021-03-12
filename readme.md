# Angular 11 with ASP.Net Core 5 Demo app

## Install

- insall nodejs [download](https://nodejs.org/en/download/)
- install angular
```
npm uninstall -g @angular/cli
npm install -g @angular/cli@11
```
- install .net 5 SDK [download](https://dotnet.microsoft.com/download/dotnet/5.0)

Check if your ports: 5000 and 4200 are not in use. 

The project uses SQL Server's LocalDB, make sure it is available

## Run

If you are on windows call run_windows.bat. If you've installed .net and nodejs the script shall start backend and frontend app, but it takes time to install node modules.

Otherwise run manually:
```
dotnet run --project "projectname"
```
```
cd src/billing-spa
npm install
ng serve -o
```

The backend project needs cors update when you access the backend app from a different port.

When the backend is server from a different port (e.g. using IIS Express) then check the angular app's environment.ts to update the port.

## Manual API test

There is 2 postman json file in the root which you can import to postman and test the api manually wihtout clicking on ui:

- Billing-Api-Demo.postman_collection.json
- Billing-Api-Demo.postman_environment.json