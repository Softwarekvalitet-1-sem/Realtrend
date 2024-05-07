# REALTREND - Readme

### Overview

Welcome to Realtrend, a Blazor Server application designed to get info about BFE numbers in a userfriendly enviroment. This README aims to guide you through the setup, features, and usage of the application.

The application is developed for educational purposes, in the context of PBA Softwaredevelopment, on ULC.

### Table of Contents

1. [Installation](#installation)
2. [Structure](#structure)
3. [Features](#features)
4. [Tests](#tests)
5. [About](#contributing)


## Installation

To run Realtrend locally, follow these steps:

1. **Clone the repository**: 
   ```bash
   git clone https://github.com/Softwarekvalitet-1-sem/Realtrend.git

2. **Navigate to the project directory**: 
   ```bash
   cd Realtrend

3. **Install dependencies**: 
   ```bash
   dotnet restore

4. **Build the project:**: 
   ```bash
   dotnet build

5. **Run the application:**: 
   ```bash
   cd Realtrend
   dotnet run

6. **Use application:**: 
Open your web browser and navigate to https://localhost:5255 to view the application.


## Structure

- **Project Root**
  - `.github`: Workflows for Github Actions
  - `/Realtrend`: Project folder
    - `/Realtrend`: Blazor Web Assemble .NET 7.0
    - `/Realtrend.Library`: Class library .NET 7.0
    - `/Realtrend.UnitTests`: Xunit test project .NET 7.0

## Features

### Addressform
A feature that takes in a address, and convert it to a BFE number.

### Pricecharts
A feature that shows history on price devoleopment for a given BFE number


## Tests

### Methods for development

-  **TestD riven Development**
-  **Data Driven Development**
-  **Behaviour Driven Development**

### Frameworks and tools

-  **Xunit** for unit testing
-  **Bunit** for component testing
-  **Fluentassertations** for test readability and error handling
-  **Moq** for mocking data
-  **Reqnroll** for Gherkin tests

## About

### Contributers

-  **Kasper**
-  **Jens**
-  **Bjarke**