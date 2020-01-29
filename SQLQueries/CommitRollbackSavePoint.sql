BEGIN TRANSACTION
--save transaction point1

delete from Customers
where CustomerID=9
--save transaction point2

delete from Customers
where CustomerID=10
--save transaction point3

--commit transaction
commit

--rollback transaction point2
rollback

use SalesDB
select * from Customers

insert into Customers(CustomerID, CustomerName, ContactName,Address,City,PostalCode,Country)
values (10,'Praksha','GN','120 Hanover Sq.','Bangalore','Hosaroad','India')

insert into Customers(CustomerID, CustomerName, ContactName,Address,City,PostalCode,Country)
values (9,'Naveen','GN','No.98,GHalli.','Tumkuru','561202','India')

---Release SAVEPOINT point2