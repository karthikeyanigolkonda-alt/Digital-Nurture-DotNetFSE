USE CTS_Week2_Index;
GO

CREATE PROCEDURE GetAllEmployees
AS
BEGIN
    SELECT * FROM Employees_SP;
END;
GO

EXEC GetAllEmployees;