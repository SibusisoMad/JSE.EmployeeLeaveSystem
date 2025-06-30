JSE.EmployeeLeaveSystem
An internal leave application system that allows employees to submit leave requests and managers to review, approve, or reject those requests.
The system consits of backend API and a user-friendly MVC frontend.


- **Employees** can apply for leave (annual, sick, etc.), view their request history, and retract or edit pending requests.
- **Managers** can view requests from their direct subordinates, approve or reject them with comments.
- Leave calculations **exclude weekends and public holidays**, ensuring accurate leave tracking.
- Secure authentication using **JWT**, with sessions managing roles and user IDs on the MVC side.


Tech Stack

### Backend: JSE.EmployeeLeaveSystem.Api:
- **.NET 8 Web API**
- **ASP.NET Core**
- **Entity Framework Core**
- **JWT Authentication**
- **SQL Server**
- **AutoMapper**
- **Dependency Injection**

- ### Frontend : JSE.EmployeeLeaveSystem.Mvc
- **ASP.NET MVC 5**
- **Razor Views**
- **Session-based state**
- **HttpClient for API calls**
- **Bootstrap (for UI styling)**


### Configuration Steps
1. Database Setup
SQL Server must be installed and running.
Update appsettings.json in JSE.EmployeeLeaveSystem.Api with your connection string:
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=EmployeeLeaveDB;Trusted_Connection=True;TrustServerCertificate=True;"
}


Run EF Core migrations from terminal 
cd JSE.EmployeeLeaveSystem.Api
dotnet ef database update

### JWT Configuration
In appsettings.json (API project):

"JwtSettings": {
  "SecretKey": "YourSuperSecretKey123!",
  "Issuer": "JSE.EmployeeLeaveSystem",
  "Audience": "JSE.EmployeeLeaveSystemUsers",
  "ExpiryMinutes": 60
}


 # MVC Web.config API URL
In JSE.EmployeeLeaveSystem.Mvc/Helpers/ApiService.cs update:
private readonly string _baseUrl = "https://localhost:7264/api";


 ## Getting to run Application Locally
 
Prerequisites
.NET 8 SDK
Visual Studio 2022+ (with ASP.NET and .NET SDK support)
SQL Server or SQL Server Express


## Step 1: Clone the repository
git clone https://your-repo-url/JSE.EmployeeLeaveSystem.git
cd JSE.EmployeeLeaveSystem

## Step 2: Build the solution
Open JSE.EmployeeLeaveSystem.sln in Visual Studio and build all projects.

## Step 3: Set Startup Projects
In Visual Studio:
Right-click the solution → Set Startup Projects → Select Multiple startup projects
JSE.EmployeeLeaveSystem.Api → Start
JSE.EmployeeLeaveSystem.Mvc → Start

## Login Details
Email is used as username
Employee Number as password


## Features
Employee login
Submit leave request
View leave history
Edit/retract pending leave
Manager login
 View subordinate requests
 Approve/Reject with comments
 Role-based access control


![image](https://github.com/user-attachments/assets/26a658f7-86f3-42e3-ad92-0c4d77d1d834)



![image](https://github.com/user-attachments/assets/bdbea083-5ae1-4a29-ad78-3a718a31c033)
