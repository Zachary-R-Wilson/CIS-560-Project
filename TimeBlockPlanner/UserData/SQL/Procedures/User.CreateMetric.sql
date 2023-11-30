CREATE OR ALTER PROCEDURE [User].CreateMetric

   @Name NVARCHAR(32),
   @IsDeleted INT,
   @MetricId INT OUTPUT

AS

INSERT [User].Metric( [Name], IsDeleted)
VALUES(@Name, @IsDeleted);

SET @MetricId = SCOPE_IDENTITY();

GO
