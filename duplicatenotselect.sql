USE [UserDB]
GO
/****** Object:  StoredProcedure [dbo].[spEmployeeViewAll]    Script Date: 1/22/2020 10:20:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[spEmployeeViewAll]
AS
BEGIN
SELECT * FROM TblEmployees
WHERE UserName IN (SELECT UserName from TblEmployees GROUP BY UserName HAVING COUNT(1) > 1)
END