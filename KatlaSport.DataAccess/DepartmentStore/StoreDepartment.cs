using System;
using System.Collections.Generic;

namespace KatlaSport.DataAccess.DepartmentStore
{
    public class StoreDepartment
    {
        public int Id { get; set; }

        public virtual StoreDepartment ParentDepartment { get; set; }

        public int? ParentId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        //public int LogoId { get; set; }

        //public virtual MyImage Logo { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime LastUpdated { get; set; }

        public virtual ICollection<StoreDepartment> ChildDepartments { get; set; }
    }
}
