USE [UserDB]
GO
/****** Object:  StoredProcedure [dbo].[spEmployeesMngrId]    Script Date: 1/8/2020 6:50:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[spEmployeesMngrId]
@Id int
AS
BEGIN
Select e1.Id, e1.User_name, e1.Department, e2.User_name AS ManagerName
from Employees e1
Inner join  Employees e2
on e1.MngerId = e2.Id
Where e1.Id = @Id
END

