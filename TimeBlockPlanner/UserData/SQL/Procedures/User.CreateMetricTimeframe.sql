CREATE OR ALTER PROCEDURE [User].CreateMetricTimeframe
   @Name NVARCHAR(32),
   @IsDeleted INT,
   @MetricTimeframeId INT OUTPUT

AS

INSERT [User].MetricTimeframe([Name], IsDeleted)
VALUES(@Name, @IsDeleted);

SET @MetricTimeframeId = SCOPE_IDENTITY();

GO
