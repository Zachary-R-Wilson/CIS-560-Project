CREATE OR ALTER PROCEDURE [User].RetrieveUser
AS

SELECT U.PersonId, U.Email, U.FirstName, U.LastName, U.passwordHash, U.IsDeleted
FROM [User].[User] U;
GO