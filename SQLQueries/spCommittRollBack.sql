USE SalesDB
GO
ALTER PROCEDURE spCommitRollback
@CustomerID int
AS
BEGIN 
SET XACT_ABORT ON;  
 BEGIN TRY
   Delete from Customers
   Where CustomerID = @CustomerID

  -- Delete from Customers
  -- Where CustomerID = 12

   Commit TRAN
   Print 'Transaction Committed'
 END TRY 

 BEGIN CATCH
 BEGIN TRAN
 IF(@CustomerID> 0)
  Rollback TRAN
  Print 'Transaction Rolled Back'
  END CATCH
END 
