USE [UserDB]
GO
/****** Object:  StoredProcedure [dbo].[spInsertEmployee]    Script Date: 1/8/2020 3:35:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[spInsertEmployee]
(
@Id int,
@User_name nvarchar(250),
@Department nvarchar(250),
@MngerId int
)
AS
Insert into Employees values(@Id,@User_name,@Department,@MngerId)
