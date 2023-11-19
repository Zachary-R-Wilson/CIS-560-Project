CREATE OR ALTER PROCEDURE [User].CreateUser	-- find the CreateUser to tie this to 
   @Username NVARCHAR(32),
   @FirstName NVARCHAR(32),
   @LastName NVARCHAR(32),
   @Email NVARCHAR(128),
   @PasswordHash NVARCHAR(256),	-- probabably needs to be a larger data type
   @IsDeleted INT,
   @UserId INT OUTPUT
AS

INSERT [User].[User](Username, FirstName, LastName, Email, PasswordHash, IsDeleted)
VALUES(@Username, @FirstName, @LastName, @Email, @PasswordHash, @IsDeleted);

SET @UserId = SCOPE_IDENTITY();
GO