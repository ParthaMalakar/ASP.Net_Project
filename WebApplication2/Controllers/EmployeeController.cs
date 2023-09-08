using Microsoft.AspNetCore.Cors;
using System;
using System.Collections.Generic;
using System.Linq;
using BLL.DTOs;
using BLL.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Buffers.Text;
using System.Security.Policy;
using System.Xml.Linq;

namespace WebApplication2.Controllers
{
    public class EmployeeController : ApiController
    {
        //Get all employee based on maximum to minimum salary who has not any absent record
        [EnableCors("*")]
        [Route("api/getAllSalary")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = CollectDataService.GetMontlySalaryEmp();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }


       // Get employee who has 3rd highest salary
        [EnableCors("*")]
        [Route("api/get/third/Salary")]
        [HttpGet]
        public HttpResponseMessage GETSALGet()
        {
            var data = CollectDataService.GETSAL();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        //Get a hierarchy from an employee based on his supervisor.
        [Route("api/SuperVisor/{id}")]
        [HttpGet]
        public HttpResponseMessage GetSupervisor(string id)
        {
            
            var data = CollectDataService.GetSupervisor(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        // Get monthly attendance report of all employee
        [Route("api/attendence")]
        [HttpGet]
        public HttpResponseMessage GetAttendence()
        {

            var data = CollectDataService.GetAllEmp();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }


        // Update an employee’s Employee Name and Code[Don't allow duplicate employee code]
        [EnableCors("*")]
        [Route("api/update")]
        [HttpPost]
        public HttpResponseMessage GetUpdate(EmployeeDTO obj)
        {
            try
            {
                var isUpdated = CollectDataService.UPDATE(obj);
                return Request.CreateResponse(HttpStatusCode.OK, isUpdated);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
           
        }

    }
}
