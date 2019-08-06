using KatlaSport.Services.CompanyStructureManagement;
using KatlaSport.WebApi.CustomFilters;
using Microsoft.Web.Http;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace KatlaSport.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [RoutePrefix("api/departments")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [CustomExceptionFilter]
    [SwaggerResponseRemoveDefaults]
    public class DepartmentController : ApiController
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService ?? throw new ArgumentNullException(nameof(departmentService));
        }

        [HttpGet]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a list of departments.")]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetDepartments()
        {
            var department = await _departmentService.GetDepartments();
            return Ok(department);
        }

        [HttpGet]
        [Route("{departmentId:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a department.", Type = typeof(DepartmentListItem))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetDepartment(int departmentId)
        {
            var department = await _departmentService.GetDepartment(departmentId);
            return Ok(department);
        }

        [HttpGet]
        [Route("{departmentId:int:min(1)}/childDepartments")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a child departments.", Type = typeof(DepartmentListItem))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetDhildDepartments(int departmentId)
        {
            var childDepartments = await _departmentService.GetChildDepartments(departmentId);
            return Ok(childDepartments);
        }

        [HttpPost]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Create a new department.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> AddDepartment([FromBody] UpdateDepartmentRequest createRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var department = await _departmentService.CreateDepartment(createRequest);
            var location = string.Format("/api/departments/{0}", department.Id);
            return Created<Department>(location, department);
        }

        [HttpPut]
        [Route("{departmentId:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Updates an existed department.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> UpdateDepartment([FromUri] int departmentId, [FromBody] UpdateDepartmentRequest updateRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _departmentService.UpdateDepartment(departmentId, updateRequest);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        }

        [HttpDelete]
        [Route("{departmentId:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Deletes an existed department.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> DeleteDepartment([FromUri] int departmentId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _departmentService.DeleteDepartment(departmentId);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        }

        [HttpPut]
        [Route("{departmentId:int:min(1)}/status/{deletedStatus:bool}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Sets deleted status for an existed department.")]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> SetStatus([FromUri] int departmentId, [FromUri] bool deletedStatus)
        {
            await _departmentService.SetStatus(departmentId, deletedStatus);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        }
    }
}
