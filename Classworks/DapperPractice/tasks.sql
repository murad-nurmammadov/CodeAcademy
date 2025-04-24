USE master;
DROP DATABASE Tasks;

CREATE DATABASE Tasks;
USE Tasks;

CREATE TABLE Items
(
	Id int IDENTITY PRIMARY KEY,
	Title nvarchar(100) DEFAULT 'New Task',
	IsCompleted bit DEFAULT 0,
);
