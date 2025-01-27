CREATE TABLE Roles 
(
	Id int not null identity primary key,
	RoleName nvarchar(20) not null unique
)



IF OBJECT_ID('Users', 'U') is null

			CREATE TABLE Users(
					Id INT IDENTITY (1,1) PRIMARY KEY,
					FirstName NVARCHAR(50) not null,
					LastName NVARCHAR(50) not null,
					Email NVARCHAR(100) not null,
					PhoneNumbe NVARCHAR(15) null
					)

INSERT INTO Users (FirstName, LastName, Email, PhoneNumber) 
VALUES (@FirstName, @LastName, @Email, @PhoneNumber)

SELECT * FROM Users Where Email = ''
CREATE TABLE Projects 
(
id int not null identity primary key,
Name NVARCHAR(150) not null,
Description NVARCHAR(max),
StartDate date not null,
EndDate date,
StatusId int not null,
CustomerId int not null,
UserId int not null
)