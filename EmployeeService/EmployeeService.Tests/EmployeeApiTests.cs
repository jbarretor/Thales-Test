using EmployeeService.API.Controllers;
using EmployeeService.Business;
using EmployeeService.DataAccess.Services;
using EmployeeService.Domain.Dtos;
using EmployeeService.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace EmployeeService.Tests
{
    public class EmployeeApiTests
    {
        private Mock<IService> _mockEmployeeService;
        private IEmployeeBusiness _employeeBusiness;
        private EmployeesController _controller;

        [SetUp]
        public void Setup()
        {
            _mockEmployeeService = new Mock<IService>();
            _employeeBusiness = new EmployeeBusiness(_mockEmployeeService.Object);
            _controller = new EmployeesController(_employeeBusiness);
        }

        [Test]
        public void GetEmployees_ReturnsOkResult_WithListOfEmployees()
        {
            // Arrange
            var employees = new List<Employee>
            {
                new Employee { id = 1, employee_name = "John", employee_salary = 1000, employee_age = 30, profile_image = "" },
                new Employee { id = 2, employee_name = "Jane", employee_salary = 2000, employee_age = 35, profile_image = "" },
                new Employee { id = 3, employee_name = "Carl", employee_salary = 3000, employee_age = 38, profile_image = "" }
            };
            _mockEmployeeService.Setup(m => m.GetAll()).Returns(employees);

            // Act
            var result = _controller.GetEmployees();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.IsInstanceOf<List<EmployeeDto>>(okResult.Value);
            Assert.AreEqual(3, (okResult.Value as List<EmployeeDto>).Count);
            foreach (var employee in okResult.Value as List<EmployeeDto>)
            {
                Assert.AreEqual(employee.employee_anual_salary, employee.employee_salary * 12);
            }
        }

        [Test]
        public void GetEmployees_ReturnsOkResult_WithOutEmployees()
        {
            // Arrange
            var employees = new List<Employee>
            {
            };
            _mockEmployeeService.Setup(m => m.GetAll()).Returns(employees);

            // Act
            var result = _controller.GetEmployees();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.IsInstanceOf<List<EmployeeDto>>(okResult.Value);
            Assert.AreEqual(0, (okResult.Value as List<EmployeeDto>).Count);
        }

        [Test]
        public async Task GetEmployee_ReturnsOkResult_WithEmployee()
        {
            // Arrange
            var employee = new Employee { id = 1, employee_name = "John", employee_salary = 1000, employee_age = 30, profile_image = "" };
            _mockEmployeeService.Setup(service => service.GetById(1)).Returns(employee);

            // Act
            var result = _controller.GetEmployee(1);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.IsInstanceOf<EmployeeDto>(okResult.Value);
            Assert.AreEqual((okResult.Value as EmployeeDto).employee_anual_salary, employee.employee_salary * 12);
        }

        [Test]
        public async Task GetEmployee_ReturnsNotFoundResult_WhenEmployeeNotFound()
        {
            // Arrange
            _mockEmployeeService.Setup(service => service.GetById(1)).Returns((Employee)null);

            // Act
            var result = _controller.GetEmployee(1);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }
    }
}