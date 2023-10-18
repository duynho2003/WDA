create database SchoolDB
---------------------
use SchoolDB
---------
create table Course
(
	code varchar(20) primary key,
	[name] varchar(100),
	duration varchar(20),
	fee decimal(15,2),
	photo varchar(250)
)
-----
select * from Course
-----
insert into Course values('7023-WDA','Web Developing using ASP.NET MVC', '1,5 months', 4560000, 'Images/b1.gif')