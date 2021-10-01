create database Lab15_2;
use Lab15_2;



create table Genre(

Name varchar(15) not null,

primary key (Name)

);

insert into Genre (Name) values('horror');
insert into Genre (Name) values('action');
insert into Genre (Name) values('thriller');
insert into Genre (Name) values('comedy');
insert into Genre (Name) values('drama');
insert into Genre (Name) values('other');


create table Movies (

ID int auto_increment not null,
Name varchar(50) not null unique,
Genre varchar(50) not null,
Director varchar(50),
Rating varchar(5),
Year int,

primary key (ID), foreign key (Genre) references Genre(Name)

);

insert into movies (Name,Genre) values('the null pointer','thriller');
insert into movies (Name,Genre) values('return of the null pointer','thriller');
insert into movies (Name,Genre) values('the debugging','horror');
insert into movies (Name,Genre) values('see sharp','action');
insert into movies (Name,Genre) values('see sharper','action');
insert into movies (Name,Genre) values('sharpest sight','action');
insert into movies (Name,Genre) values('an out of bounds exception','comedy');
insert into movies (Name,Genre) values('trycatch','drama');
insert into movies (Name,Genre) values('the Object','other');
insert into movies (Name,Genre) values('404','thriller');
insert into movies (Name,Genre) values('the hexed decimal','horror');
insert into movies (Name,Genre) values('void: a return','other');


