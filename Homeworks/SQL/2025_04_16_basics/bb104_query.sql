/*
BB104 adlı database yaradılır.
Students cədvəli yaradılır, Name, Surname, Age, AvgPoint sütunları yaradılır.
Ad boş ola bilməz, Soyadın default dəyəri 'XXX' olmalıdır. Yaş 18dən az ola bilməz. Avg point tam ədəd olmaya bilər.
Sorğular :
1. Ortalaması 51dən yuxarı olan tələbələri göstərsin
2. Ortalaması 51dən böyük, 90dan az olan tələbələri göstərsin. 
3. A ilə başlayıb i ilə bitən tələbələri göstərsin
*/

CREATE DATABASE BB104;

USE BB104;
CREATE TABLE Students (
	ID int identity,
	[Name] nvarchar(20) NOT NULL,
	Surname nvarchar(30) DEFAULT 'XXX',
	Age tinyint CHECK (Age >= 18),
	AvgPoint float CHECK (AvgPoint >=0 AND AvgPoint <= 100)
);

INSERT INTO Students
VALUES 
('Murad', 'Nurmammadov', 21, 82.5),
('Davud', 'Nurmammadov', 19, 90.5);

INSERT INTO Students ("Name", Age, AvgPoint)
VALUES (N'Ağaəli', 19, 90.5)


SELECT * FROM Students
WHERE AvgPoint > 51;

SELECT * FROM Students
WHERE AvgPoint > 51 AND AvgPoint < 90;

SELECT * FROM Students
WHERE [Name] LIKE 'A%i';


--USE master;
--DROP DATABASE BB104;

