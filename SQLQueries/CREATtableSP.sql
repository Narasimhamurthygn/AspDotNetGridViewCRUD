CREATE PROC spLogin
AS
BEGIN
CREATE TABLE TblLogin
(
UserId int primary key not null,
UserName  nvarchar(250) not null,
Password  nvarchar(250) not null,
Admin  bit not null
)
END
 
