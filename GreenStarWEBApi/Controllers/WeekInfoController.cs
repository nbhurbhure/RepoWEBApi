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
    public class WeekInfoController : ApiController
    {

        // GET api/WeekInfo
        public HttpResponseMessage GetWeekInfos()
        {
            DataTable dsResult = null;
            dsResult = WeekInfoService.GetWeekInfos();

            if (dsResult == null || dsResult.Rows.Count < 1)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, dsResult);
        }



        // GET api/WeekInfo
        public HttpResponseMessage GetWeekInfosById(int Id)
        {
            DataTable dsResult = null;
            dsResult = WeekInfoService.GetWeekInfosById(Id);

            if (dsResult == null || dsResult.Rows.Count < 1)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, dsResult);
        }


        // PUT api/WeekInfo/5
        public IHttpActionResult PutWeekInfo(int Id, WeekInfo objWeekInfo)
        {
            WeekInfoService.PutWeekInfo(Id, objWeekInfo);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/WeekInfo
        [ResponseType(typeof(WeekInfo))]
        public IHttpActionResult PostWeekInfo(WeekInfo objWeekInfo)
        {
            WeekInfoService.PostWeekInfo(objWeekInfo);
            return CreatedAtRoute("DefaultApi", new { id = objWeekInfo.Id }, objWeekInfo);
        }

        // DELETE api/WeekInfo/5
        [ResponseType(typeof(WeekInfo))]
        public IHttpActionResult DeleteWeekInfo(int Id)
        {
            DataTable dsResult = null;
            dsResult = WeekInfoService.GetWeekInfos();
            DataRow retainDataRow=null;
            foreach (DataRow dr in dsResult.AsEnumerable())
            {
                if (Convert.ToInt32(dr[0]) == Id)
                {
                    retainDataRow = dr;
                }
            }

            WeekInfoService.DeleteWeekInfo(Id);
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
