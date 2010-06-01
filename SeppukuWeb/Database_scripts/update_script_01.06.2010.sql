USE [Seppuku]
GO
/****** Object:  StoredProcedure [dbo].[SepKingdomGetById]    Script Date: 06/01/2010 09:28:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Łukasz Wiatrak
-- Create date: 11.03.2010
-- =============================================
CREATE PROCEDURE [dbo].[SepKingdomGetInfoById]
	@KingdomId int
AS
BEGIN
	declare @KingdomSize int
	declare @KingdomArmy int
	
	set @KingdomSize = (select COUNT(*) from SepField where
	    KingdomId = @KingdomId)

	set @KingdomArmy = (select COUNT(*) from SepUnit where
		KingdomId = @KingdomId)
		
	SELECT *, @KingdomArmy as 'KingdomArmy', @KingdomSize as 'KingdomSize'  FROM SepKingdom WHERE KingdomId = @KingdomId
END


GO

USE [Seppuku]
GO
/****** Object:  StoredProcedure [dbo].[SepKingdomTechnologyGetById]    Script Date: 06/01/2010 09:40:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Łukasz Wiatrak
-- Create date: 11.03.2010
-- =============================================
CREATE PROCEDURE [dbo].[SepKingdomTechnologyGetByKingdomAndTechnology]
	 @KingdomId int
	,@TechnologyId int
AS
BEGIN
	SELECT * FROM SepKingdomTechnology WHERE KingdomId = @KingdomId and TechnologyId = @TechnologyId
END

GO
USE [Seppuku]
GO
/****** Object:  StoredProcedure [dbo].[SepFieldGetById]    Script Date: 06/01/2010 10:08:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Łukasz Wiatrak
-- Create date: 11.03.2010
-- =============================================
CREATE PROCEDURE [dbo].[SepFieldGetByXY]
	 @FieldX int
	,@FieldY int
AS
BEGIN
	SELECT * FROM SepField WHERE FieldX = @FieldX and FieldY = @FieldY
END

GO

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.SepField
	DROP CONSTRAINT FK_SepField_SepMap
GO
ALTER TABLE dbo.SepMap SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.SepMap', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.SepMap', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.SepMap', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.SepField
	DROP CONSTRAINT FK_SepField_SepKingdom
GO
ALTER TABLE dbo.SepKingdom SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.SepKingdom', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.SepKingdom', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.SepKingdom', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_SepField
	(
	FieldId int NOT NULL IDENTITY (1, 1),
	MapId int NOT NULL,
	KingdomId int NOT NULL,
	FieldName nvarchar(50) NOT NULL,
	FieldX int NOT NULL,
	FieldY int NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_SepField SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_SepField ON
GO
IF EXISTS(SELECT * FROM dbo.SepField)
	 EXEC('INSERT INTO dbo.Tmp_SepField (FieldId, MapId, KingdomId, FieldName, FieldX, FieldY)
		SELECT FieldId, MapId, KingdomId, FieldName, FieldX, FieldY FROM dbo.SepField WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_SepField OFF
GO
ALTER TABLE dbo.SepUnit
	DROP CONSTRAINT FK_SepUnit_SepField
GO
DROP TABLE dbo.SepField
GO
EXECUTE sp_rename N'dbo.Tmp_SepField', N'SepField', 'OBJECT' 
GO
ALTER TABLE dbo.SepField ADD CONSTRAINT
	PK_SepField PRIMARY KEY CLUSTERED 
	(
	FieldId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.SepField ADD CONSTRAINT
	FK_SepField_SepKingdom FOREIGN KEY
	(
	KingdomId
	) REFERENCES dbo.SepKingdom
	(
	KingdomId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.SepField ADD CONSTRAINT
	FK_SepField_SepMap FOREIGN KEY
	(
	MapId
	) REFERENCES dbo.SepMap
	(
	MapId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
select Has_Perms_By_Name(N'dbo.SepField', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.SepField', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.SepField', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.SepUnit ADD CONSTRAINT
	FK_SepUnit_SepField FOREIGN KEY
	(
	FieldId
	) REFERENCES dbo.SepField
	(
	FieldId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.SepUnit SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.SepUnit', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.SepUnit', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.SepUnit', 'Object', 'CONTROL') as Contr_Per 

GO