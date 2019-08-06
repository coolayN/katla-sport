namespace KatlaSport.DataAccess.DepartmentStore
{
    internal sealed class DepartmentContext : DomainContextBase<ApplicationDbContext>, IDepartmentContext
    {
        public DepartmentContext(ApplicationDbContext dbContext)
           : base(dbContext)
        {
        }

        public IEntitySet<StoreDepartment> Departments => GetDbSet<StoreDepartment>();
    }
}
