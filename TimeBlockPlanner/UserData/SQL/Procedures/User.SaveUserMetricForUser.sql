CREATE OR ALTER PROCEDURE [User].SaveUserMetric
   @UserId INT,
   @MetricTimeframeId INT,
   @MetricID INT,
   @Date DATETIME,
   @Value INT
AS

MERGE [User].UserMetric UM
USING
      (
         VALUES(@UserId, @MetricTimeframeId, @MetricId, @Date, @Value)
      ) S(UserId, MetricTimeframeId, MetricId, [Date], [Value])
   ON S.UserId = UM.UserId
WHEN MATCHED AND NOT EXISTS
      (
         SELECT S.[Date], S.[Value]
         INTERSECT
         SELECT  UM.[Date], UM.[Value]
      ) THEN
   UPDATE
   SET 
      [Date] = S.[Date],
      [Value] = S.[Value]
WHEN NOT MATCHED THEN
   INSERT(UserId, MetricTimeframeId, MetricId, [Date], [Value])
   VALUES(S.UserId, S.MetricTimeframeId, S.MetricId, S.[Date], S.[Value]);
GO
