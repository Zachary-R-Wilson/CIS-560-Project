CREATE OR ALTER PROCEDURE [User].GetUserByEmail
   @Email NVARCHAR(128)
AS

SELECT  U.UserId, U.Username, U.Email, U.FirstName, U.LastName, U.PasswordHash, U.IsDeleted
FROM [User].[User] U
WHERE U.Email = @Email;
GO