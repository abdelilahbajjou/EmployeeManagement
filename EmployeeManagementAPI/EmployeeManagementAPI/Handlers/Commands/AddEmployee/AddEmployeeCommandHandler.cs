using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.Models;
using MediatR;

namespace EmployeeManagementAPI.Handlers.Commands.AddEmployee
{
    public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommand, Employee>
    {
        private EmployeeContext context;
        public AddEmployeeCommandHandler(EmployeeContext context)
        {
            this.context = context;
        }

        public async Task<Employee> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = new Employee
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Position = request.Position,
                Department = request.Department
            };

            context.Employees.Add(employee);
            await context.SaveChangesAsync();
            return employee;
        }
    }
}
