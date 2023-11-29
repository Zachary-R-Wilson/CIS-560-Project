CREATE OR ALTER PROCEDURE [User].SaveMetric
   @MetricId INT,
   @Name NVARCHAR(32),
   @IsDeleted INT

AS

MERGE [User].Metric M
USING
      (
         VALUES(@MetricId, @Name, @IsDeleted)
      ) S(MetricId, [Name], IsDeleted)
   ON S.MetricId = M.MetricId
WHEN MATCHED AND NOT EXISTS
      (
         SELECT S.[Name], S.IsDeleted
         INTERSECT
         SELECT  M.[Name], TF.IsDeleted
      ) THEN
   UPDATE
   SET 
      [Name] = S.[Name],
      IsDeleted = S.IsDeleted
WHEN NOT MATCHED THEN
   INSERT(MetricId, [Name], IsDeleted)
   VALUES(S.MetricId, S.[Name], S.IsDeleted);
GO
