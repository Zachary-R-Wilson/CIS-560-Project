IF NOT EXISTS
   (
      SELECT *
      FROM sys.schemas s
      WHERE s.[name] = N'TimeBlock'
   )
BEGIN
   EXEC(N'CREATE SCHEMA [TimeBlock] AUTHORIZATION [dbo]');
END;