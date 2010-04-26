USE [Seppuku]
GO
/****** Object:  Table [dbo].[DnUser]    Script Date: 04/11/2010 17:08:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DnUser](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](255) NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
	[CreateDate] [datetime] NULL,
	[IsApproved] [bit] NULL,
	[Password] [nvarchar](500) NULL,
 CONSTRAINT [PK_DnUser] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DnRole]    Script Date: 04/11/2010 17:08:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DnRole](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_DnRole] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DnChangePassword]    Script Date: 04/11/2010 17:08:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DnChangePassword](
	[ChangePasswordId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[ChangePasswordKey] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DnAuthorizationKey]    Script Date: 04/11/2010 17:08:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DnAuthorizationKey](
	[AuthorizationKeyId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[KeyGuid] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_DnAuthorizationKey] PRIMARY KEY CLUSTERED 
(
	[AuthorizationKeyId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[DnUserGetByEmail]    Script Date: 04/11/2010 17:08:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		£ukasz Wiatrak
-- Create date: 11.03.2010
-- Description:	Zwraca uzytkownika po emailu
-- =============================================
CREATE PROCEDURE [dbo].[DnUserGetByEmail]
	@Email nvarchar(255)
AS
BEGIN
	SELECT UserId, UserName, CreateDate, IsApproved, Email
		FROM DnUser
		WHERE Email = @Email 
END
GO
/****** Object:  StoredProcedure [dbo].[DnUserGetAll]    Script Date: 04/11/2010 17:08:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		£ukasz Wiatrak
-- Create date: 11.03.2010
-- Description:	Zwraca uzytkownika po emailu
-- =============================================
CREATE PROCEDURE [dbo].[DnUserGetAll]
AS
BEGIN
	SELECT UserId, UserName, CreateDate, IsApproved, Email
		FROM DnUser
	ORDER BY UserName asc
END
GO
/****** Object:  StoredProcedure [dbo].[DnUserCount]    Script Date: 04/11/2010 17:08:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		£ukasz Wiatrak
-- Create date: 11.03.2010
-- Description:	Zwraca uzytkownika po emailu
-- =============================================
CREATE PROCEDURE [dbo].[DnUserCount]
AS
BEGIN
	SELECT COUNT(*) FROM DnUser
END
GO
/****** Object:  Table [dbo].[DnUserRole]    Script Date: 04/11/2010 17:08:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DnUserRole](
	[UserRoleId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_DnUserRole] PRIMARY KEY CLUSTERED 
(
	[UserRoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[DnRoleGetAll]    Script Date: 04/11/2010 17:08:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		£ukasz Wiatrak
-- Create date: 11.03.2010
-- Description:	Zwraca role u¿ytkownika
-- =============================================
CREATE PROCEDURE [dbo].[DnRoleGetAll]
AS
BEGIN
	SELECT r.RoleId, r.RoleName
		FROM DnRole r
END
GO
/****** Object:  StoredProcedure [dbo].[DnUserValidate]    Script Date: 04/11/2010 17:08:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		£ukasz Wiatrak
-- Create date: 11.03.2010
-- Description:	Sprawdza czy u¿ytkownik z podanym loginem i has³em mo¿e siê zalogowaæ
-- =============================================
CREATE PROCEDURE [dbo].[DnUserValidate]
	@UserName nvarchar(255),
	@Password nvarchar(100)
AS
BEGIN
	IF EXISTS (SELECT UserId FROM DnUser
		WHERE UserName = @UserName AND Password = @Password AND IsApproved = 1)
	BEGIN
		select 1
	END
	ELSE
	BEGIN
		select 0
	END
END
GO
/****** Object:  StoredProcedure [dbo].[DnUserRoleDelete]    Script Date: 04/11/2010 17:08:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DnUserRoleDelete]
	@UserName nvarchar(255),
	@RoleName nvarchar(255)
AS
BEGIN
	declare @UserId int
	set @UserId = (Select UserId from DnUser where UserName = @UserName)

	declare @RoleId int
	set @RoleId = (Select RoleId from DnRole where RoleName = @RoleName)

	DELETE FROM [dbo].[DnUserRole]
		  WHERE UserId = @UserId and RoleId = @RoleId
END
GO
/****** Object:  StoredProcedure [dbo].[DnUserRoleAdd]    Script Date: 04/11/2010 17:08:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DnUserRoleAdd]
	@UserName nvarchar(255),
	@RoleName nvarchar(255)
AS
BEGIN
	declare @UserRoleId int

	declare @UserId int
	set @UserId = (Select UserId from DnUser where UserName = @UserName)

	declare @RoleId int
	set @RoleId = (Select RoleId from DnRole where RoleName = @RoleName)

	INSERT INTO [dbo].[DnUserRole]
           ([UserId]
           ,[RoleId] 
           )
     VALUES
           (@UserId
           ,@RoleId
           )

    set @UserRoleId = SCOPE_IDENTITY()
           
    select @UserId
END
GO
/****** Object:  StoredProcedure [dbo].[DnUserGetByLogin]    Script Date: 04/11/2010 17:08:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		£ukasz Wiatrak
-- Create date: 04.03.2010
-- Description:	Zwraca uzytkownika po loginie
-- =============================================
CREATE PROCEDURE [dbo].[DnUserGetByLogin]
	@UserName nvarchar(255)
AS
BEGIN
	--RAISERROR('B³¹d jakiœ!', 17, 1)
	SELECT u.UserId, UserName, CreateDate, IsApproved, Email, KeyGuid
		FROM DnUser u
			LEFT JOIN DnAuthorizationKey ak on u.UserId = ak.UserId 
		WHERE UserName = @UserName 
END
GO
/****** Object:  StoredProcedure [dbo].[DnUserAuthorize]    Script Date: 04/11/2010 17:08:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		£ukasz Wiatrak
-- Create date: 06.03.2010
-- Description:	Aktywuje u¿ytkownika
-- =============================================
CREATE PROCEDURE [dbo].[DnUserAuthorize]
	@UserName nvarchar(255),
	@AuthorizationKey nvarchar(50)
AS
BEGIN
	declare @UserId int
	set @UserId = (select UserId from DnUser where UserName = @UserName)
	IF @UserId IS NULL
	BEGIN
		RAISERROR('Invalid UserName', 17, 1)
	END	
	ELSE
	BEGIN
		IF EXISTS (SELECT UserId from DnAuthorizationKey WHERE KeyGuid = @AuthorizationKey and UserId = @UserId)
		BEGIN
			IF EXISTS (SELECT UserId from DnUser WHERE UserId = @UserId and IsApproved = 1)
			BEGIN
				RAISERROR('Already Approved', 17, 1)				
			END
			ELSE
			BEGIN		
				UPDATE [dbo].[DnUser]
				   SET [IsApproved] = 1
				 WHERE UserName = @UserName	
			END
		END
		ELSE
		BEGIN
			RAISERROR('Invalid Authentication Key', 18, 1)
		END
	END
	
END
GO
/****** Object:  StoredProcedure [dbo].[DnUserAdd]    Script Date: 04/11/2010 17:08:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		£ukasz Wiatrak
-- Create date: 06.03.2010
-- Description:	Dodaje uzytkownika
-- =============================================
CREATE PROCEDURE [dbo].[DnUserAdd]
	@UserName nvarchar(255),
	@Email nvarchar(255),
	@Password nvarchar(255),
	@CreateDate datetime,
	@AuthorizationKey nvarchar(50)
AS
BEGIN
	declare @UserId int

	INSERT INTO [dbo].[DnUser]
           ([UserName]
           ,[Email] 
           ,[Password] 
           ,[CreateDate] 
           ,[IsApproved]
           )
     VALUES
           (@UserName
           ,@Email
           ,@Password
           ,@CreateDate
           ,0
           )
    set @UserId = SCOPE_IDENTITY()

	INSERT INTO [dbo].[DnAuthorizationKey] 
           ([UserId] 
           ,[KeyGuid]  
           )
     VALUES
           (@UserId
           ,@AuthorizationKey
           )
           
    select @UserId
END
GO
/****** Object:  StoredProcedure [dbo].[DnRoleGetByUserName]    Script Date: 04/11/2010 17:08:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		£ukasz Wiatrak
-- Create date: 11.03.2010
-- Description:	Zwraca role u¿ytkownika
-- =============================================
CREATE PROCEDURE [dbo].[DnRoleGetByUserName]
	@UserName nvarchar(255)
AS
BEGIN
	SELECT r.RoleId, r.RoleName
		FROM DnUserRole ur
		INNER JOIN DnRole r on r.RoleId = ur.RoleId
		INNER JOIN DnUser u on u.UserId = ur.UserId
		WHERE u.UserName = @UserName
END
GO
/****** Object:  StoredProcedure [dbo].[DnRoleGetByUserId]    Script Date: 04/11/2010 17:08:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		£ukasz Wiatrak
-- Create date: 11.03.2010
-- Description:	Zwraca role u¿ytkownika
-- =============================================
CREATE PROCEDURE [dbo].[DnRoleGetByUserId]
	@UserId int
AS
BEGIN
	SELECT r.RoleId, r.RoleName
		FROM DnUserRole ur
		INNER JOIN DnRole r on r.RoleId = ur.RoleId
		WHERE ur.UserId = @UserId
END
GO
/****** Object:  ForeignKey [FK_DnAuthorizationKey_DnUser]    Script Date: 04/11/2010 17:08:06 ******/
ALTER TABLE [dbo].[DnAuthorizationKey]  WITH CHECK ADD  CONSTRAINT [FK_DnAuthorizationKey_DnUser] FOREIGN KEY([UserId])
REFERENCES [dbo].[DnUser] ([UserId])
GO
ALTER TABLE [dbo].[DnAuthorizationKey] CHECK CONSTRAINT [FK_DnAuthorizationKey_DnUser]
GO
/****** Object:  ForeignKey [FK_DnUserRole_DnRole]    Script Date: 04/11/2010 17:08:26 ******/
ALTER TABLE [dbo].[DnUserRole]  WITH CHECK ADD  CONSTRAINT [FK_DnUserRole_DnRole] FOREIGN KEY([RoleId])
REFERENCES [dbo].[DnRole] ([RoleId])
GO
ALTER TABLE [dbo].[DnUserRole] CHECK CONSTRAINT [FK_DnUserRole_DnRole]
GO
/****** Object:  ForeignKey [FK_DnUserRole_DnUser]    Script Date: 04/11/2010 17:08:26 ******/
ALTER TABLE [dbo].[DnUserRole]  WITH CHECK ADD  CONSTRAINT [FK_DnUserRole_DnUser] FOREIGN KEY([UserId])
REFERENCES [dbo].[DnUser] ([UserId])
GO
ALTER TABLE [dbo].[DnUserRole] CHECK CONSTRAINT [FK_DnUserRole_DnUser]
GO
