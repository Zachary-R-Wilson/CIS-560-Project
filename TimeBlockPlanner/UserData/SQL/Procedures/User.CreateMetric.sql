CREATE OR ALTER PROCEDURE [User].CreateMetric
   @MetricId INT,
   @Name NVARCHAR(32),
   @IsDeleted INT

AS

INSERT [User].MetricId( @Name, @IsDeleted)
VALUES(@Name, @IsDeleted);

SET @MetricId = SCOPE_IDENTITY();

GO
