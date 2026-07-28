# EmployeeManagementAPI

## Testing

This project uses NUnit for unit testing and Moq for mocking repository dependencies.

### Purpose of unit testing

The unit tests verify the service layer behavior of the API without invoking real database or repository implementations. They ensure the employee service correctly handles data operations and repository interactions.

### Test cases covered

- Get all employees
- Get employee by ID
- Employee not found scenario
- Add employee
- Update employee
- Delete employee

### Test execution

Run the following command from the `EmployeeManagementAPI.Tests` project folder or solution root:

```bash
dotnet test
```

### Test result

- Total tests: 6
- Failed: 0
