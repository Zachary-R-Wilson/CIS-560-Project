CREATE OR ALTER PROCEDURE [User].RetrieveUser
AS

SELECT U.UserId, U.Email, U.FirstName, U.LastName, U.PasswordHash, U.IsDeleted
FROM [User].[User] U;
GO