

1. ������� ��������� ���

/* creating table type for several id */

CREATE TYPE AwardsIds AS TABLE(id int);
GO




2. ������� ���������

�� �����: ���, �������, ���� ��������, ������� ��������

CREATE PROCEDURE AddAwardedUser(
	@firstName nvarchar(50),
	@surname nvarchar(50),
	@birthdate datetime2,
	@awardIds AwardsIds readonly)
AS
BEGIN
	DECLARE @userId AS TABLE(id int);

	/* ������ ������������ � ��� ������� */
	INSERT INTO Users
	OUTPUT Inserted.Id INTO @userId
	VALUES(@firstName, @surname, @birthdate);

	/* ������ ����� � ������ ������� (������� ������) ������������ � ��������� */
	INSERT INTO Relations
	SELECT [@userId].id, [@awardIds].id FROM @awardIds, @userId;
END







/* test */

/* ������� ����������-�������, ��������� ������� �������� */

DECLARE @userAwardsIds AS AwardsIds;
INSERT INTO @userAwardsIds
  VALUES (1), (3);


/* �������� ���������, ��������� ����������-������� */

EXEC AddAwardedUser  @firstName = N'Some'
                    ,@surname = N'Person'
                    ,@birthdate = '2001-04-24'
                    ,@awardIds = @userAwardsIds;