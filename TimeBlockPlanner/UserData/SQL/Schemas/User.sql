    IF NOT EXISTS
   (
      SELECT *
      FROM sys.schemas s
      WHERE s.[name] = N'User'
   )
BEGIN
   EXEC(N'CREATE SCHEMA [User] AUTHORIZATION [dbo]');
END;