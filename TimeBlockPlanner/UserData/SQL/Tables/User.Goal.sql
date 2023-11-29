
IF OBJECT_ID(N'User.Goal') IS NULL
BEGIN
   CREATE TABLE [User].Goal
   (
      GoalId INT NOT NULL IDENTITY(1, 1),
      UserId INT NOT NULL,
      [Name] NVARCHAR(32) NOT NULL,
      [Description] NVARCHAR(32) NULL,
      StartDate DATETIME NOT NULL,
      EndDate DATETIME NOT NULL,
      IsComplete INT NOT NULL, 
      Progress NVARCHAR(128) NOT NULL
      
      CONSTRAINT [PK_User_UserGoal_UserGoalId] PRIMARY KEY CLUSTERED
      (
         GoalId ASC
      ),

      CONSTRAINT FK_User_Goal_User_UserId FOREIGN KEY(UserId)
      REFERENCES [User].[User](UserId),
   );
END

/****************************
 * Unique Constraints
 ****************************/

IF NOT EXISTS
   (
      SELECT *
      FROM sys.key_constraints kc
      WHERE kc.parent_object_id = OBJECT_ID(N'[User].Goal')
         AND kc.[name] = N'UK_User_Goal_UserId_GoalId'
   )
BEGIN
   ALTER TABLE [User].Goal
   ADD CONSTRAINT [UK_User_Goal_UserId_GoalId] UNIQUE NONCLUSTERED
   (
      UserId,
      GoalId
   )
END;

/****************************
 * Foreign Keys Constraints
 ****************************/

IF NOT EXISTS
   (
      SELECT *
      FROM sys.foreign_keys fk
      WHERE fk.parent_object_id = OBJECT_ID(N'[User].Goal')
         AND fk.referenced_object_id = OBJECT_ID(N'[User].User')
         AND fk.[name] = N'FK_User_Goal_User_UserId'
   )
BEGIN
   ALTER TABLE [User].Goal              
   ADD CONSTRAINT [FK_User_Goal_User_UserId] FOREIGN KEY
   (
      UserId
   )
   REFERENCES [User].[User]
   (
      UserId
   );
END;


