using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using EmployeeManagementAPI.Handlers.Commands.AddEmployee;
using EmployeeManagementAPI.Handlers.Queries;
using EmployeeManagementAPI.Handlers.Queries.GetEmployeeById;
using EmployeeManagementAPI.Handlers.Queries.UpdateEmployee;
using EmployeeManagementAPI.Handlers.Commands.DeleteEmployee;

namespace EmployeeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IMediator mediator;
        public EmployeesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // Add Employee
        [HttpPost]
        public async Task<IActionResult> Create(AddEmployeeCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        //Get All Employees
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await mediator.Send(new GetEmployeesQuery()));
        }

        //Get Employee By Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await mediator.Send(new GetEmployeeByIdQuery(id)));
        }

        //Update Employee
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(Guid id, [FromBody] UpdateEmployeeCommand query)
        {
            return Ok(await mediator.Send(query));
        }

        //DeleteEmployee
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            return Ok(await mediator.Send(new DeleteEmployeeCommand(id)));
        }

    }
}
