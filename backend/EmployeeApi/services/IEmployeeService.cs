using System.Collections.Generic;
using EmployeeApi.Models;

namespace EmployeeApi.Services
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAll();
        Employee GetById(int id);
        Employee Create(Employee emp);
        void Update(int id, Employee emp);
        void Delete(int id);
    }
}
