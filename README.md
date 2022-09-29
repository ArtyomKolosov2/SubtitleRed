# Subtitle Red

Subtitle Red is a web application, that contains CRUD for the basic localization models.

`Scene [guid, name]`
`Section [guid, name]`
`Line [guid, speaker, text]`

## Features

- Test data is loaded on a startup into database from json file.
- API endpoints are accessiable for a preview via Swagger.
- Project covered with integration tests.
- API can be accessed only with valid JWT token.
- Use of functional programming principles to secure domain from unapropriate use.

## Tech

- .NET 6
- C# 10
- ASP.NET Core - Web application framework.
- Entity Framework Core - Database manipulations.
- MediatR - Simple libiriary that facilitates CQRS and Mediator patterns in .NET.
- Microsoft Identiy - Authentication and authorization functionality.
- Swagger - API Documentation & Design Tools.
- Flurl - Light and easy to use Http request libriary
- Mapster - Fast and efficient mapping.
- xUnit & FluentAssertions - test exectuion & assertions
- MS-SQL - database managment system

And of course SubtitleRed code is on a [public repository](https://github.com/ArtyomKolosov2/SubtitleRed) on GitHub.

## Startup

**To start the application you should have a .NET 6 runtime & MS-SQL (except integration tests start) installed on your machine** 

- Build the solution `dotnet build [<SOLUTION>]`
- Go to folder with the results of the build
- Use `dotnet SubtitleRed.dll` or find and open `SubtitleRed.exe`
- If application is hosted on a local machine use `https://localhost:5001/swagger/index.html` to navigate to swagger

## Q&A

> How did you find the exercise? 
* It was an interesting assignment. I met some difficulties when implementing links for models, but I was able to successfully cope with them.  I would say that the task itself is simple and I spent most of my time on high-quality implementation of the project
>The approximate amount of hours you spent on this task
* ~22 Hours (Development + Testing + Bug fixes)
>Any external resources used/included in the project
* Libriaries and technologies used in project mentioned above at Tech section
>Any info on how to use the features developed in this task that you think we should be aware of
* No any


## Screenshots of Swagger UI

![image](https://user-images.githubusercontent.com/62713674/193228467-87bbb1b3-14ac-41d8-908b-833ceaa4a951.png)


![image](https://user-images.githubusercontent.com/62713674/193228693-1a186d3a-7096-4ae1-9a33-ac9e7ebe23ac.png)

