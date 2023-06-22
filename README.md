# Univent-BE
[![.NET Core Build Configuration](https://github.com/LukeX19/univent-be/actions/workflows/dotnet-build-config.yml/badge.svg)](https://github.com/LukeX19/univent-be/actions/workflows/dotnet-build-config.yml)

## Short Description
This application serves as a virtual space where students enrolled in multiple universities can create public events, sign as participants to events created by other users and send ratings for other users after an event has completed successfully.
This repository consists of the server project only. [The client project can be found here](https://github.com/LukeX19/univent-fe)

## Technologies used
- ASP.NET Core, with Entity Framework, version 6 
- Microsoft SQL Server 2019

## Prerequisites
### Setup
- Install [.NET Core SDK](https://dotnet.microsoft.com/en-us/download)
- Install [Entity Framework](https://learn.microsoft.com/en-us/ef/core/get-started/overview/install) by running `dotnet tool install --global dotnet-ef`
- Install [Microsoft SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- Build the project with `dotnet build`
- Run `dotnet ef database update` to create the local database

### Alternative Option
Use Microsoft Visual Studio Community Edition IDE with the following workloads:
- .NET desktop development
- ASP.NET and web development
- Data storage and processing

## Execution
To run the application, use `dotnet run`
