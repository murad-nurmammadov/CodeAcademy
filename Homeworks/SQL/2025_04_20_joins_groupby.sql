--CREATE DATABASE

USE master;
DROP DATABASE Management;

CREATE DATABASE Management;
USE Management;


--CREATE TABLES AND INSERT DATA

--İşçi: (SAA, VəzifəId, Maaş)
CREATE TABLE Workers
(
	ID int IDENTITY PRIMARY KEY,
	FirstName varchar(15),
	LastName varchar(20),
	FatherName varchar(15),
	PositionID int,
);

INSERT INTO Workers VALUES
('name-1', 'surname-1', 'father-1', 1),
('name-2', 'surname-2', 'father-2', 1),
('name-3', 'surname-3', 'father-3', 1);

--Vəzifə: (Ad)
CREATE TABLE Positions
(
	ID int IDENTITY PRIMARY KEY,
	[Name] varchar(40),
);

INSERT INTO Positions VALUES
('position-1'),
('position-2'),
('position-3');

--Filial: (Ad)
CREATE TABLE Branches
(
	ID int IDENTITY PRIMARY KEY,
	[Name] varchar(30),
);

INSERT INTO Branches VALUES
('branch-1'),
('branch-2');

--Məhsul: (Ad, Alış qiyməti, Satış qiyməti)
CREATE TABLE Products
(
	ID int IDENTITY PRIMARY KEY,
	[Name] varchar(30),
	CostPrice decimal,
	SellPrice decimal,
);

INSERT INTO Products VALUES
('product-1', 14.25, 19.99),
('product-2', 14.25, 19.99),
('product-3', 14.25, 19.99),
('product-4', 14.25, 19.99),
('product-5', 14.25, 19.99);


--Satış: (MəhsulId, İşçiId, FilialId, Satış tarixi)
CREATE TABLE Checkouts
(
	ID int IDENTITY PRIMARY KEY,
	ProductID int REFERENCES Products(ID),
	WorkerID int REFERENCES Workers(ID),
	BranchID int REFERENCES Branches(ID),
	[Date] datetime DEFAULT CURRENT_TIMESTAMP,
);

INSERT INTO Checkouts (ProductID, WorkerID, BranchID) VALUES
(1, 1, 1),
(1, 1, 2),
(2, 1, 1),
(2, 2, 2),
(2, 2, 1),
(3, 2, 2),
(4, 3, 1),
(5, 3, 2),
(5, 3, 1);


--QUERIES

--1) Satış cədvəlində işçilərin , satılan məhsulların, satışın olduğu filialın, məhsulun alış və satış qiyməti yazılsın.
SELECT
	w.FirstName + w.LastName AS FullName,
	p.[Name] AS [Product],
	b.[Name] AS Branch,
	p.CostPrice AS [Cost Price],
	p.SellPrice AS [Sell Price]
FROM Checkouts AS c
	JOIN Workers AS w
	ON c.WorkerID = w.ID
	JOIN ProductS AS p
	ON c.ProductID = p.ID
	JOIN Branches AS b
	ON c.BranchID = b.ID;

--2) Bütün satışların cəmini tap.
SELECT 
	SUM(p.SellPrice) AS Total
FROM Checkouts AS c
	JOIN Products AS p
	ON c.ProductID = p.ID;

--3) Cari ayda məhsul satışından gələn yekun məbləği tap
SELECT 
	SUM(p.SellPrice) AS Total
FROM Checkouts AS c
	JOIN Products AS p
	ON c.ProductID = p.ID
WHERE DATETRUNC(month, c.[Date]) = DATETRUNC(month, CURRENT_TIMESTAMP);

--4) Hər işçinin satdığı məhsul sayını tap
SELECT 
	WorkerID,
	COUNT(c.ProductID) AS [Products Sold]
FROM Checkouts AS c
GROUP BY WorkerID;

--5) Bu gün üzrə ən çox məhsul satılan filialı tap.
SELECT *
FROM Checkouts AS c;

SELECT TOP 1
	BranchID,
	COUNT(ProductID) AS [Products Sold]
FROM Checkouts AS c
GROUP BY BranchID
ORDER BY [Products Sold] DESC;

--6) Cari ayda ən çox satılan məhsulu tap.
SELECT TOP 1
	c.ProductID,
	COUNT(ProductID) AS [Products Sold]
FROM Checkouts AS c
WHERE DATETRUNC(month, c.[Date]) = DATETRUNC(month, CURRENT_TIMESTAMP)
GROUP BY c.ProductID
ORDER BY [Products Sold] DESC;
