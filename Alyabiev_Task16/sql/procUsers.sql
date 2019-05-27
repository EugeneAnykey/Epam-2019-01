/* Procedures - Users */

USE UsersAwards
GO

-- AddUserSimple
-- UpdateUserSimple
-- DeleteUserSimple
-- DeleteUser
-- [x] GetUserIdByName
-- [x] GetUserIdByNameReturn
-- GetUsers

SELECT * FROM Users;

INSERT INTO Users
	VALUES(N'Gregory', N'Wasserman', '1983-12-17');

/* Add User Simple */
IF OBJECT_ID(N'dbo.AddUserSimple') IS NOT NULL
  DROP PROCEDURE AddUserSimple;
GO

CREATE PROCEDURE AddUserSimple(
	@firstName nvarchar(50),
	@surname nvarchar(50),
	@birthdate datetime2)
AS
BEGIN
	INSERT INTO Users
	VALUES(@firstName, @surname, @birthdate)
END
GO



/* Update User Simple */
IF OBJECT_ID(N'dbo.UpdateUserSimple') IS NOT NULL
  DROP PROCEDURE UpdateUserSimple;
GO

CREATE PROCEDURE UpdateUserSimple(
	@firstName NVARCHAR(50),
	@surname NVARCHAR(50),
	@birthdate DATETIME2,
  @Id INT)
AS
BEGIN
  UPDATE dbo.Users
  SET
    FirstName = ISNULL(@firstName, firstname),
    Surname = ISNULL(@surname, surname),
    Birthdate = ISNULL(@birthdate, Birthdate)
	WHERE Id = @Id AND (@firstName IS NOT NULL OR
                    	@surname IS NOT NULL OR
                    	@birthdate IS NOT NULL)
END
GO



/* Delete User Simple */
IF OBJECT_ID(N'dbo.DeleteUserSimple') IS NOT NULL
  DROP PROCEDURE DeleteUserSimple;
GO

CREATE PROCEDURE DeleteUserSimple(
	@Id INT)
AS
BEGIN
  DELETE FROM dbo.Users
  WHERE Id = @Id
END
GO



/* Delete User */
IF OBJECT_ID(N'dbo.DeleteUserWithRels') IS NOT NULL
  DROP PROCEDURE DeleteUserWithRels;
GO

CREATE PROCEDURE DeleteUserWithRels(
	@Id INT)
AS
BEGIN
  DELETE FROM dbo.Users
  WHERE Id = @Id;
  
  DELETE FROM dbo.Relations
  WHERE Relations.UserId = @Id;
END
GO



/* check it */
IF OBJECT_ID(N'dbo.GetUserIdByName') IS NOT NULL
  DROP PROCEDURE GetUserIdByName;
GO

CREATE PROCEDURE GetUserIdByName(
  @firstName nvarchar(50),
	@surname nvarchar(50))
AS
BEGIN
  SET NOCOUNT ON;
  SELECT TOP 1 u.Id
    FROM dbo.users u
    WHERE u.firstname = @firstname AND u.surname = @surname
END
GO



/* check it */
IF OBJECT_ID(N'dbo.GetUserIdByNameReturn') IS NOT NULL
  DROP PROCEDURE GetUserIdByNameReturn;
GO

CREATE PROCEDURE dbo.GetUserIdByNameReturn(
   @firstName nvarchar(50),
	@surname nvarchar(50))
AS
BEGIN
	RETURN (SELECT u.Id
    FROM dbo.users u
    WHERE u.firstname = @firstname AND u.surname = @surname)
END



/* Get Users List */
IF OBJECT_ID(N'dbo.GetUsers') IS NOT NULL
  DROP PROCEDURE GetUsers;
GO

CREATE PROCEDURE dbo.GetUsers
AS
BEGIN
	SELECT Id, FirstName, Surname, Birthdate
    FROM dbo.users
END







EXEC AddUserSimple @firstName = N'Peter'
            ,@surname = N'Black'
            ,@birthdate = '1969-06-09';

EXEC AddUserSimple N'Jenifer', N'Smith', '1998-07-06';



-- error, how to get int?
declare @JeniferId int;
EXEC GetUserIdByName @jeniferid, N'Jenifer', N'Smith';


EXEC UpdateUserSimple @firstName = N'Jennifer'
                     ,@surname = NULL
                     ,@birthdate = NULL
                     ,@Id = GetUserIdByNameReturn;

EXEC UpdateUserSimple @firstName = N'Anthonius'
                     ,@surname = NULL
                     ,@birthdate = NULL
                     ,@Id = 2;

EXEC AddUserSimple N'Jenifer2', N'Smith', '1998-07-06';

EXEC DeleteUserSimple @Id = 7;

EXEC GetUsers;

