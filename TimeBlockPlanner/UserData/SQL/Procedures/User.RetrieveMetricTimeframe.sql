CREATE OR ALTER PROCEDURE [User].RetrieveMetricTimeframe
AS

SELECT TF.MetricTimeframeId, TF.[Name], TF.IsDeleted
FROM [User].MetricTimeframe TF;

GO