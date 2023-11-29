
CREATE OR ALTER PROCEDURE [User].RetrieveMetricsForUser
@UserId INT
AS

SELECT M.MetricId, M.[Name], M.IsDeleted
FROM [User].Metric M
WHERE M.UserId = @UserId
GO