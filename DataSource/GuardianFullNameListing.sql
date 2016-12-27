USE [FamilyLiteracy.mdf]
GO

DECLARE @RC int
DECLARE @fullname nvarchar(50)

-- TODO: Set parameter values here.

EXECUTE @RC = [dbo].[GuardianFullNameListing] 
   @fullname
GO

