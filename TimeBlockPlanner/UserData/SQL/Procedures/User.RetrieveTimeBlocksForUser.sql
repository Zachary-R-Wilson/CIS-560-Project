CREATE OR ALTER PROCEDURE [User].RetrieveTimeBlockForUser
   @UserId INT
AS

SELECT UT.TimeBlockId, Ut.UserId, UT.[Name], UT.[Description],
   UT.[Date], UT.TimePeriod
FROM [User].TimeBlock UT
WHERE UT.UserId = @UserId;
GO