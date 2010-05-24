-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jakub Martyna
-- Create date: 24.05.2010
-- =============================================
CREATE PROCEDURE SepOrderGetById
	@OrderId int
AS
BEGIN
	select so.OrderId, so.OrderTypeId, sot.OrderTypeName, so.FieldId, so.FieldIdDestination, so.OrderTime, so.Epoch 
	from SepOrder as so inner join SepOrderType as sot on so.OrderTypeId=sot.OrderTypeId
	where so.OrderId = @OrderId
END
GO
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jakub Martyna
-- Create date: 24.05.2010
-- =============================================
CREATE PROCEDURE SepOrderGetAll
AS
BEGIN
	select so.OrderId, so.OrderTypeId, sot.OrderTypeName, so.FieldId, so.FieldIdDestination, so.OrderTime, so.Epoch 
	from SepOrder as so inner join SepOrderType as sot on so.OrderTypeId=sot.OrderTypeId
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jakub Martyna
-- Create date: 24.05.2010
-- =============================================
CREATE PROCEDURE SepOrderGetByEpoch
	@Epoch int
AS
BEGIN
	select so.OrderId, so.OrderTypeId, sot.OrderTypeName, so.FieldId, so.FieldIdDestination, so.OrderTime, so.Epoch 
	from SepOrder as so inner join SepOrderType as sot on so.OrderTypeId=sot.OrderTypeId
	where so.Epoch = @Epoch
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jakub Martyna
-- Create date: 24.05.2010
-- =============================================
CREATE PROCEDURE SepOrderGetByDateFrame
	@DateStart datetime
	,@DateEnd datetime
AS
BEGIN
	select so.OrderId, so.OrderTypeId, sot.OrderTypeName, so.FieldId, so.FieldIdDestination, so.OrderTime, so.Epoch 
	from SepOrder as so inner join SepOrderType as sot on so.OrderTypeId=sot.OrderTypeId
	where so.OrderTime < @DateEnd and so.OrderTime > @DateStart
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jakub Martyna
-- Create date: 24.05.2010
-- =============================================
CREATE PROCEDURE SepOrderAdd
	@FieldId int
	,@FieldIdDestination int
	,@OrderTypeId int
	,@Epoch int
AS
BEGIN
	insert into SepOrder (OrderTypeId,FieldId,FieldIdDestination,OrderTime,Epoch)
	values (@OrderTypeId,@FieldId,@FieldIdDestination,GETDATE(),@Epoch)
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jakub Martyna
-- Create date: 24.05.2010
-- =============================================
CREATE PROCEDURE SepOrderTypeAdd
	@OrderTypeName nvarchar(50)
AS
BEGIN
	insert into SepOrderType (OrderTypeName)
	values (@OrderTypeName)
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jakub Martyna
-- Create date: 24.05.2010
-- =============================================
CREATE PROCEDURE SepOrderTypeGetByName
	@OrderTypeName nvarchar(50)
AS
BEGIN
	select * from SepOrderType where OrderTypeName = @OrderTypeName
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jakub Martyna
-- Create date: 24.05.2010
-- =============================================
CREATE PROCEDURE SepOrderTypeGetById
	@OrderTypeId int
AS
BEGIN
	select * from SepOrderType where OrderTypeId = @OrderTypeId
END
GO
