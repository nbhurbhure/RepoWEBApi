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
    public class CityController : ApiController
    {

        // GET api/City
        public HttpResponseMessage GetCitys()
        {
            DataTable dsResult = null;
            dsResult = CityService.GetCitys();

            if (dsResult == null || dsResult.Rows.Count < 1)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, dsResult);
        }



        // GET api/City
        public HttpResponseMessage GetCitysById(int Id)
        {
            DataTable dsResult = null;
            dsResult = CityService.GetCitysById(Id);

            if (dsResult == null || dsResult.Rows.Count < 1)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, dsResult);
        }


        // PUT api/City/5
        public IHttpActionResult PutCity(int Id, City objCity)
        {
            CityService.PutCity(Id, objCity);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/City
        [ResponseType(typeof(City))]
        public IHttpActionResult PostCity(City objCity)
        {
            CityService.PostCity(objCity);
            return CreatedAtRoute("DefaultApi", new { id = objCity.Id }, objCity);
        }

        // DELETE api/City/5
        [ResponseType(typeof(City))]
        public IHttpActionResult DeleteCity(int Id)
        {
            DataTable dsResult = null;
            dsResult = CityService.GetCitys();
            DataRow retainDataRow=null;
            foreach (DataRow dr in dsResult.AsEnumerable())
            {
                if (Convert.ToInt32(dr[0]) == Id)
                {
                    retainDataRow = dr;
                }
            }

            CityService.DeleteCity(Id);
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
