using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.Handlers.Queries;
using EmployeeManagementAPI.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.CQRS.Handlers
{
    public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, IEnumerable<Employee>>
    {
        private EmployeeContext context;
        public GetEmployeesQueryHandler(EmployeeContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Employee>> Handle(GetEmployeesQuery query, CancellationToken cancellationToken)
        {
            var EmployeesList = await context.Employees.ToListAsync();
            return EmployeesList;
        }
    }
}