/* Procedures - Awards */

USE UsersAwards
GO

-- AddAward
-- UpdateAward
-- DeleteAward
-- GetAwards


/* Add Award */
IF OBJECT_ID(N'dbo.AddAward') IS NOT NULL
  DROP PROCEDURE AddAward;
GO

CREATE PROCEDURE AddAward(
	@title nvarchar(50),
	@description nvarchar(150))
AS
BEGIN
	INSERT INTO Awards
	VALUES(@title, @description)
END
GO



/* Update Award */
IF OBJECT_ID(N'dbo.UpdateAward') IS NOT NULL
  DROP PROCEDURE UpdateAward;
GO

CREATE PROCEDURE UpdateAward(
	@title NVARCHAR(50),
	@description NVARCHAR(50),
  @Id INT)
AS
BEGIN
  UPDATE dbo.Awards
  SET
    Title = ISNULL(@title, Title),
    Description = ISNULL(@description, Description)
	WHERE Id = @Id AND (@title IS NOT NULL)
END
GO



/* Delete Award */
IF OBJECT_ID(N'dbo.DeleteAward') IS NOT NULL
  DROP PROCEDURE DeleteAward;
GO

CREATE PROCEDURE DeleteAward(
	@Id INT)
AS
BEGIN
  DELETE FROM dbo.Awards
  WHERE Id = @Id
END
GO



/* Get Awards */
IF OBJECT_ID(N'dbo.GetAwards') IS NOT NULL
  DROP PROCEDURE GetAwards;
GO

CREATE PROCEDURE GetAwards
AS
BEGIN
	SELECT Id, Title, Description FROM Awards
END
GO


/* tests */
EXEC AddAward @title = N'test Grade A, prize 2b'
             ,@description = N'epic award, again';

EXEC GetAwards;

EXEC DeleteAward 5;

