IF OBJECT_ID(N'TimeBlockData.TimeBlock') IS NULL
BEGIN
   CREATE TABLE TimeBlockData.TimeBlock
   (
      TimeBlockId INT NOT NULL IDENTITY(1, 1),
      UserId INT NOT NULL,
      [Name] NVARCHAR(32) NOT NULL,
      [Description] NVARCHAR(32) NULL,
      [Date] SYSDATETIME NOT NULL,
      [Time] SYSDATETIME NOT NULL,
      ZipCode CHAR(5) NOT NULL,
      
      CONSTRAINT [PK_Person_PersonAddress_PersonAddressId] PRIMARY KEY CLUSTERED    -- change this
      (
         PersonAddressId ASC
      ),

      CONSTRAINT FK_Person_PersonAddress_Person_Person FOREIGN KEY(PersonId) -- change these
      REFERENCES Person.Person(PersonId),

      CONSTRAINT FK_Person_PersonAddress_Person_AddressType FOREIGN KEY(AddressTypeId) -- change 
      REFERENCES Person.AddressType(AddressTypeId)
   );
END

/****************************
 * Unique Constraints
 ****************************/

IF NOT EXISTS
   (
      SELECT *
      FROM sys.key_constraints kc
      WHERE kc.parent_object_id = OBJECT_ID(N'TimeBlockData.TimeBlock')
         AND kc.[name] = N'UK_Person_PersonAddress_PersonId_AddressTypeId' -- change this
   )
BEGIN
   ALTER TABLE TimeBlockData.TimeBlock
   ADD CONSTRAINT [UK_Person_PersonAddress_PersonId_AddressTypeId] UNIQUE NONCLUSTERED
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
      WHERE fk.parent_object_id = OBJECT_ID(N'TimeBlockData.TimeBlock')
         AND fk.referenced_object_id = OBJECT_ID(N'TimeBlockData.User')
         AND fk.[name] = N'FK_Person_PersonAddress_Person_Person'       -- change this
   )
BEGIN
   ALTER TABLE TimeBlockData.TimeBlock              
   ADD CONSTRAINT [FK_Person_PersonAddress_Person_Person] FOREIGN KEY       -- change this
   (
      UserId
   )
   REFERENCES TimeBlockData.[User]
   (
      UserId
   );
END;

IF NOT EXISTS
   (
      SELECT *
      FROM sys.foreign_keys fk
      WHERE fk.parent_object_id = OBJECT_ID(N'TimeBlockData.TimeBlock')
         AND fk.[name] = N'FK_Person_PersonAddress_Person_AddressType'      -- change
   )
BEGIN
   ALTER TABLE TimeBlockData.TimeBlock
   ADD CONSTRAINT [FK_Person_PersonAddress_Person_AddressType] FOREIGN KEY      -- change
   (
      TimeBlockId
   )
   REFERENCES TimeBlockData.[User]          -- not sure if this should change 
   (
      UserId
   );
END;
