using System.Collections.Generic;
using System.Linq;
using EmployeeApi.Models;

namespace EmployeeApi.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly List<Employee> _employees = new();
        private int _nextId = 1;

        public IEnumerable<Employee> GetAll() => _employees;

        public Employee GetById(int id) =>
            _employees.FirstOrDefault(e => e.Id == id);

        public Employee Create(Employee emp)
        {
            emp.Id = _nextId++;
            _employees.Add(emp);
            return emp;
        }

        public void Update(int id, Employee emp)
        {
            var idx = _employees.FindIndex(e => e.Id == id);
            if (idx == -1) return;
            emp.Id = id;
            _employees[idx] = emp;
        }

        public void Delete(int id)
        {
            var emp = GetById(id);
            if (emp != null) _employees.Remove(emp);
        }
    }
}
