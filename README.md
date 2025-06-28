#  Employee Management System

## This is the basic complete application build with asp.net and SQL server database.
Its features are :
- User registeration and Login.
- Crud operation for employee data.
- Stored Procedured integration.
- Razer Pages UI.
- Error handling and input validation.
- Clean architecture.
  
## Technololgies Used:
- ASP.NET Core
- SQL Server
- Entity Framework Core

## Database Used:
Tables:
- `UsersDb`
- `EmployeeDb`

Stored Procedures:
- `spUserRegisteration`, `spUserLogin`
- `spAddEmployee`, `spGetAllEmployee`, `spGetEmployeeById`, `spEditEmployee`, `spDeleteEmployee`

## Layers Used:

1. Presentation Layer (MVC):
- Controllers handle HTTP requests and coordinate with the repository.
- Views (Razor pages) display the UI for login, registration, and employee management.

2. Business Layer (Repository Pattern):
- Interfaces (`IEmployeeRepository`, `IAuthRepository`) define contracts for operations.
- Implementations (`EmployeeRepository`, `AuthRepository`) handle business logic and interact with the database using stored procedures.

3. Data Access Layer:
- Uses Entity Framework Core to execute stored procedures in SQL Server.
- Stored procedures handle:
    - User registration and login 
    - Employee CRUD operations
    
## Setup Instructions:
1. Create a database named `EmployeeManagementDb` in SQL Server.
2. Run the provided SQL script `EmployeeManagementScriptTables.sql` to create tables and  `EmployeeManagementStoredProcedure.sql` to create stored procedures.
3. Open the solution file `EmployeeManagementSystem.sln` in Visual Studio.
4. Update the connection string in `appsettings.json`.
5. Build and run the project.
