USE master
IF (db_id(N'UsersAwards')) IS NOT NULL
	DROP DATABASE UsersAwards

CREATE DATABASE UsersAwards
GO

USE UsersAwards


CREATE TABLE Users(
	[Id] int not null primary key identity(1,1),
	[FirstName] nvarchar(50),
	[Surname] nvarchar(50),
	[Birthdate] datetime2
);

CREATE TABLE Awards(
	[Id] int not null primary key identity(1,1),
	[Title] nvarchar(50),
	[Description] nvarchar(150)
);

CREATE TABLE Relations(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[UserId] INT NOT NULL,
	[AwardId] INT NOT NULL,
	FOREIGN KEY (UserId) REFERENCES Users(Id) ON DELETE CASCADE,
	FOREIGN KEY (AwardId) REFERENCES Awards(Id) ON DELETE CASCADE,
);





/*
  fill
 */

INSERT INTO Users
VALUES
  (N'Jack', N'Jackal', '1987-06-05'),
  (N'Anthony', N'Vagrant', '1992-03-22'),
  (N'Joshua', N'Michigan', '1972-06-12'),
  (N'Billy', N'Hill', '1993-01-17');

Select * from users;

INSERT INTO Awards
VALUES
  (N'test Grade A, prize 1', N'test epic award'),
  (N'test Grade B, prize 1', N'test common award'),
  (N'test Grade B, prize 2', N'test another common award');

Select * from awards;

INSERT INTO Relations
VALUES
  (1, 1),
  (1, 2),
  (2, 2);

Select * from Relations;
