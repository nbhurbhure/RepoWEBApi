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
    public class MonthInfoController : ApiController
    {

        // GET api/MonthInfo
        public HttpResponseMessage GetMonthInfos()
        {
            DataTable dsResult = null;
            dsResult = MonthInfoService.GetMonthInfos();

            if (dsResult == null || dsResult.Rows.Count < 1)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, dsResult);
        }



        // GET api/MonthInfo
        public HttpResponseMessage GetMonthInfosById(int Id)
        {
            DataTable dsResult = null;
            dsResult = MonthInfoService.GetMonthInfosById(Id);

            if (dsResult == null || dsResult.Rows.Count < 1)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, dsResult);
        }


        // PUT api/MonthInfo/5
        public IHttpActionResult PutMonthInfo(int Id, MonthInfo objMonthInfo)
        {
            MonthInfoService.PutMonthInfo(Id, objMonthInfo);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/MonthInfo
        [ResponseType(typeof(MonthInfo))]
        public IHttpActionResult PostMonthInfo(MonthInfo objMonthInfo)
        {
            MonthInfoService.PostMonthInfo(objMonthInfo);
            return CreatedAtRoute("DefaultApi", new { id = objMonthInfo.Id }, objMonthInfo);
        }

        // DELETE api/MonthInfo/5
        [ResponseType(typeof(MonthInfo))]
        public IHttpActionResult DeleteMonthInfo(int Id)
        {
            DataTable dsResult = null;
            dsResult = MonthInfoService.GetMonthInfos();
            DataRow retainDataRow=null;
            foreach (DataRow dr in dsResult.AsEnumerable())
            {
                if (Convert.ToInt32(dr[0]) == Id)
                {
                    retainDataRow = dr;
                }
            }

            MonthInfoService.DeleteMonthInfo(Id);
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
