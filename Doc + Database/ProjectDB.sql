CREATE database ProjectDB
-----
use ProjectDB
-----
CREATE table tbProject
(
	Id int primary key identity,
	ClientName varchar(50),
	ProjectName varchar(50),
	StartDate datetime,
	EndDate datetime,
	Cost decimal(15,2)
);
