using EmployeeManagementAPI.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementAPI.Handlers.Queries.GetEmployeeById
{
    public class GetEmployeeByIdQuery : IRequest<Employee>
    {
        public Guid Id { get; }

        public GetEmployeeByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
