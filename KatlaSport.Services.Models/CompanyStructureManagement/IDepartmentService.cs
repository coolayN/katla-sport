using System.Collections.Generic;
using System.Threading.Tasks;

namespace KatlaSport.Services.CompanyStructureManagement
{
    public interface IDepartmentService
    {
        Task<List<DepartmentListItem>> GetDepartments();

        Task<List<DepartmentListItem>> GetChildDepartments(int departmentId);

        Task<DepartmentListItem> GetDepartment(int departmentId);

        Task<Department> CreateDepartment(UpdateDepartmentRequest createRequest);

        Task<Department> UpdateDepartment(int departmentId, UpdateDepartmentRequest updateRequest);

        Task DeleteDepartment(int departmentId);

        Task SetStatus(int departmentId, bool deletedStatus);
    }
}
