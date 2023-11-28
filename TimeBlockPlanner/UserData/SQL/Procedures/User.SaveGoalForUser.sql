CREATE OR ALTER PROCEDURE [User].SaveGoalForUser
   @GoalId INT,
   @UserId INT,
   @Name NVARCHAR(32),
   @Description NVARCHAR(32),
   @StartDate DATETIME,
   @EndDate DATETIME,
   @IsComplete INT,
   @Progress NVARCHAR(32)
AS

MERGE [User].Goal G
USING
      (
         VALUES(@GoalId, @UserId, @Name, @Description, @StartDate, @EndDate, @IsComplete, @Progress)
      ) S(GoalId, UserId, [Name], [Description], StartDate, EndDate, IsComplete, Progress)
   ON S.UserId = G.UserId
WHEN MATCHED AND NOT EXISTS
      (
         SELECT S.[Name], S.[Description], S.StartDate, S.EndDate, S.IsComplete, S.Progress
         INTERSECT
         SELECT  G.[Name], G.[Description], G.StartDate, G.EndDate, G.IsComplete, G.Progress
      ) THEN
   UPDATE
   SET
      [Name] = S.[Name],
      [Description] = S.[Description],
      StartDate = S.StartDate,
      EndDate = S.EndDate,
      IsComplete = S.IsComplete,
      Progress = S.Progress
WHEN NOT MATCHED THEN
   INSERT(GoalId, UserId, [Name], [Description], StartDate, EndDate, IsComplete, Progress)
   VALUES(S.GoalId, S.UserId, S.[Name], S.[Description], S.StartDate, S.EndDate, S.IsComplete, S.Progress);
GO