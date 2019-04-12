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
    public class VolunteerController : ApiController
    {

        // GET api/Volunteer
        public HttpResponseMessage GetVolunteers()
        {
            DataTable dsResult = null;
            dsResult = VolunteerService.GetVolunteers();

            if (dsResult == null || dsResult.Rows.Count < 1)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, dsResult);
        }



        // GET api/Volunteer
        public HttpResponseMessage GetVolunteersById(int Id)
        {
            DataTable dsResult = null;
            dsResult = VolunteerService.GetVolunteersById(Id);

            if (dsResult == null || dsResult.Rows.Count < 1)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, dsResult);
        }


        // PUT api/Volunteer/5
        public IHttpActionResult PutVolunteer(int Id, Volunteer objVolunteer)
        {
            VolunteerService.PutVolunteer(Id, objVolunteer);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Volunteer
        [ResponseType(typeof(Volunteer))]
        public IHttpActionResult PostVolunteer(Volunteer objVolunteer)
        {
            VolunteerService.PostVolunteer(objVolunteer);
            return CreatedAtRoute("DefaultApi", new { id = objVolunteer.Id }, objVolunteer);
        }

        // DELETE api/Volunteer/5
        [ResponseType(typeof(Volunteer))]
        public IHttpActionResult DeleteVolunteer(int Id)
        {
            DataTable dsResult = null;
            dsResult = VolunteerService.GetVolunteers();
            DataRow retainDataRow=null;
            foreach (DataRow dr in dsResult.AsEnumerable())
            {
                if (Convert.ToInt32(dr[0]) == Id)
                {
                    retainDataRow = dr;
                }
            }

            VolunteerService.DeleteVolunteer(Id);
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
