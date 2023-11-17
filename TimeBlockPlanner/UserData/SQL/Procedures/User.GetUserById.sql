CREATE OR ALTER PROCEDURE [User].GetUserById
   @UserId INT
AS

SELECT U.UserId, U.Username, U.Email, U.FirstName, U.LastName, U.PasswordHash, U.IsDeleted
FROM [User].[User] U
WHERE U.UserId = @UserId;
GO
