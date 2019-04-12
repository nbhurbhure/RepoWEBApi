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
    public class HolidayController : ApiController
    {

        // GET api/Holiday
        public HttpResponseMessage GetHolidays()
        {
            DataTable dsResult = null;
            dsResult = HolidayService.GetHolidays();

            if (dsResult == null || dsResult.Rows.Count < 1)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, dsResult);
        }



        // GET api/Holiday
        public HttpResponseMessage GetHolidaysById(int Id)
        {
            DataTable dsResult = null;
            dsResult = HolidayService.GetHolidaysById(Id);

            if (dsResult == null || dsResult.Rows.Count < 1)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, dsResult);
        }


        // PUT api/Holiday/5
        public IHttpActionResult PutHoliday(int Id, Holiday objHoliday)
        {
            HolidayService.PutHoliday(Id, objHoliday);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Holiday
        [ResponseType(typeof(Holiday))]
        public IHttpActionResult PostHoliday(Holiday objHoliday)
        {
            HolidayService.PostHoliday(objHoliday);
            return CreatedAtRoute("DefaultApi", new { id = objHoliday.Id }, objHoliday);
        }

        // DELETE api/Holiday/5
        [ResponseType(typeof(Holiday))]
        public IHttpActionResult DeleteHoliday(int Id)
        {
            DataTable dsResult = null;
            dsResult = HolidayService.GetHolidays();
            DataRow retainDataRow=null;
            foreach (DataRow dr in dsResult.AsEnumerable())
            {
                if (Convert.ToInt32(dr[0]) == Id)
                {
                    retainDataRow = dr;
                }
            }

            HolidayService.DeleteHoliday(Id);
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
