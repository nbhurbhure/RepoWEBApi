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
    public class RoleScreenMappingController : ApiController
    {

        // GET api/RoleScreenMapping
        public HttpResponseMessage GetRoleScreenMappings()
        {
            DataTable dsResult = null;
            dsResult = RoleScreenMappingService.GetRoleScreenMappings();

            if (dsResult == null || dsResult.Rows.Count < 1)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, dsResult);
        }

        // GET api/RoleScreenMapping
        public HttpResponseMessage GetRoleScreenMappingsById(int Id)
        {
            DataTable dsResult = null;
            dsResult = RoleScreenMappingService.GetRoleScreenMappingsById(Id);

            if (dsResult == null || dsResult.Rows.Count < 1)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, dsResult);
        }


        // PUT api/RoleScreenMapping/5
        public IHttpActionResult PutRoleScreenMapping(int Id, RoleScreenMapping objRoleScreenMapping)
        {
            RoleScreenMappingService.PutRoleScreenMapping(Id, objRoleScreenMapping);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/RoleScreenMapping
        [ResponseType(typeof(RoleScreenMapping))]
        public IHttpActionResult PostRoleScreenMapping(RoleScreenMapping objRoleScreenMapping)
        {
            RoleScreenMappingService.PostRoleScreenMapping(objRoleScreenMapping);
            return CreatedAtRoute("DefaultApi", new { id = objRoleScreenMapping.Id }, objRoleScreenMapping);
        }

        // DELETE api/RoleScreenMapping/5
        [ResponseType(typeof(RoleScreenMapping))]
        public IHttpActionResult DeleteRoleScreenMapping(int Id)
        {
            DataTable dsResult = null;
            dsResult = RoleScreenMappingService.GetRoleScreenMappings();
            DataRow retainDataRow=null;
            foreach (DataRow dr in dsResult.AsEnumerable())
            {
                if (Convert.ToInt32(dr[0]) == Id)
                {
                    retainDataRow = dr;
                }
            }

            RoleScreenMappingService.DeleteRoleScreenMapping(Id);
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
