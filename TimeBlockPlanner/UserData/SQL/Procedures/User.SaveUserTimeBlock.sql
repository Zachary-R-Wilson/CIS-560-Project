CREATE OR ALTER PROCEDURE [User].SaveUserTimeBlock
   @TimeBlockId INT,
   @UserId INT,
   @Name NVARCHAR(32),
   @Description NVARCHAR(32),
   @Date DATETIME,
   @TimePeriod DATETIME
AS

MERGE [User].TimeBlock T
USING
      (
         VALUES(@TimeBlockId, @UserId, @Name, @Description, @Date, @TimePeriod)
      ) S(TimeBlockId, UserId, [Name], [Description], [Date], TimePeriod)
   ON S.UserId = T.UserId
WHEN MATCHED AND NOT EXISTS
      (
         SELECT S.Line1, S.Line2, S.City, S.StateCode, S.ZipCode
         INTERSECT
         SELECT  T.Line1, T.Line2, T.City, T.StateCode, T.ZipCode
      ) THEN
   UPDATE
   SET 
      [Name] = S.[Name],
      [Description] = S.[Description],
      [Date] = S.[Date],
      Timeperiod = S.TimePeriod
WHEN NOT MATCHED THEN
   INSERT(TimeBlockId, UserId, [Name], [Description], [Date], TimePeriod)
   VALUES(S.TimeBlockId, S.UserId, S.[Name], S.[Description], S.[Date], S.TimePeriod);
GO
