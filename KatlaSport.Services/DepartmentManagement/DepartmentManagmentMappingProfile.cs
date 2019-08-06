namespace KatlaSport.Services.DepartmentManagement
{
    using System;
    using AutoMapper;
    using KatlaSport.DataAccess.DepartmentStore;
    using KatlaSport.Services.CompanyStructureManagement;

    public sealed class DepartmentManagmentMappingProfile : Profile
    {
        public DepartmentManagmentMappingProfile()
        {
            CreateMap<StoreDepartment, Department>();
            CreateMap<UpdateDepartmentRequest, StoreDepartment>()
                .ForMember(r => r.LastUpdated, opt => opt.MapFrom(p => DateTime.UtcNow));

            CreateMap<StoreDepartment, DepartmentListItem>()
               .ForMember(r => r.ParentName, opt => opt.MapFrom(p => p.ParentDepartment.Name));
        }
    }
}
