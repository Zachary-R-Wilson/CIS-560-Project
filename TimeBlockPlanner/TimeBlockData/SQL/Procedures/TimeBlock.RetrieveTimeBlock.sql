CREATE OR ALTER PROCEDURE TimeBlock.GetTimeBlockById
   @TimeBlockId INT
AS

SELECT T.TimeBlockId, T.UserId, T.[Name], T.[Description], T.[Date], T.[Time]
FROM TimeBlockData.TimeBlock T
WHERE T.TimeBlockId = @TimeBlockId;
GO
