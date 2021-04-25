USE [IF4101_B91472_B92299]
GO
/****** Object:  StoredProcedure [dbo].[InsertStudent]    Script Date: 20/4/2021 
11:06:04 ******/
SET ANSI_NULLS ON 
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================
--Author:Esteban Sanabria
--Create date: 20/04/2021
--Description:SP to insert a student
--=============================================

CREATE PROCEDURE[dbo].[InsertStudent]  @User nvarchar(100),@Name nvarchar(100),@Email varchar(30),@Password varchar (30)
AS BEGIN
	--SET NOCOUNT ON added to prevent extra result sets from
	--SET NOCOUNT ON;
	
	--Insert statements for procedure
	INSERT INTO Student([User],[Name],Email,[Password])
	VALUES (@User,@Name,@Email,@Password)
	END

	DROP PROCEDURE[dbo].[InsertStudent]