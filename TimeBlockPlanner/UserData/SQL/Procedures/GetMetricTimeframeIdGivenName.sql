CREATE OR ALTER PROCEDURE [User].GetMetricTimeframeIdGivenName
   @Name NVARCHAR(128)
AS

SELECT  TF.MetricTimeframeId
FROM [User].MetricTimeframe TF
WHERE TF.[Name] = @Name;
GO
