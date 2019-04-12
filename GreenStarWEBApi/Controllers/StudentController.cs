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
    public class StudentController : ApiController
    {

        // GET api/Student
        public HttpResponseMessage GetStudents()
        {
            DataTable dsResult = null;
            dsResult = StudentService.GetStudents();

            if (dsResult == null || dsResult.Rows.Count < 1)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, dsResult);
        }



        // GET api/Student
        public HttpResponseMessage GetStudentsById(int Id)
        {
            DataTable dsResult = null;
            dsResult = StudentService.GetStudentsById(Id);

            if (dsResult == null || dsResult.Rows.Count < 1)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, dsResult);
        }


        // PUT api/Student/5
        public IHttpActionResult PutStudent(int Id, Student objStudent)
        {
            StudentService.PutStudent(Id, objStudent);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Student
        [ResponseType(typeof(Student))]
        public IHttpActionResult PostStudent(Student objStudent)
        {
            StudentService.PostStudent(objStudent);
            return CreatedAtRoute("DefaultApi", new { id = objStudent.Id }, objStudent);
        }

        // DELETE api/Student/5
        [ResponseType(typeof(Student))]
        public IHttpActionResult DeleteStudent(int Id)
        {
            DataTable dsResult = null;
            dsResult = StudentService.GetStudents();
            DataRow retainDataRow=null;
            foreach (DataRow dr in dsResult.AsEnumerable())
            {
                if (Convert.ToInt32(dr[0]) == Id)
                {
                    retainDataRow = dr;
                }
            }

            StudentService.DeleteStudent(Id);
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
