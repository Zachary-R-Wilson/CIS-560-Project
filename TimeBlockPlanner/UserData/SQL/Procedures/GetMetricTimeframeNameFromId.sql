CREATE OR ALTER PROCEDURE [User].GetMetricTimeframeNameFromId
   @MetricTimeframeId INT
AS

SELECT  TF.MetricTimeframeId
FROM [User].MetricTimeframe TF
WHERE TF.[Name] = @Name;
GO
