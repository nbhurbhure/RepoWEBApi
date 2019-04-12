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
    public class ComparativeChartController : ApiController
    {

        // GET api/ComparativeChart
        public HttpResponseMessage GetComparativeCharts()
        {
            DataTable dsResult = null;
            dsResult = ComparativeChartService.GetComparativeCharts();

            if (dsResult == null || dsResult.Rows.Count < 1)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, dsResult);
        }



        // GET api/ComparativeChart
        public HttpResponseMessage GetComparativeChartsById(int Id)
        {
            DataTable dsResult = null;
            dsResult = ComparativeChartService.GetComparativeChartsById(Id);

            if (dsResult == null || dsResult.Rows.Count < 1)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, dsResult);
        }


        // PUT api/ComparativeChart/5
        public IHttpActionResult PutComparativeChart(int Id, ComparativeChart objComparativeChart)
        {
            ComparativeChartService.PutComparativeChart(Id, objComparativeChart);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/ComparativeChart
        [ResponseType(typeof(ComparativeChart))]
        public IHttpActionResult PostComparativeChart(ComparativeChart objComparativeChart)
        {
            ComparativeChartService.PostComparativeChart(objComparativeChart);
            return CreatedAtRoute("DefaultApi", new { id = objComparativeChart.Id }, objComparativeChart);
        }

        // DELETE api/ComparativeChart/5
        [ResponseType(typeof(ComparativeChart))]
        public IHttpActionResult DeleteComparativeChart(int Id)
        {
            DataTable dsResult = null;
            dsResult = ComparativeChartService.GetComparativeCharts();
            DataRow retainDataRow=null;
            foreach (DataRow dr in dsResult.AsEnumerable())
            {
                if (Convert.ToInt32(dr[0]) == Id)
                {
                    retainDataRow = dr;
                }
            }

            ComparativeChartService.DeleteComparativeChart(Id);
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
