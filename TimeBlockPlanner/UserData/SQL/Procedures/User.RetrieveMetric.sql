
CREATE OR ALTER PROCEDURE [User].RetrieveMetric
@MetricId INT
AS

SELECT M.MetricId, M.[Name], M.IsDeleted
FROM [User].Metric M
WHERE M.MetricId = @MetricId
GO