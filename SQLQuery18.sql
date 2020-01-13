USE [UserDB]
GO
/****** Object:  StoredProcedure [dbo].[spEmployeesMngrId]    Script Date: 1/7/2020 2:47:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[spEmployeesMngrId]
@Id int,
@MngerId int 
AS
BEGIN
Select @Id = Id from Employees
  Where MngerId = @MngerId
END
