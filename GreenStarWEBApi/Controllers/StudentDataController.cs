using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI.Models;
using System.Web.Http.Cors;
using WebAPI.Service;

namespace WebAPI.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class StudentDataController : ApiController
    {

        // GET api/StudentData
        public HttpResponseMessage GetStudentDatas()
        {
            DataTable dsResult = null;
            dsResult = StudentDataService.GetStudentDatas();

            if (dsResult == null || dsResult.Rows.Count < 1)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, dsResult);
        }



        // GET api/StudentData
        public HttpResponseMessage GetStudentDatasById(int Id)
        {
            DataTable dsResult = null;
            dsResult = StudentDataService.GetStudentDatasById(Id);

            if (dsResult == null || dsResult.Rows.Count < 1)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, dsResult);
        }


        // PUT api/StudentData/5
        public IHttpActionResult PutStudentData(int Id, StudentData objStudentData)
        {
            StudentDataService.PutStudentData(Id, objStudentData);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/StudentData
        [ResponseType(typeof(StudentData))]
        public IHttpActionResult PostStudentData(StudentData objStudentData)
        {
            StudentDataService.PostStudentData(objStudentData);
            return CreatedAtRoute("DefaultApi", new { id = objStudentData.Id }, objStudentData);
        }

        // DELETE api/StudentData/5
        [ResponseType(typeof(StudentData))]
        public IHttpActionResult DeleteStudentData(int Id)
        {
            DataTable dsResult = null;
            dsResult = StudentDataService.GetStudentDatas();
            DataRow retainDataRow=null;
            foreach (DataRow dr in dsResult.AsEnumerable())
            {
                if (Convert.ToInt32(dr[0]) == Id)
                {
                    retainDataRow = dr;
                }
            }

            StudentDataService.DeleteStudentData(Id);
            return Ok(retainDataRow);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
