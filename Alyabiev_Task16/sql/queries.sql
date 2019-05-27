USE UsersAwards
GO

/* queries */

SELECT * FROM dbo.Users

SELECT * FROM dbo.Awards

SELECT * FROM dbo.Relations



/* after program test */
DELETE
FROM dbo.Awards
WHERE Id >= 5;

DELETE
--SELECT *
FROM dbo.Users
WHERE Id >= 7;


/* all users and awarded */
SELECT Concat(u.FirstName, ' ', u.Surname) as Name, u.Birthdate, a.Title, a.Description
FROM dbo.Users AS u
LEFT JOIN dbo.Relations AS r
	ON r.UserId = u.Id
	LEFT JOIN dbo.Awards AS a
		ON r.AwardId = a.Id;

/* only awarded users */
SELECT Concat(u.FirstName, ' ', u.Surname) as Name, u.Birthdate, a.Title, a.Description
FROM dbo.Users AS u
RIGHT JOIN dbo.Relations AS r
	ON r.UserId = u.Id
	LEFT JOIN dbo.Awards AS a
		ON r.AwardId = a.Id;




DELETE FROM dbo.Users
WHERE id IN (SELECT TOP(2) id FROM dbo.Users)



UPDATE dbo.Users
SET FisrtName = 'Janny'
WHERE Id = 3;



SELECT CONCAT(FirstName, ' ', Surname) AS 'User Name', birthdate AS 'birth'
FROM dbo.Users;



SELECT CONCAT(FirstName, ' ', Surname) AS 'User Name', GetAwards(id) AS 'Awards'
FROM dbo.Users;
