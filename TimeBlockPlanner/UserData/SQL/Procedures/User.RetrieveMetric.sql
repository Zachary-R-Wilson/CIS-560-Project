CREATE OR ALTER PROCEDURE [User].RetrieveMetric
AS

SELECT M.MetricId, M.[Name], M.IsDeleted
FROM [User].Metric M;

GO
