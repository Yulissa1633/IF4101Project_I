USE [IF4101_B91472_B92299]
GO
SET ANSI_NULLS ON 
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE[dbo].[GetStudent]  @User nvarchar(100), @Password varchar (30)
AS BEGIN
	SELECT * FROM STUDENT WHERE @User = [User] AND @Password = [Password];
	END

