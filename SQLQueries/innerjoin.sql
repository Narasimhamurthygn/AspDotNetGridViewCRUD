use SalesDB
select Orders.OrderID, Customers.CustomerName, Orders.OrderDate
from  Orders
inner join Customers
on Orders.CustomerID = Customers.CustomerID