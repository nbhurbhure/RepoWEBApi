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
    public class StandardController : ApiController
    {

        // GET api/Standard
        public HttpResponseMessage GetStandards()
        {
            DataTable dsResult = null;
            dsResult = StandardService.GetStandards();

            if (dsResult == null || dsResult.Rows.Count < 1)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, dsResult);
        }



        // GET api/Standard
        public HttpResponseMessage GetStandardsById(int Id)
        {
            DataTable dsResult = null;
            dsResult = StandardService.GetStandardsById(Id);

            if (dsResult == null || dsResult.Rows.Count < 1)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, dsResult);
        }


        // PUT api/Standard/5
        public IHttpActionResult PutStandard(int Id, Standard objStandard)
        {
            StandardService.PutStandard(Id, objStandard);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Standard
        [ResponseType(typeof(Standard))]
        public IHttpActionResult PostStandard(Standard objStandard)
        {
            StandardService.PostStandard(objStandard);
            return CreatedAtRoute("DefaultApi", new { id = objStandard.Id }, objStandard);
        }

        // DELETE api/Standard/5
        [ResponseType(typeof(Standard))]
        public IHttpActionResult DeleteStandard(int Id)
        {
            DataTable dsResult = null;
            dsResult = StandardService.GetStandards();
            DataRow retainDataRow=null;
            foreach (DataRow dr in dsResult.AsEnumerable())
            {
                if (Convert.ToInt32(dr[0]) == Id)
                {
                    retainDataRow = dr;
                }
            }

            StandardService.DeleteStandard(Id);
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
