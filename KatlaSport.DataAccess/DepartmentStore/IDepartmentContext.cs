namespace KatlaSport.DataAccess.DepartmentStore
{
    public interface IDepartmentContext : IAsyncEntityStorage
    {
        IEntitySet<StoreDepartment> Departments { get; }
    }
}
