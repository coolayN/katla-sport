using KatlaSport.Services.ImageManagement;
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

        public DateTime EmploymentDate { get; set; }

        public int PhotoId { get; set; }

        public virtual MyImage Photo { get; set; }
    }
}
