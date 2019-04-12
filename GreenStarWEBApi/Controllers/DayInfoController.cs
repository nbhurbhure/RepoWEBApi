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
    public class DayInfoController : ApiController
    {

        // GET api/DayInfo
        public HttpResponseMessage GetDayInfos()
        {
            DataTable dsResult = null;
            dsResult = DayInfoService.GetDayInfos();

            if (dsResult == null || dsResult.Rows.Count < 1)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, dsResult);
        }



        // GET api/DayInfo
        public HttpResponseMessage GetDayInfosById(int Id)
        {
            DataTable dsResult = null;
            dsResult = DayInfoService.GetDayInfosById(Id);

            if (dsResult == null || dsResult.Rows.Count < 1)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, dsResult);
        }


        // PUT api/DayInfo/5
        public IHttpActionResult PutDayInfo(int Id, DayInfo objDayInfo)
        {
            DayInfoService.PutDayInfo(Id, objDayInfo);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/DayInfo
        [ResponseType(typeof(DayInfo))]
        public IHttpActionResult PostDayInfo(DayInfo objDayInfo)
        {
            DayInfoService.PostDayInfo(objDayInfo);
            return CreatedAtRoute("DefaultApi", new { id = objDayInfo.Id }, objDayInfo);
        }

        // DELETE api/DayInfo/5
        [ResponseType(typeof(DayInfo))]
        public IHttpActionResult DeleteDayInfo(int Id)
        {
            DataTable dsResult = null;
            dsResult = DayInfoService.GetDayInfos();
            DataRow retainDataRow=null;
            foreach (DataRow dr in dsResult.AsEnumerable())
            {
                if (Convert.ToInt32(dr[0]) == Id)
                {
                    retainDataRow = dr;
                }
            }

            DayInfoService.DeleteDayInfo(Id);
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
