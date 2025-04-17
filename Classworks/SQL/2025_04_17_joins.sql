--Create database
CREATE DATABASE SalesAnalysis;
USE SalesAnalysis;

--Create tables
CREATE TABLE Customers (
	Id int IDENTITY PRIMARY KEY,
	[Name] nvarchar(25) NOT NULL,
	Email varchar(60) UNIQUE,
	Phone char(10),
);

CREATE TABLE Products (
	Id int IDENTITY PRIMARY KEY,
	[Name] nvarchar(25) NOT NULL,
	Price decimal(5,2) CHECK(Price > 0),
);

CREATE TABLE Orders (
	Id int IDENTITY PRIMARY KEY,
	CustomerId int REFERENCES Customers(Id),
	ProductId int REFERENCES Products(Id),
	ProductQuantity int CHECK(ProductQuantity > 0) DEFAULT 0,
	CreateDate datetime DEFAULT CURRENT_TIMESTAMP,
);

--Insert data
INSERT INTO Customers
VALUES
('customer-1', 'customer-1@gmail.com', '0000000001'),
('customer-2', 'customer-2@gmail.com', '0000000002'),
('customer-3', 'customer-3@gmail.com', '0000000003');

INSERT INTO Products
VALUES
('pr-1', 14.45),
('pr-2', 5.99),
('pr-3', 8.99),
('pr-4', 33.95),
('pr-5', 21.99);

INSERT INTO Orders (CustomerId, ProductId, ProductQuantity)
VALUES
(1, 3, 10),
(1, 3, 10),
(2, 2, 10),
(2, 1, 10),
(3, 1, 10);

--Queries
SELECT * FROM Customers;
SELECT * FROM Products;
SELECT * FROM Orders;

--Task 1 + Create View
CREATE VIEW vw_CustomerSpendings AS
SELECT 
	c.[Name] AS Customer,
	p.[Name] AS Product,
	o.ProductQuantity AS Quantity,
	p.Price,
	o.ProductQuantity * p.Price AS Total
FROM Orders AS o
JOIN Customers AS c
ON o.CustomerId = c.Id
JOIN Products AS p
ON o.ProductId = p.Id;

SELECT * FROM vw_CustomerSpendings;

--Task 2 + Create View
CREATE VIEW vw_SpendingsSummary AS
SELECT 
	CustomerId,
	c.[Name] AS [Customer Name],
	SUM(p.Price * o.ProductQuantity) AS Total
FROM Orders AS o
	JOIN Customers AS c
	ON o.CustomerId = c.Id
	JOIN Products AS p
	ON o.ProductId = p.Id
GROUP BY CustomerId, c.[Name];

SELECT * FROM vw_SpendingsSummary;
