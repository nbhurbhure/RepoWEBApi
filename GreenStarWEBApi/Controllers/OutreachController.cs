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
    public class OutreachController : ApiController
    {

        // GET api/Outreach
        public HttpResponseMessage GetOutreachs()
        {
            DataTable dsResult = null;
            dsResult = OutreachService.GetOutreachs();

            if (dsResult == null || dsResult.Rows.Count < 1)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, dsResult);
        }



        // GET api/Outreach
        public HttpResponseMessage GetOutreachsById(int Id)
        {
            DataTable dsResult = null;
            dsResult = OutreachService.GetOutreachsById(Id);

            if (dsResult == null || dsResult.Rows.Count < 1)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, dsResult);
        }


        // PUT api/Outreach/5
        public IHttpActionResult PutOutreach(int Id, Outreach objOutreach)
        {
            OutreachService.PutOutreach(Id, objOutreach);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Outreach
        [ResponseType(typeof(Outreach))]
        public IHttpActionResult PostOutreach(Outreach objOutreach)
        {
            OutreachService.PostOutreach(objOutreach);
            return CreatedAtRoute("DefaultApi", new { id = objOutreach.Id }, objOutreach);
        }

        // DELETE api/Outreach/5
        [ResponseType(typeof(Outreach))]
        public IHttpActionResult DeleteOutreach(int Id)
        {
            DataTable dsResult = null;
            dsResult = OutreachService.GetOutreachs();
            DataRow retainDataRow=null;
            foreach (DataRow dr in dsResult.AsEnumerable())
            {
                if (Convert.ToInt32(dr[0]) == Id)
                {
                    retainDataRow = dr;
                }
            }

            OutreachService.DeleteOutreach(Id);
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
