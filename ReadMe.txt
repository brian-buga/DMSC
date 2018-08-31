Project Structure :

DMSC.Assessment.Data : This layer contains the database models, repositorys and Entity Framework DbContext(Code First)
DMSC.Assessment.Test : This layer contains the Unittest, for the this purpose, I only wrote one test article controller.
DMSC.Assessment.Web : This layer contains the UI.

To run :
- Open the project .sln in Visual Studio 2017
- Build and restore any missing nuget packages
- Setup migration
	- run power shell as admin, go to the root directory
	- enter this command . ie cd C:xxxxx\xx\Dmsc.Assessment\DMSC.Assessment.Web
	- then run this command to create the database: dotnet ef database update.

- I've also included the db script
	- Create a database iDMSC2 on MsSql and run the script against it.

I setup seed for three type users : 

- Admin@pressford.com  as an adminstrator of the web site, same right as publisher
- Publisher@pressford.com as a publisher, can publish news article.
- Employee@pressford.com as an employee, can read and like article.

Login credentials and Role.

UserName : Admin@pressford 
Password :123456
Role : Admin

UserName : Publisher@pressford,Publisher1@pressford ,Publisher2@pressford  
Password :123456
Role : Publisher

UserName : Employee@pressford, Employee1@pressford, Employee2@pressford, Employee3@pressford,Employee4@pressford,Employee5@pressford
Password :123456
Role : Employee

Technology.
Aspnet core MVC 2.0, Entity Framework Core, Jquery, Boostrap, Chart.j, xunit.

To Do.

- Add text editor to article form
- Add a Yes/No dialogue to the article delete button action
- Implement the Comment section .




