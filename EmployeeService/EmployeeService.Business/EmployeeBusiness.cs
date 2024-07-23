using EmployeeService.DataAccess.Services;
using EmployeeService.Domain.Dtos;
using EmployeeService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService.Business
{
    public class EmployeeBusiness (EmployeesService employeeService)
    {
        private readonly EmployeesService _employeeService = employeeService;

        public List<EmployeeDto> GetEmployeesAsync()
        {
            var employeesRs = _employeeService.GetEmployeesAsync();
            var employees = new List<EmployeeDto>();
            foreach (var employee in employeesRs)
            {
                employees.Add(CalculateAnnualSalary(employee));
            }
            return employees;
        }

        public async Task<EmployeeDto> GetEmployeeByIdAsync(int id)
        {
            var employeeRs = await _employeeService.GetEmployeeByIdAsync(id);
            var employee = CalculateAnnualSalary(employeeRs);
            return employee;
        }

        private EmployeeDto CalculateAnnualSalary(Employee input)
        {
            var employee = new EmployeeDto()
            {
                id = input.id,
                employee_age = input.employee_age,
                employee_salary = input.employee_salary,
                employee_name = input.employee_name,
                profile_image = input.profile_image,
                employee_anual_salary = input.employee_salary * 12
            };

            return employee;
        }

    }
}
