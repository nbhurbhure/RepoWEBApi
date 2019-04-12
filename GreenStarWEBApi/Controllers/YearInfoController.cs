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
    public class YearInfoController : ApiController
    {

        // GET api/YearInfo
        public HttpResponseMessage GetYearInfos()
        {
            DataTable dsResult = null;
            dsResult = YearInfoService.GetYearInfos();

            if (dsResult == null || dsResult.Rows.Count < 1)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, dsResult);
        }



        // GET api/YearInfo
        public HttpResponseMessage GetYearInfosById(int Id)
        {
            DataTable dsResult = null;
            dsResult = YearInfoService.GetYearInfosById(Id);

            if (dsResult == null || dsResult.Rows.Count < 1)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, dsResult);
        }


        // PUT api/YearInfo/5
        public IHttpActionResult PutYearInfo(int Id, YearInfo objYearInfo)
        {
            YearInfoService.PutYearInfo(Id, objYearInfo);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/YearInfo
        [ResponseType(typeof(YearInfo))]
        public IHttpActionResult PostYearInfo(YearInfo objYearInfo)
        {
            YearInfoService.PostYearInfo(objYearInfo);
            return CreatedAtRoute("DefaultApi", new { id = objYearInfo.Id }, objYearInfo);
        }

        // DELETE api/YearInfo/5
        [ResponseType(typeof(YearInfo))]
        public IHttpActionResult DeleteYearInfo(int Id)
        {
            DataTable dsResult = null;
            dsResult = YearInfoService.GetYearInfos();
            DataRow retainDataRow=null;
            foreach (DataRow dr in dsResult.AsEnumerable())
            {
                if (Convert.ToInt32(dr[0]) == Id)
                {
                    retainDataRow = dr;
                }
            }

            YearInfoService.DeleteYearInfo(Id);
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
