/* Procedures - Relations */

USE UsersAwards
GO

-- AddRelation
-- RemoveRelation
-- UnAssignAward - from all users
-- GetUserAwardsIds



/* Add Relation */
IF OBJECT_ID(N'dbo.AddRelation') IS NOT NULL
  DROP PROCEDURE AddRelation;
GO

CREATE PROCEDURE AddRelation(
	@userId int,
	@awardId int)
AS
BEGIN
	INSERT INTO Relations
	VALUES(@userId, @awardId)
END
GO



/* Remove Relation */
IF OBJECT_ID(N'dbo.RemoveRelation') IS NOT NULL
  DROP PROCEDURE RemoveRelation;
GO

CREATE PROCEDURE RemoveRelation(
	@userId int,
	@awardId int)
AS
BEGIN
	Delete from dbo.Relations
	where UserId = @userId and AwardId = @awardId
END
GO



/* UnAssign Award - from all users */
IF OBJECT_ID(N'dbo.UnAssignAward') IS NOT NULL
  DROP PROCEDURE UnAssignAward;
GO

CREATE PROCEDURE UnAssignAward(
	@id int)
AS
BEGIN
	DELETE FROM dbo.Relations
	WHERE @id = AwardId
END
GO



/* Get User Awards Ids */
IF OBJECT_ID(N'dbo.GetUserAwardsIds') IS NOT NULL
  DROP PROCEDURE GetUserAwardsIds;
GO

CREATE PROCEDURE GetUserAwardsIds(
  @userId INT)
AS
BEGIN
  SELECT r.AwardId
    FROM Relations r
    WHERE r.UserId = @userId;
END
GO



/* tests */
EXEC AddRelation @userId = 4, @awardId = 1;
EXEC AddRelation 4, 3;

EXEC UnAssignAward 170;


EXEC GetUserAwardsIds 1;