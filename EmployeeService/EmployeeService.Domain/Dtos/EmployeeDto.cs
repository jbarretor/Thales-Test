﻿namespace EmployeeService.Domain.Dtos
{
    public class EmployeeDto
    {
        public int id { get; set; }
        public string employee_name { get; set; }
        public int employee_salary { get; set; }
        public int employee_annual_salary { get; set; }
        public int employee_age { get; set; }
        public string profile_image { get; set; }
    }
}
