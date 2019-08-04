using System;

namespace KatlaSport.Services.CompanyStructureManagement
{
    public class Employee
    {
        public long Id { get; set; }

        public Guid DepartmentId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Position { get; set; }
    }
}
