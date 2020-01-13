Select e1.User_name EmployeeName, e2.User_name AS ManagerName
from Employees e1
Inner join Employees e2
on e1.MngerId = e2.Id
where e1.Id = 504

