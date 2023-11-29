
IF OBJECT_ID(N'User.MetricTimeframe') IS NULL
BEGIN
   CREATE TABLE [User].MetricTimeframe
   (
      MetricTimeframeId INT NOT NULL,
      [Name] NVARCHAR(32) NOT NULL,
      IsDeleted INT NOT NULL

      CONSTRAINT [PK_User_MetricTimeframe_MetricTimeframeId] PRIMARY KEY CLUSTERED
      (
         MetricTimeframeId ASC
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
      WHERE kc.parent_object_id = OBJECT_ID(N'[User].MetricTimeframe')
         AND kc.[name] = N'UK_User_MetricTimeframe_MetricTimeframeId_Name'
   )
BEGIN
   ALTER TABLE [User].MetricTimeframe
   ADD CONSTRAINT [UK_User_MetricTimeframe_MetricTimeframeId_Name] UNIQUE NONCLUSTERED
   (
      MetricTimeframeId,
      [Name]
   )
END;

