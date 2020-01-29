use SalesDB
select Customers.CustomerName, Orders.OrderID from Customers
left join Orders on  Customers.CustomerID = Orders.CustomerID
order by Customers.CustomerName