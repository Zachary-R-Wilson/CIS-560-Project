CREATE OR ALTER PROCEDURE [User].SaveMetric
   @Name NVARCHAR(32),
   @IsDeleted INT,
   @MetricId INT OUTPUT
AS


MERGE [User].Metric M
USING
      (
         VALUES(@Name, @IsDeleted, @MetricId)
      ) S([Name], IsDeleted, MetricId)
   ON S.MetricId = M.MetricId
WHEN MATCHED AND NOT EXISTS
      (
         SELECT S.[Name], S.IsDeleted
         INTERSECT
         SELECT  M.[Name], M.IsDeleted
      ) THEN
   UPDATE
   SET 
      [Name] = S.[Name],
      IsDeleted = S.IsDeleted
WHEN NOT MATCHED THEN
   INSERT([Name], IsDeleted)
   VALUES(S.[Name], S.IsDeleted);

    SET @MetricId = SCOPE_IDENTITY();
GO

