using EmployeeManagementAPI.Models;
using EmployeeManagementAPI.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementAPI.Handlers.Queries.GetEmployeeById
{
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, Employee>
    {
        private readonly EmployeeContext context;

        public GetEmployeeByIdQueryHandler(EmployeeContext context)
        {
            this.context = context;
        }

        public async Task<Employee> Handle(GetEmployeeByIdQuery query, CancellationToken cancellationToken)
        {
            var employee = await context.Employees.Where(a => a.Id == query.Id).FirstOrDefaultAsync();
            return employee;
        }
    }
}
