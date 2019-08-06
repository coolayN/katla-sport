using System.Data.Entity.ModelConfiguration;

namespace KatlaSport.DataAccess.DepartmentStore
{
    internal sealed class StoreDepartmentConfiguration : EntityTypeConfiguration<StoreDepartment>
    {
        public StoreDepartmentConfiguration()
        {
            ToTable("departments");
            HasKey(i => i.Id);
            Property(i => i.Code).HasColumnName("department_code").HasMaxLength(5).IsRequired();
            Property(i => i.Name).HasColumnName("department_name").HasMaxLength(60).IsRequired();
            Property(i => i.IsDeleted).HasColumnName("deleted").IsRequired();
            Property(i => i.LastUpdated).HasColumnName("updated_utc").IsRequired();
            HasOptional(i => i.ParentDepartment).WithMany(i => i.ChildDepartments).HasForeignKey(i => i.ParentId);
        }
    }
}
