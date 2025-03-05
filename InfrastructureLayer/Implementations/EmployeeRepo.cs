using ApplicationLayer.DTO;
using ApplicationLayer.Interface;
using Data.AppDbContext;
using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Implementation
{
    public class EmployeeRepo : IEmployee
    {
        private readonly AppDbContext _context;

        public EmployeeRepo(AppDbContext context)
        {
            _context = context;
        }

        // ✅ Add a new employee
        public async Task<ServiceResponse> Addasync(Employee employee)
        {
            _context.Employees.Add(employee);
            await Savechanges();
            return new ServiceResponse(true, "Employee added successfully");
        }

        // ✅ Get all employees
        public async Task<List<Employee>> Getasync() => await _context.Employees.AsNoTracking().ToListAsync();

        // ✅ Get employee by ID
        public async Task<Employee> Getbyidasync(int id) => await _context.Employees.FindAsync(id);

        // ✅ Update an existing employee
        async Task<ServiceResponse> IEmployee.Updateasync(Employee employee)
        {
            try
            {
                var existingEmployee = await _context.Employees.FindAsync(employee.Id);
                if (existingEmployee == null)
                {
                    return new ServiceResponse(false, "Employee not found!");
                }

                // Update employee properties
                existingEmployee.Name = employee.Name;
                existingEmployee.address = employee.address;

                _context.Employees.Update(existingEmployee);
                await Savechanges();
                return new ServiceResponse(true, "Employee updated successfully!");
            }
            catch (Exception ex)
            {
                return new ServiceResponse(false, $"Error: {ex.Message}");
            }
        }

        // ✅ Delete an employee
        async Task<ServiceResponse> IEmployee.Deleteasync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return new ServiceResponse(false, "Employee not found!");
            }

            _context.Employees.Remove(employee);
            await Savechanges();
            return new ServiceResponse(true, "Employee deleted successfully!");
        }

        // ✅ Save changes to database
        private async Task Savechanges() => await _context.SaveChangesAsync();
    }
}
