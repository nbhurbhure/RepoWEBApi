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
    public class SchoolController : ApiController
    {

        // GET api/School
        public HttpResponseMessage GetSchools()
        {
            DataTable dsResult = null;
            dsResult = SchoolService.GetSchools();

            if (dsResult == null || dsResult.Rows.Count < 1)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, dsResult);
        }



        // GET api/School
        public HttpResponseMessage GetSchoolsById(int Id)
        {
            DataTable dsResult = null;
            dsResult = SchoolService.GetSchoolsById(Id);

            if (dsResult == null || dsResult.Rows.Count < 1)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, dsResult);
        }


        // PUT api/School/5
        public IHttpActionResult PutSchool(int Id, School objSchool)
        {
            SchoolService.PutSchool(Id, objSchool);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/School
        [ResponseType(typeof(School))]
        public IHttpActionResult PostSchool(School objSchool)
        {
            SchoolService.PostSchool(objSchool);
            return CreatedAtRoute("DefaultApi", new { id = objSchool.Id }, objSchool);
        }

        // DELETE api/School/5
        [ResponseType(typeof(School))]
        public IHttpActionResult DeleteSchool(int Id)
        {
            DataTable dsResult = null;
            dsResult = SchoolService.GetSchools();
            DataRow retainDataRow=null;
            foreach (DataRow dr in dsResult.AsEnumerable())
            {
                if (Convert.ToInt32(dr[0]) == Id)
                {
                    retainDataRow = dr;
                }
            }

            SchoolService.DeleteSchool(Id);
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
