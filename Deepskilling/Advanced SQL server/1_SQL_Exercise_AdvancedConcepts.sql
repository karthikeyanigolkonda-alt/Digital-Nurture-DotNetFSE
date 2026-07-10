USE CTS_Week2_SQL;
GO

SELECT
    EmployeeID,
    FirstName,
    LastName,
    Salary,
    DENSE_RANK() OVER (ORDER BY Salary DESC) AS DenseSalaryRank
FROM Employees;