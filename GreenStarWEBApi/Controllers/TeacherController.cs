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
    public class TeacherController : ApiController
    {

        // GET api/Teacher
        public HttpResponseMessage GetTeachers()
        {
            DataTable dsResult = null;
            dsResult = TeacherService.GetTeachers();

            if (dsResult == null || dsResult.Rows.Count < 1)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, dsResult);
        }



        // GET api/Teacher
        public HttpResponseMessage GetTeachersById(int Id)
        {
            DataTable dsResult = null;
            dsResult = TeacherService.GetTeachersById(Id);

            if (dsResult == null || dsResult.Rows.Count < 1)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, dsResult);
        }


        // PUT api/Teacher/5
        public IHttpActionResult PutTeacher(int Id, Teacher objTeacher)
        {
            TeacherService.PutTeacher(Id, objTeacher);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Teacher
        [ResponseType(typeof(Teacher))]
        public IHttpActionResult PostTeacher(Teacher objTeacher)
        {
            TeacherService.PostTeacher(objTeacher);
            return CreatedAtRoute("DefaultApi", new { id = objTeacher.Id }, objTeacher);
        }

        // DELETE api/Teacher/5
        [ResponseType(typeof(Teacher))]
        public IHttpActionResult DeleteTeacher(int Id)
        {
            DataTable dsResult = null;
            dsResult = TeacherService.GetTeachers();
            DataRow retainDataRow=null;
            foreach (DataRow dr in dsResult.AsEnumerable())
            {
                if (Convert.ToInt32(dr[0]) == Id)
                {
                    retainDataRow = dr;
                }
            }

            TeacherService.DeleteTeacher(Id);
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
