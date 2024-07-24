using EmployeeService.Domain.Models;

namespace EmployeeService.DataAccess.Services
{
    public interface IService
    {

        public List<Employee> GetAll();

        public Employee GetById(int id);

    }
}
