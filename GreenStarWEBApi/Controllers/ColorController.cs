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
    public class ColorController : ApiController
    {

        // GET api/Color
        public HttpResponseMessage GetColors()
        {
            DataTable dsResult = null;
            dsResult = ColorService.GetColors();

            if (dsResult == null || dsResult.Rows.Count < 1)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, dsResult);
        }



        // GET api/Color
        public HttpResponseMessage GetColorsById(int Id)
        {
            DataTable dsResult = null;
            dsResult = ColorService.GetColorsById(Id);

            if (dsResult == null || dsResult.Rows.Count < 1)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, dsResult);
        }


        // PUT api/Color/5
        public IHttpActionResult PutColor(int Id, Color objColor)
        {
            ColorService.PutColor(Id, objColor);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Color
        [ResponseType(typeof(Color))]
        public IHttpActionResult PostColor(Color objColor)
        {
            ColorService.PostColor(objColor);
            return CreatedAtRoute("DefaultApi", new { id = objColor.Id }, objColor);
        }

        // DELETE api/Color/5
        [ResponseType(typeof(Color))]
        public IHttpActionResult DeleteColor(int Id)
        {
            DataTable dsResult = null;
            dsResult = ColorService.GetColors();
            DataRow retainDataRow=null;
            foreach (DataRow dr in dsResult.AsEnumerable())
            {
                if (Convert.ToInt32(dr[0]) == Id)
                {
                    retainDataRow = dr;
                }
            }

            ColorService.DeleteColor(Id);
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
