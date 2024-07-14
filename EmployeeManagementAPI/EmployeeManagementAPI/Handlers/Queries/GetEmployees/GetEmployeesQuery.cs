using EmployeeManagementAPI.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.Handlers.Queries
{
    public class GetEmployeesQuery : IRequest<IEnumerable<Employee>>
    {
       
    }
}