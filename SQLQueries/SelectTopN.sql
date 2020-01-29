--SELECT TOP (expression) [PERCENT]
---   [WITH TIES]
--FROM 
--    table_name
---ORDER BY 
--    column_name;

select top 8 CustomerName
from Customers
order by CustomerID Desc

select * from Customers