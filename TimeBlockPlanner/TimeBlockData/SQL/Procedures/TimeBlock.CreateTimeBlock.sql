CREATE OR ALTER PROCEDURE TimeBlock.CreateTimeBlock
      @TimeBlockId INT,
      @UserId INT,
      @Name NVARCHAR(32),
      @Description NVARCHAR(32),
      @Date SYSDATETIME,
      @Time SYSDATETIME
AS

INSERT TimeBlock.TimeBlock(TimeBlockId, UserId, [Name])
VALUES([Description], [Date], [Time]);

SET @TimeBlockId = SCOPE_IDENTITY();
