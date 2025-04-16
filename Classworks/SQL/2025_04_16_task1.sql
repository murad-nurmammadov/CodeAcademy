CREATE DATABASE BB104;

USE	BB104;

DROP TABLE Employees;

CREATE TABLE Employees (
	Id int identity,
	FullName nvarchar(40) NOT NULL unique,
	Age tinyint CHECK(Age > 0) NOT NULL,
	Email varchar(100) NOT NULL unique,
	Salary decimal CHECK(Salary >= 300 AND Salary <= 2000) NOT NULL,
);

INSERT Employees 
VALUES 
('emp1', 20, 'emp1@gmail.com', '1200'),
('emp2', 20, 'emp2@gmail.com', '1200'),
('emp3', 20, 'emp3@gmail.com', '1200');

UPDATE Employees
SET Email = 'emp1-updated@gmailcom'
WHERE Id = 1;

SELECT * FROM Employees;

SELECT * FROM Employees
WHERE (Salary >= 500 AND Salary <= 2000);

SELECT FullName, Email, Salary FROM Employees
ORDER BY Salary desc;s