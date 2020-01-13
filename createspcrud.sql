ALTER PROC  spEmployeesProcedure
(
@Id int,
@User_name nvarchar(250),
@Department  nvarchar(250),
@MngerId int,
@Action nvarchar(250)
)
As
BEGIN  
--SET NOCOUNT ON;
--SELECT
IF @Action = 'SELECT'
   BEGIN
      SELECT * FROM Employees
   END
--INSERT
IF @Action = 'INSERT'
   BEGIN
      INSERT INTO  Employees(Id,User_name,Department,MngerId) 
	  VALUES  (@Id,@User_name,@Department,@MngerId)
   END
--UPDATE
IF @Action = 'UPDATE'
   BEGIN
      UPDATE  Employees
	  SET Id = @Id,
			 User_name =@User_name,
			 Department = @Department,
			 MngerId = @MngerId
     WHERE  Id = @Id
    END
--DELETE
IF @Action = 'DELETE' 
   BEGIN
      DELETE FROM Employees
      WHERE Id = @Id
   END
END