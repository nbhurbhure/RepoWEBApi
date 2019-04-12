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
    public class VroleController : ApiController
    {

        // GET api/Vrole
        public HttpResponseMessage GetVroles()
        {
            DataTable dsResult = null;
            dsResult = VroleService.GetVroles();

            if (dsResult == null || dsResult.Rows.Count < 1)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, dsResult);
        }



        // GET api/Vrole
        public HttpResponseMessage GetVrolesById(int Id)
        {
            DataTable dsResult = null;
            dsResult = VroleService.GetVrolesById(Id);

            if (dsResult == null || dsResult.Rows.Count < 1)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, dsResult);
        }


        // PUT api/Vrole/5
        public IHttpActionResult PutVrole(int Id, Vrole objVrole)
        {
            VroleService.PutVrole(Id, objVrole);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Vrole
        [ResponseType(typeof(Vrole))]
        public IHttpActionResult PostVrole(Vrole objVrole)
        {
            VroleService.PostVrole(objVrole);
            return CreatedAtRoute("DefaultApi", new { id = objVrole.Id }, objVrole);
        }

        // DELETE api/Vrole/5
        [ResponseType(typeof(Vrole))]
        public IHttpActionResult DeleteVrole(int Id)
        {
            DataTable dsResult = null;
            dsResult = VroleService.GetVroles();
            DataRow retainDataRow=null;
            foreach (DataRow dr in dsResult.AsEnumerable())
            {
                if (Convert.ToInt32(dr[0]) == Id)
                {
                    retainDataRow = dr;
                }
            }

            VroleService.DeleteVrole(Id);
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
