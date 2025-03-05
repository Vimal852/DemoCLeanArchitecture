using ApplicationLayer.DTO;
using DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services
{
    public interface IEmployeeService
    {
        Task<ServiceResponse> Addasync(Employee employee);
        Task<ServiceResponse> Updateasync(Employee employee);
        public Task<ServiceResponse> Deleteasync(int id);
        Task<List<Employee>> Getasync();
        Task<Employee> Getbyidasync(int id);
    }
}
