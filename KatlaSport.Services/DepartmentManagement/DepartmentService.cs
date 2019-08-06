namespace KatlaSport.Services.DepartmentManagement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using KatlaSport.DataAccess;
    using KatlaSport.DataAccess.DepartmentStore;
    using KatlaSport.Services.CompanyStructureManagement;

    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentContext _context;

        public DepartmentService(IDepartmentContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Department> CreateDepartment(UpdateDepartmentRequest createRequest)
        {
            var dbDepartments = await _context.Departments.Where(d => d.Code == createRequest.Code).ToArrayAsync();
            if (dbDepartments.Length > 0)
            {
                throw new RequestedResourceHasConflictException("code");
            }

            var dbDepartment = Mapper.Map<UpdateDepartmentRequest, StoreDepartment>(createRequest);
            _context.Departments.Add(dbDepartment);

            await _context.SaveChangesAsync();

            return Mapper.Map<Department>(dbDepartment);
        }

        public async Task DeleteDepartment(int departmentId)
        {
            var dbDepartments = await _context.Departments.Where(d => d.Id == departmentId).ToArrayAsync();
            if (dbDepartments.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbDepartment = dbDepartments[0];
            if (dbDepartment.IsDeleted == false)
            {
                throw new RequestedResourceHasConflictException();
            }

            _context.Departments.Remove(dbDepartment);
            _context.SaveChangesAsync();
        }

        public async Task<Department> GetDepartment(int departmentId)
        {
            var dbDepartments = await _context.Departments.Where(d => d.Id == departmentId).ToArrayAsync();
            if (dbDepartments.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            return Mapper.Map<StoreDepartment, Department>(dbDepartments[0]);
        }

        public async Task<List<Department>> GetDepartments()
        {
            var dbDepartments = await _context.Departments.OrderBy(h => h.Id).ToArrayAsync();
            var departments = dbDepartments.Select(h => Mapper.Map<Department>(h)).ToList();

            return departments;
        }

        public async Task SetStatus(int departmentId, bool deletedStatus)
        {
            var dbDepartments = await _context.Departments.Where(d => d.Id == departmentId).ToArrayAsync();

            if (dbDepartments.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbDepartment = dbDepartments[0];
            if (dbDepartment.IsDeleted != deletedStatus)
            {
                dbDepartment.IsDeleted = deletedStatus;
                dbDepartment.LastUpdated = DateTime.UtcNow;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Department> UpdateDepartment(int departmentId, UpdateDepartmentRequest updateRequest)
        {
            var dbDepartments = await _context.Departments.Where(p => p.Code == updateRequest.Code && p.Id != departmentId).ToArrayAsync();
            if (dbDepartments.Length > 0)
            {
                throw new RequestedResourceHasConflictException("code");
            }

            dbDepartments = _context.Departments.Where(p => p.Id == departmentId).ToArray();
            if (dbDepartments.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbDepartment = dbDepartments[0];

            Mapper.Map(updateRequest, dbDepartment);

            await _context.SaveChangesAsync();

            return Mapper.Map<Department>(dbDepartment);
        }
    }
}
