﻿using EmployeeService.Domain.Models;
using System.Net;
using System.Net.Http.Json;

namespace EmployeeService.DataAccess.Services
{
    public class EmployeesService(HttpClient httpClient) : IService
    {
        private readonly HttpClient _httpClient = httpClient;

        public List<Employee> GetAll()
        {
            try
            {
                var response = _httpClient.GetAsync("/api/v1/employees").Result;

                if (response == null)
                {
                    throw new Exception($"The service isn't responding.");
                }
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception($"StatusCode: ({response.StatusCode}) {(int)response.StatusCode} >> The execution is not successful.");
                }

                var result = response.Content.ReadFromJsonAsync<EmployeesResponse>().Result;

                if (!result.status.Equals("success"))
                {
                    throw new Exception($"Something went wrong during execution >> Service Response: {result.message}");
                }

                return result.data;
            }
            finally
            {
                _httpClient.Dispose();
            }
        }

        public Employee GetById(int id)
        {
            try
            {
                var response = _httpClient.GetAsync($"/api/v1/employee/{id}").Result;

                if (response == null)
                {
                    throw new Exception($"The service isn't responding.");
                }
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception($"StatusCode: ({response.StatusCode}) {(int)response.StatusCode} >> The execution is not successful.");
                }

                var result = response.Content.ReadFromJsonAsync<EmployeeByIdResponse>().Result;

                if (!result.status.Equals("success"))
                {
                    throw new Exception($"Something went wrong during execution >> Service Response: {result.message}");
                }

                return result.data;
            }
            finally
            {
                _httpClient.Dispose();
            }
        }
    }
}
