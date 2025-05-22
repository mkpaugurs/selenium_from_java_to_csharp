# selenium_from_java_to_csharp

## Overview

This repository contains C#/.NET implementations of various Selenium test automation tasks. The work is based on original Java project and demonstrates how to complete those tasks in C# using MSTest and a PageObject pattern. 

## Original Java Repositories

- [KristineK/selenium_java_basic](https://github.com/KristineK/selenium_java_basic) 
- [JanisDzalbe/selenium_java](https://github.com/JanisDzalbe/selenium_java) 

## Technologies Used

- C# / .NET 
- Selenium WebDriver 
- MSTest 
- DotNetSeleniumExtras.PageObjects.Core (alternative to Java's `@FindBy` library) 

## Project Structure

- `Samples/` – Contains sample test cases that can be executed together. 
- `Tasks/` – Contains specific task-based tests, also runnable as a group. 

> ⚠️ Note: Tests in `Samples` and `Tasks` cannot be run together in a single execution. Run each group separately. 

## How to Run Tests

1. Open the project in Visual Studio 2022 or a compatible IDE. 
2. Make sure .NET 8 is installed 
2. Restore all NuGet dependencies. 
3. Build the solution. 
4. Run tests using: 
   - Visual Studio Test Explorer, or 
   - Command line: `dotnet test` 

## Author

**Marcis Kalnins**
