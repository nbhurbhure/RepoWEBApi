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
    public class ClassWiseTrackingController : ApiController
    {

        // GET api/ClassWiseTracking
        public HttpResponseMessage GetClassWiseTrackings()
        {
            DataTable dsResult = null;
            dsResult = ClassWiseTrackingService.GetClassWiseTrackings();

            if (dsResult == null || dsResult.Rows.Count < 1)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, dsResult);
        }



        // GET api/ClassWiseTracking
        public HttpResponseMessage GetClassWiseTrackingsById(int Id)
        {
            DataTable dsResult = null;
            dsResult = ClassWiseTrackingService.GetClassWiseTrackingsById(Id);

            if (dsResult == null || dsResult.Rows.Count < 1)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, dsResult);
        }


        // PUT api/ClassWiseTracking/5
        public IHttpActionResult PutClassWiseTracking(int Id, ClassWiseTracking objClassWiseTracking)
        {
            ClassWiseTrackingService.PutClassWiseTracking(Id, objClassWiseTracking);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/ClassWiseTracking
        [ResponseType(typeof(ClassWiseTracking))]
        public IHttpActionResult PostClassWiseTracking(ClassWiseTracking objClassWiseTracking)
        {
            ClassWiseTrackingService.PostClassWiseTracking(objClassWiseTracking);
            return CreatedAtRoute("DefaultApi", new { id = objClassWiseTracking.Id }, objClassWiseTracking);
        }

        // DELETE api/ClassWiseTracking/5
        [ResponseType(typeof(ClassWiseTracking))]
        public IHttpActionResult DeleteClassWiseTracking(int Id)
        {
            DataTable dsResult = null;
            dsResult = ClassWiseTrackingService.GetClassWiseTrackings();
            DataRow retainDataRow=null;
            foreach (DataRow dr in dsResult.AsEnumerable())
            {
                if (Convert.ToInt32(dr[0]) == Id)
                {
                    retainDataRow = dr;
                }
            }

            ClassWiseTrackingService.DeleteClassWiseTracking(Id);
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
