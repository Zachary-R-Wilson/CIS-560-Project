IF OBJECT_ID(N'User.User') IS NULL
BEGIN
   CREATE TABLE [User].[User]
   (
      UserId INT NOT NULL IDENTITY(1, 1) ,
      Username  NVARCHAR(128) NOT NULL,
      Email NVARCHAR(128) NOT NULL,
      FirstName NVARCHAR(32) NOT NULL,
      LastName NVARCHAR(32) NOT NULL,
      PasswordHash NVARCHAR(32) NOT NULL,
      IsDeleted INT NOT NULL,

      CONSTRAINT [PK_User_User_UserId] PRIMARY KEY CLUSTERED
      (
         UserId ASC
      )
   );
END;

/****************************
 * Unique Constraints
 ****************************/

IF NOT EXISTS
   (
      SELECT *
      FROM sys.key_constraints kc
      WHERE kc.parent_object_id = OBJECT_ID(N'User.User')
         AND kc.[name] = N'UK_User_User_Email'
   )
BEGIN
   ALTER TABLE [User].[User]
   ADD CONSTRAINT [UK_User_User_Email] UNIQUE NONCLUSTERED
   (
      Email ASC
   )
END;

/****************************
 * Check Constraints
 ****************************/

IF NOT EXISTS
   (
      SELECT *
      FROM sys.check_constraints cc
      WHERE cc.parent_object_id = OBJECT_ID(N'User.User')
         AND cc.[name] = N'CK_User_User_LastName_FirstName'
   )
BEGIN
   ALTER TABLE [User].[User]
   ADD CONSTRAINT [CK_User_User_LastName_FirstName] CHECK
   (
      FirstName > N'' OR LastName > N''
   )
END;
