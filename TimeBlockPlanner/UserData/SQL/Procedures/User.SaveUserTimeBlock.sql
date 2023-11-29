
CREATE OR ALTER PROCEDURE [User].SaveUserTimeBlock
   @UserId INT,
   @Name NVARCHAR(32),
   @Description NVARCHAR(32),
   @Date DATETIME,
   @TimePeriod DATETIMEOFFSET,
   @TimeBlockId INT OUTPUT
AS

MERGE [User].TimeBlock T
USING
      (
         VALUES(@UserId, @Name, @Description, @Date, @TimePeriod, @TimeBlockId)
      ) S(UserId, [Name], [Description], [Date], TimePeriod, TimeBlockId)
   ON S.UserId = T.UserId AND S.[Name] = T.[Name] AND S.[Description] = T.[Description]
WHEN MATCHED AND NOT EXISTS
      (
         SELECT S.[Name], S.[Description], S.[Date], S.[TimePeriod]
         INTERSECT
         SELECT  T.[Name], T.[Description], T.[Date], T.[TimePeriod]
      ) THEN
   UPDATE
   SET 
      [Name] = S.[Name],
      [Description] = S.[Description],
      [Date] = S.[Date],
      Timeperiod = S.TimePeriod
WHEN NOT MATCHED THEN
   INSERT(UserId, [Name], [Description], [Date], TimePeriod)
   VALUES(S.UserId, S.[Name], S.[Description], S.[Date], S.TimePeriod);

    SET @TimeBlockId = SCOPE_IDENTITY();
GO

