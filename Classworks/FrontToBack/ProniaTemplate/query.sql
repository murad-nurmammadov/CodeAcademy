USE master;
DROP DATABASE ProniaDB;

CREATE DATABASE ProniaDB;
USE ProniaDB;

CREATE TABLE Sliders
(
	Id int IDENTITY PRIMARY KEY,
	Title nvarchar(64) NOT NULL,
	Description nvarchar(256) NOT NULL,
	Price decimal(5,2) CHECK (Price > 0),
	ImagePath nvarchar(256) NOT NULL,
);
