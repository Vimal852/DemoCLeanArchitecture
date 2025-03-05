using ApplicationLayer.DTO;
using DomainLayer.Entities;
using System.Net.Http.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace ApplicationLayer.Services
{
    public class EmployeeService : IEmployeeService
    {

        private readonly HttpClient httpClient;

        public EmployeeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<ServiceResponse> Addasync(Employee employee)
        {
            var data = await httpClient.PostAsJsonAsync ("api/employee", employee);
            var responce = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return responce;
        }

        public async Task<ServiceResponse> Deleteasync(int id)
        {
            var data = await httpClient.DeleteAsync ($"api/employee/{id}");
            var responce = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return responce;

        }

        public async Task<List<Employee>> Getasync() =>
            await httpClient.GetFromJsonAsync<List<Employee>>("api/employee")!;

        public async Task<Employee> Getbyidasync(int id) =>
            await httpClient.GetFromJsonAsync<Employee>($"api/employee/{id}")!;

        public async Task<ServiceResponse> Updateasync(Employee employee)
        {
            var data = await httpClient.PutAsJsonAsync("api/employee", employee);
            var responce = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return responce;
        }
    }
}
