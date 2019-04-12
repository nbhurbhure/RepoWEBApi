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
    public class TeamStudentMappingController : ApiController
    {

        // GET api/TeamStudentMapping
        public HttpResponseMessage GetTeamStudentMappings()
        {
            DataTable dsResult = null;
            dsResult = TeamStudentMappingService.GetTeamStudentMappings();

            if (dsResult == null || dsResult.Rows.Count < 1)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, dsResult);
        }



        // GET api/TeamStudentMapping
        public HttpResponseMessage GetTeamStudentMappingsById(int Id)
        {
            DataTable dsResult = null;
            dsResult = TeamStudentMappingService.GetTeamStudentMappingsById(Id);

            if (dsResult == null || dsResult.Rows.Count < 1)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, dsResult);
        }


        // PUT api/TeamStudentMapping/5
        public IHttpActionResult PutTeamStudentMapping(int Id, TeamStudentMapping objTeamStudentMapping)
        {
            TeamStudentMappingService.PutTeamStudentMapping(Id, objTeamStudentMapping);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/TeamStudentMapping
        [ResponseType(typeof(TeamStudentMapping))]
        public IHttpActionResult PostTeamStudentMapping(TeamStudentMapping objTeamStudentMapping)
        {
            TeamStudentMappingService.PostTeamStudentMapping(objTeamStudentMapping);
            return CreatedAtRoute("DefaultApi", new { id = objTeamStudentMapping.Id }, objTeamStudentMapping);
        }

        // DELETE api/TeamStudentMapping/5
        [ResponseType(typeof(TeamStudentMapping))]
        public IHttpActionResult DeleteTeamStudentMapping(int Id)
        {
            DataTable dsResult = null;
            dsResult = TeamStudentMappingService.GetTeamStudentMappings();
            DataRow retainDataRow=null;
            foreach (DataRow dr in dsResult.AsEnumerable())
            {
                if (Convert.ToInt32(dr[0]) == Id)
                {
                    retainDataRow = dr;
                }
            }

            TeamStudentMappingService.DeleteTeamStudentMapping(Id);
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
