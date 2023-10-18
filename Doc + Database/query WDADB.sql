CREATE DATABASE WDADB
use WDADB
----
create table Book
(
    ISBN int,
    Title varchar(255),
    Author varchar(255),
    Edition int,
	Price decimal (10,2),
    Photo varchar(255)
);
----
select * from Book