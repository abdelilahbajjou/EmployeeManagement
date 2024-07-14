using EmployeeManagementAPI.Models;
using MediatR;

namespace EmployeeManagementAPI.Handlers.Queries.UpdateEmployee
{
    public class UpdateEmployeeCommand : IRequest<Employee>
    {
        public Guid Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string PhoneNumber { get; }
        public string Position { get; }
        public string Department { get; }

        public UpdateEmployeeCommand(Guid id, string firstName, string lastName, string email, string phoneNumber, string position, string department)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Position = position;
            Department = department;
        }
    }
}