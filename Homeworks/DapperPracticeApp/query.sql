USE master;
DROP DATABASE DapperPractice;

CREATE DATABASE DapperPractice;
USE DapperPractice;

-- CREATE TABLES
CREATE TABLE Categories
(
	Id int IDENTITY PRIMARY KEY,
	--Name nvarchar(30) UNIQUE NOT NULL,
	Name nvarchar(30) NOT NULL,
);

CREATE TABLE Products
(
	Id int IDENTITY PRIMARY KEY,
	--Name nvarchar(30) UNIQUE NOT NULL,
	Name nvarchar(30) NOT NULL,
	Price decimal NOT NULL,
	CategoryId int REFERENCES Categories(Id),
);

--SELECT * FROM Products;
--SELECT * FROM Categories;
