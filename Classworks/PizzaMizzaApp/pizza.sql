USE master;
DROP DATABASE PizzaMizza;

CREATE DATABASE PizzaMizza;
USE PizzaMizza;

--Many-to-many relationship between pizzas and ingredients
CREATE TABLE Pizzas
(
	Id int IDENTITY PRIMARY KEY,
	Name nvarchar(20) NOT NULL,
	Price DECIMAL(4,2),
);

CREATE TABLE Ingredients
(
	Id int IDENTITY PRIMARY KEY,
	Name nvarchar(20) NOT NULL,
);

CREATE TABLE PizzaIngredients
(
	PizzaId int REFERENCES Pizzas(Id),
	IngredientId int REFERENCES Ingredients(Id),
	PRIMARY KEY (PizzaId, IngredientId),
);

INSERT INTO Pizzas VALUES 
('pizza-1', 12.45),
('pizza-2', 12.45),
('pizza-3', 12.45),
('pizza-4', 12.45);

INSERT INTO Ingredients VALUES
('ingredient-1'),
('ingredient-2'),
('ingredient-3'),
('ingredient-4');
