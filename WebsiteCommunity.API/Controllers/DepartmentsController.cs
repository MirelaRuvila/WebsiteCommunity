using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebsiteCommunity.Models;
using WebsiteCommunity.Business.Core;
using System.Web.Http.Cors;

namespace WebsiteCommunity.API.Controllers
{
    [EnableCors(origins: "http://localhost:52102", headers: " * ", methods: "*")]
    [RoutePrefix("api/departments")]
    public class DepartmentsController : ApiController
    {
        #region Methods
        
        //GET api/departments
        [HttpGet]
        [Route("")]
        public IEnumerable<Department> ReadAll()
        {
            using (BusinessContext context = new BusinessContext())
            {
                return context.DepartmentBusiness.ReadAll();
            }
        }

        //GET api/departments/{Guid}
        [HttpGet]
        [Route("{departmentId:Guid}")]
        public Department ReadById(Guid departmentId)
        {
            using (BusinessContext context = new BusinessContext())
            {
                return context.DepartmentBusiness.ReadById(departmentId);
            }
        }

        //POST api/departments
        [HttpPost]
        [Route("")]
        public void Insert([FromBody] Department department)
        {
            using (BusinessContext context = new BusinessContext())
            {
                context.DepartmentBusiness.Insert(department);
            }
        }

        //PUT api/departments
        [HttpPut]
        [Route("")]
        public void UpdateById([FromBody] Department department)
        {
            using (BusinessContext context = new BusinessContext())
            {
                context.DepartmentBusiness.UpdateById(department);
            }
        }

        //DELETE api/departments/{Guid}
        [HttpDelete]
        [Route("{departmentId:Guid}")]
        public void Delete([FromBody] Guid departmentId)
        {
            using (BusinessContext context = new BusinessContext())
            {
                context.DepartmentBusiness.Delete(departmentId);
            }
        }
        //string[] list = { "ion", "ana", "maria", "aa" };
        //GET api/departments
        //[HttpGet]
        //[Route("")]
        //public IEnumerable<string> ReadAll()
        //{
        //    return list;
        //}
        // [HttpGet]
        // [Route("{id}")]
        // public string ReadById(int id)
        //{
        //    return list[id];
        //}
        #endregion Methods

    }
}