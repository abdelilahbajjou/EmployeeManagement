using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementAPI.Handlers.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, Employee>
    {
        private readonly EmployeeContext context;

        public DeleteEmployeeCommandHandler(EmployeeContext context)
        {
            this.context = context;
        }

        public async Task<Employee> Handle(DeleteEmployeeCommand command, CancellationToken cancellationToken)
        {
            var employee = await context.Employees.FindAsync(command.Id);
            if (employee == null)
            {
                throw new KeyNotFoundException($"Employee with Id {command.Id} not found.");
            }

            context.Employees.Remove(employee);
            await context.SaveChangesAsync(cancellationToken);

            return employee;
        }
    }
}