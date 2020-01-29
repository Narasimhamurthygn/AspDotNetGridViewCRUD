USE SalesDB
GO
ALTER  PROCEDURE spCommittRolbackCustomer
AS
BEGIN 
 BEGIN TRY
   BEGIN TRAN
   Update Customers
   Set City = 'Cambridge'
   where CustomerID = 9 and Country=''

   Update Customers 
   Set  PostalCode = '560100'
   where CustomerID = 10 and Country= 'UK'
   Commit TRAN
   Print 'Transaction Committed'
 END TRY 
 BEGIN CATCH
   ROLLBACK TRAN
   Print 'Transaction Rolled Back'
  END CATCH
END 

select * from Customers