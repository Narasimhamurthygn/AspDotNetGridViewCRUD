CREATE PROC spInsertEmployee
(
@Id int,
@User_name nvarchar(250),
@Department nvarchar(250),
@MngerId int
)
AS
Insert into Employee values(@Id,@User_name,@Department,@MngerId)
