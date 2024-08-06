Create PROCEDURE [dbo].[SP_GetEmployeeCountBaseOnDepartment]
	
AS
BEGIN
	select e.EmployeeName EmployeeName ,COUNT(d.departmentid) Count from mstEmployee e left join mstDepartment d
on e.departmentid = d.departmentid
group by e.EmployeeName
having count(d.departmentid) > 1
END