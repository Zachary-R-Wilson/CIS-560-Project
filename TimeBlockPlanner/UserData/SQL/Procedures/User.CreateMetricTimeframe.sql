CREATE OR ALTER PROCEDURE [User].CreateMetricTimeframe
   @MetricTimeframeId INT,
   @Name NVARCHAR(32),
   @IsDeleted INT

AS

INSERT [User].MetricTimeframeId( @Name, @IsDeleted)
VALUES(@Name, @IsDeleted);

SET @MetricTimeframeId = SCOPE_IDENTITY();

GO
