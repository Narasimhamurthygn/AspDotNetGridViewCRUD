select Customers.CustomerID, Customers.CustomerName 
from  Customers
right join Orders on Orders.CustomerID = Customers.CustomerID
order by Orders.OrderID
