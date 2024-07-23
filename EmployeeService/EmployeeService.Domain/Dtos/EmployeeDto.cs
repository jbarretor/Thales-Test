using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService.Domain.Dtos
{
    public class EmployeeDto
    {
        public int id { get; set; }
        public string employee_name { get; set; }
        public int employee_salary { get; set; }
        public int employee_anual_salary { get; set; }
        public int employee_age { get; set; }
        public string profile_image { get; set; }
    }
}
