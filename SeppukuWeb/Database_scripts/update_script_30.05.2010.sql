USE [Seppuku]
GO
/****** Object:  StoredProcedure [dbo].[SepTechnologyGetByKingdomId]    Script Date: 05/30/2010 18:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Łukasz Wiatrak
-- Create date: 11.03.2010
-- =============================================
ALTER PROCEDURE [dbo].[SepTechnologyGetByKingdomId]
	@KingdomId int
AS
BEGIN
	declare @KingdomResources int
	set @KingdomResources = (select KingdomResources from SepKingdom where KingdomId = @KingdomId)

	SELECT t.*, 'Kupiony' as 'TechnologyStatus' FROM SepTechnology t
		inner join SepKingdomTechnology kt on t.TechnologyId = kt.TechnologyId
		where kt.KingdomId = @KingdomId 
		
	UNION

	SELECT *, 'Dostepny' as 'TechnologyStatus' FROM SepTechnology t
		where TechnologyId not in (Select TechnologyId from SepKingdomTechnology where KingdomId = @KingdomId)
		and t.TechnologyCost <= @KingdomResources

	UNION
	
	SELECT *, 'Niedostępny' as 'TechnologyStatus' FROM SepTechnology t
		where TechnologyId not in (Select TechnologyId from SepKingdomTechnology where KingdomId = @KingdomId)
		and t.TechnologyCost > @KingdomResources

END
