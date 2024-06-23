# .NET 8 Web API with Dapper, Swagger, and JWT Authentication

## Table of Contents

- [Introduction](#introduction)
- [Features](#features)
- [Installation](#installation)
- [Usage](#usage)
- [Configuration](#configuration)
- [License](#license)

## Introduction

This project is a shell of a .NET 8 web API, using Dapper and JWT authentication. It is meant to be used as a tutorial for those seeking to learn more about building an API, or as a jumpstart to creating a new API, with some basic pieces in place.

## Features

- **Swagger Documentation:** Uses a Swagger IOpertaion filter to automatically apply summary text to API endpoints.
- **Automatic Repository Registration:** Automatically registers repositories in the dependency injection container by using an IRepository interface.
- **Controller and Repository Base Classes:** Defines stored procedure naming conventions that simplify basic CRUD operations.
- **Dapper Extension Methods:** Uses Dapper extension methods for stored procedure execution.
- **Repository Class Decorators:** Uses custom class decorators to supply the model name and plural name to the repository.
- **JWT Authentication:** Includes the basic pieces needed to implement JWT authentication.

## Installation

```bash
# Clone the repository
git clone https://github.com/trevorgford/api-quickstart.git

# Navigate to the project directory
cd api-quickstart

# Install dependencies
dotnet add package Microsoft.Data.SqlClient
dotnet add package Dapper
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add package Scrutor
dotnet add package Swashbuckle.AspNetCore.Annotations
```

## Usage

```bash
# Build the API
dotnet build

# Run the API
dotnet run
```

## Configuration

- **appsettings.json:** 
    - Replace "MyConnectionString" with actual connection string
    - Define JWT SecretKey, Issuer, and Audience
- **appsettings.Development.json:**
    - Replace Kestrel URL and port number
- **Program.cs:**
    - Configure CORS with the origins you wish to allow
    - Replace Swagger title and version with desired values
    - Configure Kestrel ports
- **api.http:**
    - Change @api_HostAddress value
- **.editorconfig:**
    - Add/Remove/Modify desired code stylings
- **dapper/DapperContext.cs:**
    - Change connection string name

## License

This project is licensed under the MIT License - see the LICENSE file for details.