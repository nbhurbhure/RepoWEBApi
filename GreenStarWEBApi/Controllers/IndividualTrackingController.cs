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
    public class IndividualTrackingController : ApiController
    {

        // GET api/IndividualTracking
        public HttpResponseMessage GetIndividualTrackings()
        {
            DataTable dsResult = null;
            dsResult = IndividualTrackingService.GetIndividualTrackings();

            if (dsResult == null || dsResult.Rows.Count < 1)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, dsResult);
        }



        // GET api/IndividualTracking
        public HttpResponseMessage GetIndividualTrackingsById(int Id)
        {
            DataTable dsResult = null;
            dsResult = IndividualTrackingService.GetIndividualTrackingsById(Id);

            if (dsResult == null || dsResult.Rows.Count < 1)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, dsResult);
        }


        // PUT api/IndividualTracking/5
        public IHttpActionResult PutIndividualTracking(int Id, IndividualTracking objIndividualTracking)
        {
            IndividualTrackingService.PutIndividualTracking(Id, objIndividualTracking);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/IndividualTracking
        [ResponseType(typeof(IndividualTracking))]
        public IHttpActionResult PostIndividualTracking(IndividualTracking objIndividualTracking)
        {
            IndividualTrackingService.PostIndividualTracking(objIndividualTracking);
            return CreatedAtRoute("DefaultApi", new { id = objIndividualTracking.Id }, objIndividualTracking);
        }

        // DELETE api/IndividualTracking/5
        [ResponseType(typeof(IndividualTracking))]
        public IHttpActionResult DeleteIndividualTracking(int Id)
        {
            DataTable dsResult = null;
            dsResult = IndividualTrackingService.GetIndividualTrackings();
            DataRow retainDataRow=null;
            foreach (DataRow dr in dsResult.AsEnumerable())
            {
                if (Convert.ToInt32(dr[0]) == Id)
                {
                    retainDataRow = dr;
                }
            }

            IndividualTrackingService.DeleteIndividualTracking(Id);
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
