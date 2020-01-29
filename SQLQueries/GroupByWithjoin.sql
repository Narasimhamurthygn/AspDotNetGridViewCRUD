select count(CustomerID), Country
from Customers
group by Country
order by Country desc


select Shippers.ShipperName, Count(Orders.OrderID) as NumberOfOrders from Orders
left join Shippers On Orders.CustomerID = Shippers.ShipperID
Group by ShipperName

select * from Orders
select * from Shippers
select * from Customers