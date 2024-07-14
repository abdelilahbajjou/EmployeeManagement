using EmployeeManagementAPI.Models;
using MediatR;

namespace EmployeeManagementAPI.Handlers.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommand : IRequest<Employee>
    {
        public Guid Id { get; }

        public DeleteEmployeeCommand(Guid id)
        {
            Id = id;
        }
    }
}