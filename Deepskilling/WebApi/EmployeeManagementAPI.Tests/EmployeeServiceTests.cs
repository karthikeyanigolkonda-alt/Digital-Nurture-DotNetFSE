#nullable enable
using System.Collections.Generic;
using EmployeeManagementAPI.Models;
using EmployeeManagementAPI.Repositories;
using EmployeeManagementAPI.Services;
using Moq;
using NUnit.Framework;

namespace EmployeeManagementAPI.Tests;

[TestFixture]
public class EmployeeServiceTests
{
    private Mock<IEmployeeRepository> _repositoryMock = null!;
    private EmployeeService _service = null!;

    [SetUp]
    public void SetUp()
    {
        _repositoryMock = new Mock<IEmployeeRepository>(MockBehavior.Strict);
        _service = new EmployeeService(_repositoryMock.Object);
    }

    [Test]
    public void GetAll_ReturnsEmployeeCollectionSuccessfully()
    {
        // Arrange
        var employees = new List<Employee>
        {
            new Employee { Id = 1, FirstName = "Alice", LastName = "Johnson", Email = "alice@example.com", Department = "Engineering" },
            new Employee { Id = 2, FirstName = "Bob", LastName = "Smith", Email = "bob@example.com", Department = "HR" }
        };

        _repositoryMock.Setup(r => r.GetAll()).Returns(employees);

        // Act
        var result = _service.GetAll();

        // Assert
        Assert.That(result, Is.EqualTo(employees));
        _repositoryMock.Verify(r => r.GetAll(), Times.Once);
    }

    [Test]
    public void GetById_ReturnsCorrectEmployee_WhenEmployeeExists()
    {
        // Arrange
        var expected = new Employee { Id = 1, FirstName = "Alice", LastName = "Johnson", Email = "alice@example.com", Department = "Engineering" };
        _repositoryMock.Setup(r => r.GetById(1)).Returns(expected);

        // Act
        var result = _service.GetById(1);

        // Assert
        Assert.That(result, Is.SameAs(expected));
        _repositoryMock.Verify(r => r.GetById(1), Times.Once);
    }

    [Test]
    public void GetById_ReturnsNull_WhenEmployeeDoesNotExist()
    {
        // Arrange
        _repositoryMock.Setup(r => r.GetById(999)).Returns((Employee?)null);

        // Act
        var result = _service.GetById(999);

        // Assert
        Assert.That(result, Is.Null);
        _repositoryMock.Verify(r => r.GetById(999), Times.Once);
    }

    [Test]
    public void Create_AddsNewEmployeeSuccessfully()
    {
        // Arrange
        var employeeToCreate = new Employee { FirstName = "Diana", LastName = "Prince", Email = "diana@example.com", Department = "Operations" };
        var createdEmployee = new Employee { Id = 3, FirstName = "Diana", LastName = "Prince", Email = "diana@example.com", Department = "Operations" };

        _repositoryMock.Setup(r => r.Create(employeeToCreate)).Returns(createdEmployee);

        // Act
        var result = _service.Create(employeeToCreate);

        // Assert
        Assert.That(result, Is.EqualTo(createdEmployee));
        _repositoryMock.Verify(r => r.Create(employeeToCreate), Times.Once);
    }

    [Test]
    public void Update_UpdatesEmployeeDetailsSuccessfully_WhenEmployeeExists()
    {
        // Arrange
        var employeeToUpdate = new Employee { FirstName = "Alice", LastName = "Updated", Email = "alice.updated@example.com", Department = "Engineering" };
        var updatedEmployee = new Employee { Id = 1, FirstName = "Alice", LastName = "Updated", Email = "alice.updated@example.com", Department = "Engineering" };

        _repositoryMock.Setup(r => r.Update(1, employeeToUpdate)).Returns(updatedEmployee);

        // Act
        var result = _service.Update(1, employeeToUpdate);

        // Assert
        Assert.That(result, Is.EqualTo(updatedEmployee));
        _repositoryMock.Verify(r => r.Update(1, employeeToUpdate), Times.Once);
    }

    [Test]
    public void Delete_RemovesEmployeeSuccessfully_WhenEmployeeExists()
    {
        // Arrange
        _repositoryMock.Setup(r => r.Delete(1)).Returns(true);

        // Act
        var result = _service.Delete(1);

        // Assert
        Assert.That(result, Is.True);
        _repositoryMock.Verify(r => r.Delete(1), Times.Once);
    }
}
