/* Procedures - Misc */

USE UsersAwards
GO


-- GetUserAwards
-- AddAwardedUser
-- AlterAwards







/* Get User Awards */
IF OBJECT_ID(N'dbo.GetUserAwards') IS NOT NULL
  DROP PROCEDURE GetUserAwards;
GO

CREATE PROCEDURE GetUserAwards(
	@userId int)
AS
BEGIN
  SELECT a.Id, a.Title, a.Description
    FROM Awards a INNER JOIN Relations r
    ON
    r.UserId = @userId
    WHERE a.Id = r.AwardId
END
GO

/* tests */
EXEC GetUserAwards 1;





/* creating table type for several id */
CREATE TYPE AwardsIds AS TABLE(id int);
GO


/* Add Awarded User */
IF OBJECT_ID(N'dbo.AddAwardedUser') IS NOT NULL
  DROP PROCEDURE AddAwardedUser;
GO

CREATE PROCEDURE AddAwardedUser(
	@firstName nvarchar(50),
	@surname nvarchar(50),
	@birthdate datetime2,
	@awardIds AwardsIds readonly)
AS
BEGIN
	DECLARE @userId AS TABLE(id int);

	INSERT INTO Users
	OUTPUT Inserted.Id INTO @userId
	VALUES(@firstName, @surname, @birthdate);

	INSERT INTO Relations
	SELECT [@userId].id, [@awardIds].id FROM @awardIds, @userId;
END



/* Alter Awards */

IF OBJECT_ID(N'dbo.AlterAwards') IS NOT NULL
  DROP PROCEDURE AlterAwards;
GO

CREATE PROCEDURE AlterAwards(
	@userId int,
	@awardIds AwardsIds readonly)
AS
BEGIN
	DELETE FROM Relations
	WHERE @userId = UserId;

	INSERT INTO Relations
	SELECT @userId, id FROM @awardIds;
END






DECLARE @userAwardsIds AS AwardsIds;
INSERT INTO @userAwardsIds
  VALUES (1), (3);

/* test */
EXEC AddAwardedUser  @firstName = N'Some'
                    ,@surname = N'Person'
                    ,@birthdate = '2001-04-24'
                    ,@awardIds = @userAwardsIds;


/*
EXEC AddUser @firstName = N'Another'
            ,@surname = N'Guy'
            ,@birthdate = '1987-11-02'
            ,@awardIds = SELECT 1;
*/

