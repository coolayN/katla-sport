namespace KatlaSport.Services.CompanyStructureManagement
{
    public class UpdateDepartmentRequest
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public int? ParentId { get; set; }
    }
}
