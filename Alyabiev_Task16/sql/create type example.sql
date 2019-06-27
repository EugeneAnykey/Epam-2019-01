

1. создаем табличный тип

/* creating table type for several id */

CREATE TYPE AwardsIds AS TABLE(id int);
GO




2. Создаем процедуру

на входе: имя, фамилия, дата рождения, таблица индексов

CREATE PROCEDURE AddAwardedUser(
	@firstName nvarchar(50),
	@surname nvarchar(50),
	@birthdate datetime2,
	@awardIds AwardsIds readonly)
AS
BEGIN
	DECLARE @userId AS TABLE(id int);

	/* вносим пользователя в его таблицу */
	INSERT INTO Users
	OUTPUT Inserted.Id INTO @userId
	VALUES(@firstName, @surname, @birthdate);

	/* делаем связи в другой таблице (таблица связей) пользователя с индексами */
	INSERT INTO Relations
	SELECT [@userId].id, [@awardIds].id FROM @awardIds, @userId;
END







/* test */

/* создаем переменную-таблицу, заполняем таблицу индексов */

DECLARE @userAwardsIds AS AwardsIds;
INSERT INTO @userAwardsIds
  VALUES (1), (3);


/* вызываем процедуру, передавая переменную-таблицу */

EXEC AddAwardedUser  @firstName = N'Some'
                    ,@surname = N'Person'
                    ,@birthdate = '2001-04-24'
                    ,@awardIds = @userAwardsIds;