using Microsoft.AspNetCore.Mvc;
using EmployeeApi.Models;
using EmployeeApi.Services;

namespace EmployeeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _svc;
        public EmployeesController(IEmployeeService svc) => _svc = svc;

        // [HttpGet("GelAll")]
        [HttpGet]
        public IActionResult Get() => Ok(_svc.GetAll());

        // [HttpGet("GetEmp{id}", Name = "GetById")]
        [HttpGet("{id}", Name = "GetById")]
        public IActionResult Get(int id)
        {
            var emp = _svc.GetById(id);
            if (emp == null) return NotFound();
            return Ok(emp);
        }

        // [HttpPost("Add")]
        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            var created = _svc.Create(emp);
            return CreatedAtRoute("GetById", new { id = created.Id }, created);
        }

        // [HttpPut("Update/{id}")]
        [HttpPut("{id}")]
        public IActionResult Update(int id, Employee emp)
        {
            var existing = _svc.GetById(id);
            if (existing == null) return NotFound();
            _svc.Update(id, emp);
            return NoContent();
        }

        // [HttpDelete("Delete/{id}")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = _svc.GetById(id);
            if (existing == null) return NotFound();
            _svc.Delete(id);
            return NoContent();
        }
    }
}
