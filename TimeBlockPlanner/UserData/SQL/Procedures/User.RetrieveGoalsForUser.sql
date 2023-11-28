CREATE OR ALTER PROCEDURE [User].RetrieveGoalsForUser
   @UserId INT
AS

SELECT UG.GoalId, UG.UserId, UG.[Name], UG.[Description],
   UG.StartDate, UG.EndDate, UG.IsComplete, UG.Progress
FROM [User].Goal UG
WHERE UG.UserId = @UserId;
GO
