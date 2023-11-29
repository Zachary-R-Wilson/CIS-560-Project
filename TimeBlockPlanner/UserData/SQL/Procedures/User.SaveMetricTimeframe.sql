CREATE OR ALTER PROCEDURE [User].SaveMetricTimeframe
   @MetricTimeframeId INT,
   @Name NVARCHAR(32),
   @IsDeleted INT

AS

MERGE [User].MetricTimeframe TF
USING
      (
         VALUES(@MetricTimeframeId, @Name, @IsDeleted)
      ) S(MetricTimeframeId, [Name], IsDeleted)
   ON S.MetricTimeframeId = TF.MetricTimeframeId
WHEN MATCHED AND NOT EXISTS
      (
         SELECT S.[Name], S.IsDeleted
         INTERSECT
         SELECT  TF.[Name], TF.IsDeleted
      ) THEN
   UPDATE
   SET 
      [Name] = S.[Name],
      IsDeleted = S.IsDeleted
WHEN NOT MATCHED THEN
   INSERT(MetricTimeframeId, [Name], IsDeleted)
   VALUES(S.MetricTimeframeId, S.[Name], S.IsDeleted);
GO
