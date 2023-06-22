# Univent
[![.NET Core Build Configuration](https://github.com/LukeX19/univent-be/actions/workflows/dotnet-build-config.yml/badge.svg)](https://github.com/LukeX19/univent-be/actions/workflows/dotnet-build-config.yml)

## Short Description
This application serves as a virtual space where students enrolled in multiple universities can create public events, sign to events created by other users as participants and send ratings for other users after an event has completed successfully.

## Technologies used
- ASP.NET Core, version 6
- Microsoft SQL Server

## Prerequisites
### Setup
- Install [.NET Core SDK](https://dotnet.microsoft.com/en-us/download), version 6
- Run `dotnet tool install --global dotnet-ef`
- Install [Entity Framework](https://learn.microsoft.com/en-us/ef/core/get-started/overview/install), version 6
- Install [Microsoft SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- Build the project with `dotnet build`
- Run `dotnet ef database update` to create the local database

### Execution
To run the application, use `dotnet run`

## Alternative Option
Use Microsoft Visual Studio Community Edition IDE with the following workloads:
- .NET desktop development
- ASP.NET and web development
- Data storage and processing
