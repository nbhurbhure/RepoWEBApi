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
    public class ParameterController : ApiController
    {

        // GET api/Parameter
        public HttpResponseMessage GetParameters()
        {
            DataTable dsResult = null;
            dsResult = ParameterService.GetParameters();

            if (dsResult == null || dsResult.Rows.Count < 1)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, dsResult);
        }



        // GET api/Parameter
        public HttpResponseMessage GetParametersById(int Id)
        {
            DataTable dsResult = null;
            dsResult = ParameterService.GetParametersById(Id);

            if (dsResult == null || dsResult.Rows.Count < 1)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, dsResult);
        }


        // PUT api/Parameter/5
        public IHttpActionResult PutParameter(int Id, Parameter objParameter)
        {
            ParameterService.PutParameter(Id, objParameter);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Parameter
        [ResponseType(typeof(Parameter))]
        public IHttpActionResult PostParameter(Parameter objParameter)
        {
            ParameterService.PostParameter(objParameter);
            return CreatedAtRoute("DefaultApi", new { id = objParameter.Id }, objParameter);
        }

        // DELETE api/Parameter/5
        [ResponseType(typeof(Parameter))]
        public IHttpActionResult DeleteParameter(int Id)
        {
            DataTable dsResult = null;
            dsResult = ParameterService.GetParameters();
            DataRow retainDataRow=null;
            foreach (DataRow dr in dsResult.AsEnumerable())
            {
                if (Convert.ToInt32(dr[0]) == Id)
                {
                    retainDataRow = dr;
                }
            }

            ParameterService.DeleteParameter(Id);
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
