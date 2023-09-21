CREATE DATABASE TaskManagerDB;

USE TaskManagerDB;

CREATE TABLE Processes
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100),
    CpuUsage NVARCHAR(50),
    MemoryUsage NVARCHAR(50)
);


insert into Processes (Name, CpuUsage, MemoryUsage) values ('Chrome', '2334', '28');
insert into Processes (Name, CpuUsage, MemoryUsage) values ('SqlServer', '1245', '1417');
select * from Processes