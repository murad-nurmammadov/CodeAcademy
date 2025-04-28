USE master;
DROP DATABASE MVC_Practice_1;

CREATE DATABASE MVC_Practice_1;
USE MVC_Practice_1;

CREATE TABLE Categories
(
	Id int IDENTITY PRIMARY KEY,
	Name nvarchar(30) NOT NULL,
);

CREATE TABLE Products
(
	Id int IDENTITY PRIMARY KEY,
	Name nvarchar(30) NOT NULL,
	Price decimal NOT NULL,
	CategoryId int REFERENCES Categories(Id),
);
