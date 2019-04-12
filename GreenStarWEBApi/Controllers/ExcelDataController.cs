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
    public class ExcelDataController : ApiController
    {

        // GET api/ExcelData
        public HttpResponseMessage GetExcelDatas()
        {
            DataTable dsResult = null;
            dsResult = ExcelDataService.GetExcelDatas();

            if (dsResult == null || dsResult.Rows.Count < 1)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, dsResult);
        }



        // GET api/ExcelData
        public HttpResponseMessage GetExcelDatasById(int Id)
        {
            DataTable dsResult = null;
            dsResult = ExcelDataService.GetExcelDatasById(Id);

            if (dsResult == null || dsResult.Rows.Count < 1)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, dsResult);
        }


        // PUT api/ExcelData/5
        public IHttpActionResult PutExcelData(int Id, ExcelData objExcelData)
        {
            ExcelDataService.PutExcelData(Id, objExcelData);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/ExcelData
        [ResponseType(typeof(ExcelData))]
        public IHttpActionResult PostExcelData(ExcelData objExcelData)
        {
            ExcelDataService.PostExcelData(objExcelData);
            return CreatedAtRoute("DefaultApi", new { id = objExcelData.Id }, objExcelData);
        }

        // DELETE api/ExcelData/5
        [ResponseType(typeof(ExcelData))]
        public IHttpActionResult DeleteExcelData(int Id)
        {
            DataTable dsResult = null;
            dsResult = ExcelDataService.GetExcelDatas();
            DataRow retainDataRow=null;
            foreach (DataRow dr in dsResult.AsEnumerable())
            {
                if (Convert.ToInt32(dr[0]) == Id)
                {
                    retainDataRow = dr;
                }
            }

            ExcelDataService.DeleteExcelData(Id);
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
