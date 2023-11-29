CREATE OR ALTER PROCEDURE [User].RetrieveUserMetricsForUser
   @UserId INT
AS

SELECT UUM.UserId, UUM.MetricTimeframeId, UUM.MetricId,
   UUM.[Date], UUM.[Value]
FROM [User].UserMetric UUM
WHERE UUM.UserId = @UserId;
GO
