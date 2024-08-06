Create PROCEDURE [dbo].[SP_GetEmployeeBaseOnDeparId]
	@deparId Int
AS
BEGIN
	Select * from mstEmployee where departmentid = @deparId
END
