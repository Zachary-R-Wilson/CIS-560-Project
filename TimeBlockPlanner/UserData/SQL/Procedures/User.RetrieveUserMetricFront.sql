CREATE OR ALTER PROCEDURE [User].UserMetricFront
      @UserId INT
AS

      SELECT UM.UserId, UM.MetricTimeframeId, UM.MetricId, MT.[Name] AS MetricTimeframeName, M.[Name] AS MetricName, UM.[Date], UM.[Value]
      FROM [User].UserMetric UM
      JOIN [User].Metric M ON M.MetricId = UM.MetricId
      JOIN [User].MetricTimeframe MT ON MT.MetricTimeframeId = UM.MetricTimeframeId
	 WHERE UM.UserId = @UserId

GO

