create database SaleDB
use SaleDB
-----
CREATE TABLE Customers
(      
    CustomerID INTEGER PRIMARY KEY IDENTITY(1,1),
    CustomerName VARCHAR(50),
	Phone VARCHAR(50),
    [Address] VARCHAR(150),
	Email VARCHAR(20),
);
GO
CREATE TABLE Orders(
    OrderID INTEGER PRIMARY KEY IDENTITY(101,1),
    CustomerID INTEGER,
    OrderDate DATETIME,
	ProductName varchar(100),
	Price decimal(15,2),
    Quantity INTEGER,
    FOREIGN KEY (CustomerID) REFERENCES Customers (CustomerID),
);
GO
----
/* RESET IDENTITY */ 
DBCC CHECKIDENT ('Customers', RESEED, 0);