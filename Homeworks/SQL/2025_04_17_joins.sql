/* 
TASK 1:
Roles cədvəli: Id, Name 
Users cədvəli: Id, Username, Password

Users cədvəli ilə Roles cədvəli arasında relation qurun (Lazim olan column-u ozunuz elave edin).
Hər userin 1 rolu ola bilər. (Misal: Admin, Moderator ve s.).
Her Userin mutleq Role-u olmalidir.
Usersleri rollari ile bir yerde cixaran sorgu yazin.
*/

--Creating Database
USE master;
DROP DATABASE JOINS;

CREATE DATABASE JOINS;

USE JOINS;


--Creating Roles
CREATE TABLE Roles (
	Id INT IDENTITY PRIMARY KEY,
	[Name] VARCHAR(20),
);

INSERT INTO Roles
VALUES ('Admin'), ('Moderator'), ('User')


--Creating Users
CREATE TABLE Users (
	Id INT IDENTITY PRIMARY KEY,
	Username VARCHAR(20),
	[Password] VARCHAR(20),
);

INSERT INTO Users
VALUES 
('p1','p1-pass', 1),
('p2','p2-pass', 2), 
('p3','p3-pass', 3)

ALTER TABLE Users
ADD RoleId INT NOT NULL;

ALTER TABLE Users
ADD CONSTRAINT FK_USERS_ROLES 
FOREIGN KEY (RoleId) REFERENCES Roles(Id);

SELECT * FROM Users AS u
INNER JOIN Roles AS r
ON u.RoleId = r.Id;

/*
TASK 2:
Products cədvəli: Id, Name, Price, Cost
Categories cədvəli: Id, Name
Sizes cədvəli: Id, Name

Productun yalniz bir Category-i ola biler. Bir mehsulun bir nece sizes(ölçüleri) ola biler ve 
bir size bir nece mehsula aid ola bilir(Relationlari duzgun qurun). Butun mehsullari Size adlari 
ve Categori adlari ile bir yerde qaytaran sorgu yazirsiz . Category adlari Category Name, Color 
adlari Color Name sheklinde cixsin.
*/