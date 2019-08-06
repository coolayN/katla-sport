using System;
using System.Collections.Generic;

namespace KatlaSport.Services.CompanyStructureManagement
{
    public class DepartmentListItem
    {
        public int Id { get; set; }

        public int? ParentId { get; set; }

        public string ParentName { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime LastUpdated { get; set; }

        public List<DepartmentMainInfo> ChildDepartments { get; set; } = new List<DepartmentMainInfo>();
    }
}
