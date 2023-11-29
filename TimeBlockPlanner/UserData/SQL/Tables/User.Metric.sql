
IF OBJECT_ID(N'User.Metric') IS NULL
BEGIN
   CREATE TABLE [User].Metric
   (
      MetricId INT NOT NULL IDENTITY(1,1),
      [Name] NVARCHAR(32) NOT NULL,
      IsDeleted INT NOT NULL

      CONSTRAINT [PK_User_Metric_MetricId] PRIMARY KEY CLUSTERED
      (
         MetricId ASC
      ),

   );
END

/****************************
 * Unique Constraints
 ****************************/

IF NOT EXISTS
   (
      SELECT *
      FROM sys.key_constraints kc
      WHERE kc.parent_object_id = OBJECT_ID(N'[User].Metric')
         AND kc.[name] = N'UK_User_Metric_MetricId_Name'
   )
BEGIN
   ALTER TABLE [User].Metric
   ADD CONSTRAINT [UK_User_Metric_MetricId_Name] UNIQUE NONCLUSTERED
   (
      MetricId,
      [Name]
   )
END;

