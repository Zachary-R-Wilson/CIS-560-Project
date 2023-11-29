
IF OBJECT_ID(N'User.UserMetric') IS NULL
BEGIN
   CREATE TABLE [User].UserMetric
   (
      UserId INT NOT NULL,
      MetricTimeframeId INT NOT NULL,
      MetricId INT NOT NULL,
      [Date] DATETIME NOT NULL,
      [Value] INT NOT NULL

      CONSTRAINT FK_User_User_UserId FOREIGN KEY(UserId)
      REFERENCES [User].[User](UserId),
      
      CONSTRAINT FK_User_MetricTimeframe_MetricTimeframeId FOREIGN KEY(MetricTimeframeId)
      REFERENCES [User].[MetricTimeframe](MetricTimeframeId),

      CONSTRAINT FK_User_Metric_MetricId FOREIGN KEY(MetricId)
      REFERENCES [User].[Metric](MetricId),
   );
END

/****************************
 * Unique Constraints
 ****************************/

IF NOT EXISTS
   (
      SELECT *
      FROM sys.key_constraints kc
      WHERE kc.parent_object_id = OBJECT_ID(N'[User].UserMetric')
         AND kc.[name] = N'UK_User_UserMetric_UserId_MetricTimeframeId_MetricId'
   )
BEGIN
   ALTER TABLE [User].UserMetric
   ADD CONSTRAINT [UK_User_UserMetric_UserId_MetricTimeframeId_MetricId_Date] UNIQUE NONCLUSTERED
   (
      UserId,
      MetricTimeframeId,
      MetricId,
      [Date]
   )
END;

/****************************
 * Foreign Keys Constraints
 ****************************/

IF NOT EXISTS
   (
      SELECT *
      FROM sys.foreign_keys fk
      WHERE fk.parent_object_id = OBJECT_ID(N'[User].UserMetric')
         AND fk.referenced_object_id = OBJECT_ID(N'[User].User')
         AND fk.[name] = N'FK_User_UserMetric_User_UserId'
   )
BEGIN
   ALTER TABLE [User].UserMetric              
   ADD CONSTRAINT [FK_User_UserMetric_User_UserId] FOREIGN KEY
   (
      UserId
   )
   REFERENCES [User].[User]
   (
      UserId
   );
END;

IF NOT EXISTS
   (
      SELECT *
      FROM sys.foreign_keys fk
      WHERE fk.parent_object_id = OBJECT_ID(N'[User].UserMetric')
         AND fk.referenced_object_id = OBJECT_ID(N'[User].MetricTimeframe')
         AND fk.[name] = N'FK_User_MetricTimeframe_MetricTimeframeId'
   )
BEGIN
   ALTER TABLE [User].UserMetric              
   ADD CONSTRAINT [FK_User_MetricTimeframe_MetricTimeframeId] FOREIGN KEY
   (
      MetricTimeframeId
   )
   REFERENCES [User].[MetricTimeframe]
   (
      MetricTimeframeId
   );
END;

IF NOT EXISTS
   (
      SELECT *
      FROM sys.foreign_keys fk
      WHERE fk.parent_object_id = OBJECT_ID(N'[User].UserMetric')
         AND fk.referenced_object_id = OBJECT_ID(N'[User].Metric')
         AND fk.[name] = N'FK_User_Metric_MetricId'
   )
BEGIN
   ALTER TABLE [User].UserMetric              
   ADD CONSTRAINT [FK_User_Metric_MetricId] FOREIGN KEY
   (
      MetricId
   )
   REFERENCES [User].[Metric]
   (
      MetricId
   );
END;


