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

CREATE TABLE Blogs
(
	Id int IDENTITY PRIMARY KEY,
	Author nvarchar(64) NOT NULL,
	Date date DEFAULT GETDATE(),
	Title nvarchar(64) NOT NULL,
	Description nvarchar(256) NOT NULL,
	ImagePath nvarchar(256) NOT NULL,
);

INSERT INTO Sliders VALUES
('title-1', 'desc-1', 20, '1-5-270x300.jpg'),
('title-2', 'desc-2', 20, '1-6-270x300.jpg'),
('title-3', 'desc-3', 20, '1-7-270x300.jpg');
	
INSERT INTO Blogs (Author, Title, Description, ImagePath) VALUES
('author-1', 'title-1', 'desc-1', '1-1-310x220.jpg'),
('author-2', 'title-2', 'desc-2', '1-2-310x220.jpg'),
('author-3', 'title-3', 'desc-3', '1-3-310x220.jpg');
