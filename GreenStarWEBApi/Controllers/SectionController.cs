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
    public class SectionController : ApiController
    {

        // GET api/Section
        public HttpResponseMessage GetSections()
        {
            DataTable dsResult = null;
            dsResult = SectionService.GetSections();

            if (dsResult == null || dsResult.Rows.Count < 1)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, dsResult);
        }



        // GET api/Section
        public HttpResponseMessage GetSectionsById(int Id)
        {
            DataTable dsResult = null;
            dsResult = SectionService.GetSectionsById(Id);

            if (dsResult == null || dsResult.Rows.Count < 1)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, dsResult);
        }


        // PUT api/Section/5
        public IHttpActionResult PutSection(int Id, Section objSection)
        {
            SectionService.PutSection(Id, objSection);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Section
        [ResponseType(typeof(Section))]
        public IHttpActionResult PostSection(Section objSection)
        {
            SectionService.PostSection(objSection);
            return CreatedAtRoute("DefaultApi", new { id = objSection.Id }, objSection);
        }

        // DELETE api/Section/5
        [ResponseType(typeof(Section))]
        public IHttpActionResult DeleteSection(int Id)
        {
            DataTable dsResult = null;
            dsResult = SectionService.GetSections();
            DataRow retainDataRow=null;
            foreach (DataRow dr in dsResult.AsEnumerable())
            {
                if (Convert.ToInt32(dr[0]) == Id)
                {
                    retainDataRow = dr;
                }
            }

            SectionService.DeleteSection(Id);
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
