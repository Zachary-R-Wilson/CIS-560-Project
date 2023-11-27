IF OBJECT_ID(N'User.TimeBlock') IS NULL
BEGIN
   CREATE TABLE [User].TimeBlock
   (
      TimeBlockId INT NOT NULL IDENTITY(1, 1),
      UserId INT NOT NULL,
      [Name] NVARCHAR(32) NOT NULL,
      [Description] NVARCHAR(32) NULL,
      [Date] DATETIME NOT NULL,
      TimePeriod DATETIME NOT NULL
      
      CONSTRAINT [PK_User_UserTimeBlock_UserTimeBlockId] PRIMARY KEY CLUSTERED
      (
         TimeBlockId ASC
      ),

      CONSTRAINT FK_User_User_UserId FOREIGN KEY(UserId)
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
      WHERE kc.parent_object_id = OBJECT_ID(N'[User].TimeBlock')
         AND kc.[name] = N'UK_User_TimeBlock_UserId_TimeBlockId'
   )
BEGIN
   ALTER TABLE [User].TimeBlock
   ADD CONSTRAINT [UK_User_TimeBlock_UserId_Name_Description] UNIQUE NONCLUSTERED
   (
      UserId,
      TimeBlockId
   )
END;

/****************************
 * Foreign Keys Constraints
 ****************************/

IF NOT EXISTS
   (
      SELECT *
      FROM sys.foreign_keys fk
      WHERE fk.parent_object_id = OBJECT_ID(N'[User].TimeBlock')
         AND fk.referenced_object_id = OBJECT_ID(N'[User].User')
         AND fk.[name] = N'FK_User_User_UserId'
   )
BEGIN
   ALTER TABLE [User].TimeBlock              
   ADD CONSTRAINT [FK_User_User_UserId] FOREIGN KEY
   (
      UserId
   )
   REFERENCES [User].[User]
   (
      UserId
   );
END;
