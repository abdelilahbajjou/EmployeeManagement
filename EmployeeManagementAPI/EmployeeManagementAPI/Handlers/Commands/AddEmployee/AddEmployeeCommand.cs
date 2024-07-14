using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.Models;
using MediatR;

namespace EmployeeManagementAPI.Handlers.Commands.AddEmployee
{
    public class AddEmployeeCommand : IRequest<Employee>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
    }


}
