use UserDB
GO
ALTER PROC spUserLogin
(
@UserId int,
@UserName  nvarchar(250),
@Password  nvarchar(250),
@Admin  bit out
--@Select bit 
)
AS
IF @Admin = 1
BEGIN
SELECT COUNT(*) from TblLogin 
WHERE username = @UserName and password = @Password
--SET @Admin =  @UserName + 'Admin User'
--SET @Select = @Admin 
--SET @Admin = 1
PRINT 'Admin User'
END
ELSE
BEGIN
 SELECT COUNT(*) from TblLogin 
 WHERE username = @UserName and password = @Password
-- SET @Admin = @UserName + 'Normal User'
--SET @Select = @Admin 
--SET @Admin =0
 PRINT 'Normal User'
END

