USE master;
DROP DATABASE [Library];

--Create database
CREATE DATABASE [Library];
USE [Library];

--Create tables
CREATE TABLE Authors
(
	Id int IDENTITY PRIMARY KEY,
	FirstName nvarchar(15),
	LastName nvarchar(20),
);

CREATE TABLE Books
(
	Id int IDENTITY PRIMARY KEY,
	Title nvarchar(15),
	ISBN varchar(14) DEFAULT '0000000000000' UNIQUE,
	PublicationYear int CHECK(PublicationYear BETWEEN 0 AND 2023),
	AuthorId int REFERENCES Authors(Id),
);

CREATE TABLE Borrowers
(
	Id int IDENTITY PRIMARY KEY,
	FirstName nvarchar(15),
	LastName nvarchar(20) DEFAULT 'XXX',
	Email varchar(50),
);

CREATE TABLE Checkouts
(
	Id int IDENTITY PRIMARY KEY,
	CheckoutDate datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
	ReturnDate datetime CHECK(ReturnDate > CURRENT_TIMESTAMP) DEFAULT NULL,
	BorrowerId int REFERENCES Borrowers(Id),
	BookId int REFERENCES Books(Id),
);

--Insert data
INSERT INTO Authors VALUES
('name-1', 'surname-1'),
('name-2', 'surname-2'),
('name-3', 'surname-3');

INSERT INTO Books VALUES
('title-1', '001', 2019, 1),
('title-2', '002', 2019, 1),
('title-3', '003', 2019, 2),
('title-4', '004', 2019, 2),
('title-5', '005', 2019, 3);

INSERT INTO Borrowers VALUES
('b_name-1', 'b_surname-1', 'b_email_1'),
('b_name-2', 'b_surname-2', 'b_email_2'),
('b_name-3', 'b_surname-3', 'b_email_3'),
('b_name-4', 'b_surname-4', 'b_email_4');

INSERT INTO Checkouts (BorrowerId, BookId) VALUES
(1, 1), (1, 2),
(2, 2), (2, 3),
(3, 3), (3, 4),
(4, 4), (4, 1), (4, 2);

--Queries
CREATE VIEW vw_CheckedOutBooks AS
SELECT 
	Books.Title as Book, 
	a.FirstName + a.LastName AS FullName,
	Borrowers.Id as Borrower,
	c.CheckOutDate,
	c.ReturnDate
FROM Checkouts AS c
	JOIN Borrowers
	ON c.BorrowerId = Borrowers.Id
	JOIN Books
	ON c.BookId = Books.Id
	JOIN Authors AS a
	ON Books.AuthorId = a.Id;
