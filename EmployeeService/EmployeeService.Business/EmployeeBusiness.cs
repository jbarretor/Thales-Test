using EmployeeService.DataAccess.Services;
using EmployeeService.Domain.Dtos;
using EmployeeService.Domain.Models;

namespace EmployeeService.Business
{
    public class EmployeeBusiness(IService employeeService) : IEmployeeBusiness
    {
        private readonly IService _employeeService = employeeService;

        public List<EmployeeDto> GetEmployeesAsync()
        {
            var employeesRs = _employeeService.GetAll();
            var employees = new List<EmployeeDto>();
            foreach (var employee in employeesRs)
            {
                employees.Add(CalculateAnnualSalary(employee));
            }
            return employees;
        }

        public EmployeeDto GetEmployeeByIdAsync(int id)
        {
            var employeeRs = _employeeService.GetById(id);
            if (employeeRs == null)
            {
                return null;
            }
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
                employee_annual_salary = input.employee_salary * 12
            };

            return employee;
        }

    }
}
