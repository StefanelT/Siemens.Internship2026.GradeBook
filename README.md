## Siemens.Internship2026.GradeBook - Internship Problem

ASP.NET Core Web API project developed as part of the **.NET Developer Trainee @ Siemens** internship application process.



## 📄 Documentation

A detailed PDF document is attached in this repository (`Internship Problem - TudorAdrianRaulStefanel.pdf`) describing all the changes made, including:
- SOLID principle violations identified and fixed
- .NET upgrade details
- Service layer implementation
- Repository refactoring


## ✅ What was done

### I. SOLID Principles
Two violations were identified and fixed:

**SRP – Single Responsibility Principle**
The controller was responsible for both handling HTTP requests and performing business logic (filtering grades, computing statistics). The business logic was extracted into a dedicated service layer (`ItemService`).

**DIP – Dependency Inversion Principle**
The controller was using `Console.WriteLine()` directly. Fixed by using `ILogger<ItemController>` and replacing `Console.WriteLine()` with `_logger.LogInformation/LogWarning`.

### II. .NET Upgrade
Upgraded the project from **.NET 8** to **.NET 10** by changing the `TargetFramework` in the `.csproj` file.

### III. Service Layer
Introduced a service layer (`ItemService`) that encapsulates the business logic. Implemented a filter method `GetFirstNGrades(int n)` that retrieves the first N grades meeting both criteria:
- The grade is a passing grade (value >= 5)
- The grade is active (`IsActive == true`)

### IV. Repository Refactoring
Replaced the in-memory data source with data fetched  from the following external endpoint: 
```
https://gist.githubusercontent.com/ArdeleanTudor/8ea407832cd9794960e0e6bbd1319f6e/raw
```
