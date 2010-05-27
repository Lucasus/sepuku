USE [Seppuku]
GO
/****** Object:  StoredProcedure [dbo].[DnMapGetAll]    Script Date: 05/27/2010 19:11:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SepMapGetAll]
AS
BEGIN
	SELECT MapId, MapName
		FROM SepMap
	ORDER BY MapName asc
END

GO

USE [Seppuku]
GO
/****** Object:  StoredProcedure [dbo].[DnMapRoleDelete]    Script Date: 05/27/2010 21:03:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SepMapDelete]
	@MapId int
AS
BEGIN
	DELETE FROM [dbo].[SepMap]
		  WHERE MapId = @MapId 
END

GO

USE [Seppuku]
GO
/****** Object:  StoredProcedure [dbo].[SepMapUpdate]    Script Date: 05/27/2010 21:13:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		£ukasz Wiatrak
-- Create date: 06.03.2010
-- =============================================
CREATE PROCEDURE [dbo].[SepMapUpdate]
	 @MapId int
	,@MapName nvarchar(50)
AS
BEGIN
	UPDATE [dbo].[SepMap]
		SET	 MapName = @MapName
		WHERE MapId = @MapId
END

GO
