create database lab11_2;
use lab11_2;

#drop database lab11_2;


create table Users (

	UID int auto_increment not null,
    isAdmin bool not null,
	Username varchar(30),
    email varchar(100),
    
    primary key(UID)
);

insert into Users (Username, isAdmin) values ('Admin01', 1);
insert into Users (Username, isAdmin) values ('User01', 0);
insert into Users (Username, isAdmin) values ('User02', 0);
insert into Users (Username, isAdmin) values ('User03', 0);
insert into Users (Username, isAdmin) values ('User04', 0);
insert into Users (Username, isAdmin) values ('User05', 0);


create table Questions (

	ID int auto_increment not null,
	Username varchar(30),
	Title varchar(64) not null,
	Detail tinytext not null,
	Posted datetime not null,
	Category varchar(16),
	Tags varchar(100),
	Status int,

	primary key(ID)
);


create table Answers (

	ID int auto_increment not null,
	Username varchar(30),
	Detail tinytext not null,
	Posted datetime not null,
	QuestionID int,
    
    primary key(ID), foreign key(QuestionID) references Questions(ID)

);