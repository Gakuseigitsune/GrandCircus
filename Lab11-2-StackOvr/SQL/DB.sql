create database lab11_2;
use lab11_2;


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