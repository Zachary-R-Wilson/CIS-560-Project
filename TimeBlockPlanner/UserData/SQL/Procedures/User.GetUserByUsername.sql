CREATE OR ALTER PROCEDURE [User].GetUserByUsername
   @Username NVARCHAR(128)
AS

SELECT  U.UserId, U.Username, U.Email, U.FirstName, U.LastName, U.PasswordHash, U.IsDeleted
FROM [User].[User] U
WHERE U.Username = @Username;
GO