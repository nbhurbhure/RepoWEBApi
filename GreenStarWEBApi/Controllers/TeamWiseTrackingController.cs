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
    public class TeamWiseTrackingController : ApiController
    {

        // GET api/TeamWiseTracking
        public HttpResponseMessage GetTeamWiseTrackings()
        {
            DataTable dsResult = null;
            dsResult = TeamWiseTrackingService.GetTeamWiseTrackings();

            if (dsResult == null || dsResult.Rows.Count < 1)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, dsResult);
        }



        // GET api/TeamWiseTracking
        public HttpResponseMessage GetTeamWiseTrackingsById(int Id)
        {
            DataTable dsResult = null;
            dsResult = TeamWiseTrackingService.GetTeamWiseTrackingsById(Id);

            if (dsResult == null || dsResult.Rows.Count < 1)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, dsResult);
        }


        // PUT api/TeamWiseTracking/5
        public IHttpActionResult PutTeamWiseTracking(int Id, TeamWiseTracking objTeamWiseTracking)
        {
            TeamWiseTrackingService.PutTeamWiseTracking(Id, objTeamWiseTracking);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/TeamWiseTracking
        [ResponseType(typeof(TeamWiseTracking))]
        public IHttpActionResult PostTeamWiseTracking(TeamWiseTracking objTeamWiseTracking)
        {
            TeamWiseTrackingService.PostTeamWiseTracking(objTeamWiseTracking);
            return CreatedAtRoute("DefaultApi", new { id = objTeamWiseTracking.Id }, objTeamWiseTracking);
        }

        // DELETE api/TeamWiseTracking/5
        [ResponseType(typeof(TeamWiseTracking))]
        public IHttpActionResult DeleteTeamWiseTracking(int Id)
        {
            DataTable dsResult = null;
            dsResult = TeamWiseTrackingService.GetTeamWiseTrackings();
            DataRow retainDataRow=null;
            foreach (DataRow dr in dsResult.AsEnumerable())
            {
                if (Convert.ToInt32(dr[0]) == Id)
                {
                    retainDataRow = dr;
                }
            }

            TeamWiseTrackingService.DeleteTeamWiseTracking(Id);
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
