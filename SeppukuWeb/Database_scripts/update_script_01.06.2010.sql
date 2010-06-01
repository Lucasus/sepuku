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
