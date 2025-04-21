--SPOTIFY

--CREATE DATABASE
USE master;
DROP DATABASE Spotify;

CREATE DATABASE Spotify;
USE Spotify;

--CREATE TABLES

--Roles cədvəli: Type
CREATE TABLE Roles
(
	ID int IDENTITY PRIMARY KEY,
	[Name] varchar(15),
);

INSERT INTO Roles Values
('admin'),
('user');

--Users cədvəli: Name, Surname, Username, Password, Gender
CREATE TABLE Users
(
	ID int IDENTITY PRIMARY KEY,
	[Name] varchar(15),
	Surname varchar(20),
	Username varchar(20),
	Password varchar(21) CHECK (LEN(Password) > 8),
	Gender char(1) CHECK(Gender IN ('m', 'f')),
	RoleID int REFERENCES Roles(ID),
);

INSERT INTO Users VALUES
('name-1', 'surname-1', 'username-1', 'password-1', 'm', 1),
('name-2', 'surname-2', 'username-2', 'password-2', 'm', 2),
('name-3', 'surname-3', 'username-3', 'password-3', 'f', 2),
('name-4', 'surname-4', 'username-4', 'password-4', 'f', 2);

--Artists cədvəli: Name, Surname, Birthday, Gender
CREATE TABLE Artists
(
	ID int IDENTITY PRIMARY KEY,
	[Name] varchar(15),
	Surname varchar(20),
	Birthday date CHECK(Birthday < GetDate()),
	Gender char(1) CHECK(Gender IN ('m', 'f')),
);

INSERT INTO Artists VALUES
('name-1', 'surname-1', '2001-02-22', 'm'),
('name-2', 'surname-2', '1995-11-03', 'm');

--Categories cədvəli: Name
CREATE TABLE Categories
(
	ID int IDENTITY PRIMARY KEY,
	[Name] varchar(15),
);

INSERT INTO Categories VALUES
('pop'),
('jazz');

--Musics cədvəli: Name, Duration
CREATE TABLE Musics
(
	ID int IDENTITY PRIMARY KEY,
	[Name] varchar(20),
	Duration int,  --in seconds
	CategoryID int REFERENCES Categories(ID),
	ArtistID int REFERENCES Artists(ID)
);

INSERT INTO Musics VALUES
('music-1', 155, 1, 1),
('music-2', 162, 2, 1),
('music-3', 131, 1, 2),
('music-4', 124, 2, 2),
('music-5', 124, 2, 2);


/*
İstifadəçi özünə playlist yaradıb həmin playlistə mahnılar əlavə edə biləcək.
Hər mahnı 1 kateqoriyaya aid ola bilər.
*/
CREATE TABLE Playlists
(
	ID int IDENTITY PRIMARY KEY,
	[Name] varchar(30),
	UserID int REFERENCES Users(ID),
	MusicID int REFERENCES Musics(ID),
);
INSERT INTO Playlists VALUES
('playlist-1', 1, 1),
('playlist-2', 1, 3),
('playlist-3', 2, 2),
('playlist-4', 2, 4);

--QUERIES

--1. Mahnını adını,	 uzunluğunu, kateqoriyasını, hansı ifaçı tərəfindən oxunulduğunu bildirən sorğunu özündə saxlayan uptadeable view yazın


--2. Verilmiş istifadəçinin playlistinə əlavə etdiyi mahnıların siyahısını çıxarın


--3. Mahnıları uzunluğuna görə sıralayın
SELECT
	[Name],
	Duration
FROM Musics
ORDER BY Duration DESC;

--4. Saytda ən çox mahnı çıxaran ifaçını(ları) seçin
SELECT 
	ArtistID,
	Count(ID) AS [Music Count]
FROM Musics
GROUP BY ArtistID
ORDER BY [Music Count] DESC;
