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
    public class HolidayTypeController : ApiController
    {

        // GET api/HolidayType
        public HttpResponseMessage GetHolidayTypes()
        {
            DataTable dsResult = null;
            dsResult = HolidayTypeService.GetHolidayTypes();

            if (dsResult == null || dsResult.Rows.Count < 1)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, dsResult);
        }



        // GET api/HolidayType
        public HttpResponseMessage GetHolidayTypesById(int Id)
        {
            DataTable dsResult = null;
            dsResult = HolidayTypeService.GetHolidayTypesById(Id);

            if (dsResult == null || dsResult.Rows.Count < 1)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, dsResult);
        }


        // PUT api/HolidayType/5
        public IHttpActionResult PutHolidayType(int Id, HolidayType objHolidayType)
        {
            HolidayTypeService.PutHolidayType(Id, objHolidayType);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/HolidayType
        [ResponseType(typeof(HolidayType))]
        public IHttpActionResult PostHolidayType(HolidayType objHolidayType)
        {
            HolidayTypeService.PostHolidayType(objHolidayType);
            return CreatedAtRoute("DefaultApi", new { id = objHolidayType.Id }, objHolidayType);
        }

        // DELETE api/HolidayType/5
        [ResponseType(typeof(HolidayType))]
        public IHttpActionResult DeleteHolidayType(int Id)
        {
            DataTable dsResult = null;
            dsResult = HolidayTypeService.GetHolidayTypes();
            DataRow retainDataRow=null;
            foreach (DataRow dr in dsResult.AsEnumerable())
            {
                if (Convert.ToInt32(dr[0]) == Id)
                {
                    retainDataRow = dr;
                }
            }

            HolidayTypeService.DeleteHolidayType(Id);
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
