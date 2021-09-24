create database lab11_2;
use lab11_2;

#drop database lab11_2;


create table Users (

	UID int auto_increment not null,
    isAdmin bool not null,
	Username varchar(30) unique,
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
    QuestionID int,
	Username varchar(30),
	Detail tinytext not null,
	Posted datetime not null,
    Upvotes int,
	
    
    primary key(ID), foreign key(QuestionID) references Questions(ID)

);
Alter table Answers add foreign key (Username) references Users(Username);

insert into Answers (QuestionID, Username, Detail, Posted, Upvotes) values ('25', 'User03','Do this and not that','2021-09-23 19:40:58',3);
insert into Answers (QuestionID, Username, Detail, Posted, Upvotes) values ('25', 'User02','Do this and not that','2021-09-23 19:40:58',2);
insert into Answers (QuestionID, Username, Detail, Posted, Upvotes) values ('25', 'User01','Do this and not that','2021-09-23 19:40:58',-1);
insert into Answers (QuestionID, Username, Detail, Posted, Upvotes) values ('25', 'User05','Do this and not that','2021-09-23 19:40:58',0);
insert into Answers (QuestionID, Username, Detail, Posted, Upvotes) values ('26', 'User03','Do this and not that','2021-09-23 19:40:58',1);
insert into Answers (QuestionID, Username, Detail, Posted, Upvotes) values ('26', 'User02','Do this and not that','2021-09-23 19:40:58',2);
insert into Answers (QuestionID, Username, Detail, Posted, Upvotes) values ('26', 'User02','Do this and not that','2021-09-23 19:40:58',5);
insert into Answers (QuestionID, Username, Detail, Posted, Upvotes) values ('26', 'User01','Do this and not that','2021-09-23 19:40:58',-2);




select * from Users;
select * from questions;
select * from answers;

delete from questions where ID > 0;