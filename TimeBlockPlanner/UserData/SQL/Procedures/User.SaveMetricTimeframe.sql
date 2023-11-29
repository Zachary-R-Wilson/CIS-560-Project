
CREATE OR ALTER PROCEDURE [User].SaveMetricTimeframe
   @Name NVARCHAR(32),
   @IsDeleted INT,
   @MetricTimeframeId INT OUTPUT
AS


MERGE [User].MetricTimeframe TF
USING
      (
         VALUES(@Name, @IsDeleted, @MetricTimeframeId)
      ) S([Name], IsDeleted, MetricTimeframeId)
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
   INSERT([Name], IsDeleted)
   VALUES(S.[Name], S.IsDeleted);

    SET @MetricTimeframeId = SCOPE_IDENTITY();
GO
