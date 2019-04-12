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
    public class ScreenController : ApiController
    {

        // GET api/Screen
        public HttpResponseMessage GetScreens()
        {
            DataTable dsResult = null;
            dsResult = ScreenService.GetScreens();

            if (dsResult == null || dsResult.Rows.Count < 1)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, dsResult);
        }



        // GET api/Screen
        public HttpResponseMessage GetScreensById(int Id)
        {
            DataTable dsResult = null;
            dsResult = ScreenService.GetScreensById(Id);

            if (dsResult == null || dsResult.Rows.Count < 1)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, dsResult);
        }


        // PUT api/Screen/5
        public IHttpActionResult PutScreen(int Id, Screen objScreen)
        {
            ScreenService.PutScreen(Id, objScreen);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Screen
        [ResponseType(typeof(Screen))]
        public IHttpActionResult PostScreen(Screen objScreen)
        {
            ScreenService.PostScreen(objScreen);
            return CreatedAtRoute("DefaultApi", new { id = objScreen.Id }, objScreen);
        }

        // DELETE api/Screen/5
        [ResponseType(typeof(Screen))]
        public IHttpActionResult DeleteScreen(int Id)
        {
            DataTable dsResult = null;
            dsResult = ScreenService.GetScreens();
            DataRow retainDataRow=null;
            foreach (DataRow dr in dsResult.AsEnumerable())
            {
                if (Convert.ToInt32(dr[0]) == Id)
                {
                    retainDataRow = dr;
                }
            }

            ScreenService.DeleteScreen(Id);
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
