using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementAPI.Handlers.Queries.UpdateEmployee
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Employee>
    {
        private readonly EmployeeContext context;

        public UpdateEmployeeCommandHandler(EmployeeContext context)
        {
            this.context = context;
        }

        public async Task<Employee> Handle(UpdateEmployeeCommand query, CancellationToken cancellationToken)
        {
            var employee = await context.Employees.FindAsync(query.Id);
            if (employee == null)
            {
                throw new KeyNotFoundException($"Employee with Id {query.Id} not found.");
            }

            employee.FirstName = query.FirstName;
            employee.LastName = query.LastName;
            employee.Email = query.Email;
            employee.PhoneNumber = query.PhoneNumber;
            employee.Position = query.Position;
            employee.Department = query.Department;

            await context.SaveChangesAsync(cancellationToken);

            return employee;
        }
    }
}