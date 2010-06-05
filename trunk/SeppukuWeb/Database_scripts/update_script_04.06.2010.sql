SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SepEpoch](
	[EpochId] [int] NOT NULL,
	[MapId] [int] NOT NULL,
	[EpochStart] [datetime] NOT NULL,
 CONSTRAINT [PK_SepEpoch] PRIMARY KEY CLUSTERED 
(
	[EpochId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[SepEpoch]  WITH CHECK ADD  CONSTRAINT [FK_SepEpoch_SepMap] FOREIGN KEY([MapId])
REFERENCES [dbo].[SepMap] ([MapId])
GO

ALTER TABLE [dbo].[SepEpoch] CHECK CONSTRAINT [FK_SepEpoch_SepMap]
GO



SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SepOrderUnitType](
	[UnitTypeId] [int] NOT NULL,
	[OrderId] [int] NOT NULL,
	[Count] [int] NOT NULL,
	[OrderUnitTypeId] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_SepOrderUnitType] PRIMARY KEY CLUSTERED 
(
	[OrderUnitTypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[SepOrderUnitType]  WITH CHECK ADD  CONSTRAINT [FK_SepOrderUnitType_SepOrder] FOREIGN KEY([OrderId])
REFERENCES [dbo].[SepOrder] ([OrderId])
GO

ALTER TABLE [dbo].[SepOrderUnitType] CHECK CONSTRAINT [FK_SepOrderUnitType_SepOrder]
GO

ALTER TABLE [dbo].[SepOrderUnitType]  WITH CHECK ADD  CONSTRAINT [FK_SepOrderUnitType_SepUnitType] FOREIGN KEY([UnitTypeId])
REFERENCES [dbo].[SepUnitType] ([UnitTypeId])
GO

ALTER TABLE [dbo].[SepOrderUnitType] CHECK CONSTRAINT [FK_SepOrderUnitType_SepUnitType]
GO




SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SepOrderType](
	[OrderTypeId] [int] IDENTITY(1,1) NOT NULL,
	[OrderTypeName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_SepOrderType] PRIMARY KEY CLUSTERED 
(
	[OrderTypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO



SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SepUnitType](
	[UnitTypeId] [int] IDENTITY(1,1) NOT NULL,
	[UnitTypeName] [nvarchar](50) NOT NULL,
	[UnitTypeDescription] [nvarchar](150) NOT NULL,
	[UnitTypePower] [int] NOT NULL,
	[UnitTypeHealthPoint] [int] NULL,
 CONSTRAINT [PK_SepUnitType] PRIMARY KEY CLUSTERED 
(
	[UnitTypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SepUnit](
	[UnitId] [int] NOT NULL,
	[UnitName] [nvarchar](50) NOT NULL,
	[UnitTypeId] [int] NOT NULL,
	[KingdomId] [int] NOT NULL,
	[FieldId] [int] NOT NULL,
	[Count] [int] NULL,
 CONSTRAINT [PK_SepUnit] PRIMARY KEY CLUSTERED 
(
	[UnitId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[SepUnit]  WITH CHECK ADD  CONSTRAINT [FK_SepUnit_SepField] FOREIGN KEY([FieldId])
REFERENCES [dbo].[SepField] ([FieldId])
GO

ALTER TABLE [dbo].[SepUnit] CHECK CONSTRAINT [FK_SepUnit_SepField]
GO

ALTER TABLE [dbo].[SepUnit]  WITH CHECK ADD  CONSTRAINT [FK_SepUnit_SepKingdom] FOREIGN KEY([UnitId])
REFERENCES [dbo].[SepKingdom] ([KingdomId])
GO

ALTER TABLE [dbo].[SepUnit] CHECK CONSTRAINT [FK_SepUnit_SepKingdom]
GO

ALTER TABLE [dbo].[SepUnit]  WITH CHECK ADD  CONSTRAINT [FK_SepUnit_SepUnitType] FOREIGN KEY([UnitTypeId])
REFERENCES [dbo].[SepUnitType] ([UnitTypeId])
GO

ALTER TABLE [dbo].[SepUnit] CHECK CONSTRAINT [FK_SepUnit_SepUnitType]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SepOrderUnitType](
	[UnitTypeId] [int] NOT NULL,
	[OrderId] [int] NOT NULL,
	[Count] [int] NOT NULL,
	[OrderUnitTypeId] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_SepOrderUnitType] PRIMARY KEY CLUSTERED 
(
	[OrderUnitTypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[SepOrderUnitType]  WITH CHECK ADD  CONSTRAINT [FK_SepOrderUnitType_SepOrder] FOREIGN KEY([OrderId])
REFERENCES [dbo].[SepOrder] ([OrderId])
GO

ALTER TABLE [dbo].[SepOrderUnitType] CHECK CONSTRAINT [FK_SepOrderUnitType_SepOrder]
GO

ALTER TABLE [dbo].[SepOrderUnitType]  WITH CHECK ADD  CONSTRAINT [FK_SepOrderUnitType_SepUnitType] FOREIGN KEY([UnitTypeId])
REFERENCES [dbo].[SepUnitType] ([UnitTypeId])
GO

ALTER TABLE [dbo].[SepOrderUnitType] CHECK CONSTRAINT [FK_SepOrderUnitType_SepUnitType]
GO





SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jakub Martyna
-- Create date: 04.06.2010
-- Description:	Zwraca wszystkie pola z danej mapy
-- =============================================
CREATE PROCEDURE [dbo].[SepFieldGetByMapId]
	@MapId int
AS
BEGIN
	SELECT * FROM SepField as sf
	WHERE sf.MapId = @MapId
END


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jakub Martyna
-- Create date: 04.06.2010
-- Description:	Dodaje nowa epoke do mapy
-- =============================================
CREATE PROCEDURE [dbo].[SepNewEpochForMap]
	@MapId int
AS
BEGIN
	INSERT INTO SepEpoch (MapId,EpochStart) values(@MapId,GETDATE())
END

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jakub Martyna
-- Create date: 04.06.2010
-- =============================================
CREATE PROCEDURE [dbo].[SepEpochGetById]
	@EpochId int
AS
BEGIN
	SELECT * FROM SepEpoch
	WHERE EpochId = @EpochId
END

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jakub Martyna
-- Create date: 04.06.2010
-- =============================================
CREATE PROCEDURE [dbo].[SepEpochGetCurrentByMapId]
	@MapId int
AS
BEGIN
	SELECT top 1 * FROM SepEpoch
	WHERE MapId = @MapId 
	Order by EpochId
END

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jakub Martyna
-- Create date: 24.05.2010
-- =============================================
ALTER PROCEDURE [dbo].[SepOrderGetById]
	@OrderId int
AS
BEGIN
	select so.OrderId, so.OrderTypeId, sot.OrderTypeName, so.FieldId, so.FieldIdDestination, so.OrderTime, so.Epoch, sout.Count, sout.UnitTypeId, so.KingdomId
	from SepOrder as so inner join SepOrderType as sot on so.OrderTypeId=sot.OrderTypeId
						inner join SepOrderUnitType as sout on so.OrderId=sout.OrderId
	where so.OrderId = @OrderId
END

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jakub Martyna
-- Create date: 24.05.2010
-- =============================================
ALTER PROCEDURE [dbo].[SepOrderGetByFieldEpoch]
	@Epoch int
	,@FieldIdDestination int
AS
BEGIN
	select so.OrderId, so.OrderTypeId, sot.OrderTypeName, so.FieldId, so.FieldIdDestination, so.OrderTime, so.Epoch, sout.Count, sout.UnitTypeId, so.KingdomId
	from SepOrder as so inner join SepOrderType as sot on so.OrderTypeId=sot.OrderTypeId
						inner join SepOrderUnitType as sout on so.OrderId=sout.OrderId
	where so.Epoch = @Epoch and so.FieldIdDestination=@FieldIdDestination
END

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jakub Martyna
-- Create date: 24.05.2010
-- =============================================
ALTER PROCEDURE [dbo].[SepOrderGetByEpoch]
	@Epoch int
AS
BEGIN
	select so.OrderId, so.OrderTypeId, sot.OrderTypeName, so.FieldId, so.FieldIdDestination, so.OrderTime, so.Epoch, sout.Count, sout.UnitTypeId, so.KingdomId
	from SepOrder as so inner join SepOrderType as sot on so.OrderTypeId=sot.OrderTypeId
						inner join SepOrderUnitType as sout on so.OrderId=sout.OrderId
	where so.Epoch = @Epoch
END

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jakub Martyna
-- Create date: 24.05.2010
-- =============================================
ALTER PROCEDURE [dbo].[SepOrderGetByDateFrame]
	@DateStart datetime
	,@DateEnd datetime
AS
BEGIN
	select so.OrderId, so.OrderTypeId, sot.OrderTypeName, so.FieldId, so.FieldIdDestination, so.OrderTime, so.Epoch, sout.Count, sout.UnitTypeId, so.KingdomId
	from SepOrder as so inner join SepOrderType as sot on so.OrderTypeId=sot.OrderTypeId
						inner join SepOrderUnitType as sout on so.OrderId=sout.OrderId
	where so.OrderTime < @DateEnd and so.OrderTime > @DateStart
END

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jakub Martyna
-- Create date: 24.05.2010
-- =============================================
ALTER PROCEDURE [dbo].[SepOrderGetAll]
AS
BEGIN
	select so.OrderId, so.OrderTypeId, sot.OrderTypeName, so.FieldId, so.FieldIdDestination, so.OrderTime, so.Epoch, sout.Count, sout.UnitTypeId, so.KingdomId
	from SepOrder as so inner join SepOrderType as sot on so.OrderTypeId=sot.OrderTypeId
						inner join SepOrderUnitType as sout on so.OrderId=sout.OrderId
END
						
						
						SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		£ukasz Wiatrak
-- Create date: 06.03.2010
-- =============================================
ALTER PROCEDURE [dbo].[SepUnitAdd]
	 @UnitName nvarchar(50)
	,@UnitTypeId int
	,@KingdomId int
	,@FieldId int
	,@Count int
AS
BEGIN
	declare @UnitId int

	INSERT INTO [dbo].[SepUnit]
           ([UnitName]
           ,[UnitTypeId]
           ,[KingdomId]
           ,[FieldId]
           ,[Count] 
           )
     VALUES
           (@UnitName
           ,@UnitTypeId
           ,@KingdomId
           ,@FieldId
           ,@Count
           )
           
    set @UnitId = SCOPE_IDENTITY()           
    select @UnitId
END

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		£ukasz Wiatrak
-- Create date: 11.03.2010
-- =============================================
ALTER PROCEDURE [dbo].[SepUnitGetById]
	@UnitId int
AS
BEGIN
	SELECT * FROM SepUnit WHERE UnitId = @UnitId
END

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Jakub Martyna
-- Create date: 05.06.2010
-- =============================================
CREATE PROCEDURE [dbo].[SepUnitRemove]
	 @UnitId int
AS
BEGIN
	DELETE FROM SepUnit where UnitId =@UnitId
END

GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		£ukasz Wiatrak
-- Create date: 06.03.2010
-- =============================================
CREATE PROCEDURE [dbo].[SepUnitUpdate]
	 @UnitId int
	,@UnitName nvarchar(50)
	,@UnitTypeId int
	,@KingdomId int
	,@FieldId int
	,@Count int
AS
BEGIN
	UPDATE [dbo].[SepUnit]
		SET	 UnitName = @UnitName
			,UnitTypeId = @UnitTypeId
			,KingdomId = @KingdomId
			,FieldId = @FieldId
			,Count = @Count
		WHERE UnitId = @UnitId
END

GO



