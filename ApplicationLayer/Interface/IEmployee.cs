using ApplicationLayer.DTO;
using DomainLayer.Entities;

namespace ApplicationLayer.Interface
{
    public interface IEmployee
    {
        Task<ServiceResponse> Addasync(Employee employee);
        Task<ServiceResponse> Updateasync(Employee employee);
       public Task<ServiceResponse> Deleteasync(int id);
        Task<List<Employee>> Getasync();
        Task<Employee> Getbyidasync(int id);
    }
}
