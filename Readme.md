# ContaBancariaDemo — Banking Domain & Automated Tests

A demonstration project that models common **bank account operations** while exploring domain rules, web/API development and automated testing practices in the .NET ecosystem.

## About the project

The application was created as a skills-demonstration project around a banking domain. It supports the management of people and accounts and implements operations commonly found in a basic banking system.

The repository contains both a web application and a REST API, together with a dedicated domain test project.

> **Historical project:** this repository represents an earlier stage of my software engineering journey and is preserved to document the evolution of my experience with .NET, domain modeling and automated testing.

## Implemented features

- Person CRUD
- Bank account CRUD
- Link a person to an account
- Deposits
- Withdrawals
- Account statements
- Account statements filtered by period
- Banking-domain validations

## Testing & BDD

One of the main goals of this project was to practice automated testing around business rules.

The test suite includes **BDD (Behavior-Driven Development) with SpecFlow**, using `.feature` scenarios to describe expected banking behavior in a business-readable format.

Examples include deposit scenarios covering successful operations and validation cases such as zero or negative values.

The test project also references:

- SpecFlow 2.4
- xUnit
- MSTest
- Moq
- DomainValidation

## Tech stack

- C#
- .NET Framework 4.7.2
- ASP.NET
- REST API
- JavaScript
- SQL
- SpecFlow
- xUnit / MSTest
- Moq

## Solution structure

The solution separates application code and automated tests, including a dedicated domain test project:

```text
ContaBancariaDemo.sln
├── src/        # Application projects
├── testes/     # Domain automated tests / SpecFlow scenarios
└── sql/        # Database-related scripts
```

## Running the project

This solution targets an older .NET Framework stack. In a compatible Windows/Visual Studio environment:

1. Clone the repository.
2. Open `ContaBancariaDemo.sln`.
3. Restore NuGet packages.
4. Configure the required database using the scripts/configuration available in the repository.
5. Build the solution.
6. Run the desired web/API project.
7. Use Visual Studio Test Explorer to execute the automated tests.

Modern environments may require compatibility adjustments because the project preserves its original technology versions.

## Project context

Originally created as a practical demonstration of banking-domain implementation and testing. The project is particularly relevant to my development history because it combines business rules with automated tests and BDD scenarios using SpecFlow.

The code has intentionally been kept close to its original implementation so the repository can serve as a historical record of the engineering practices I was studying and applying at the time.

---

**William Figueiredo**  
Software Engineering → AI Engineering
