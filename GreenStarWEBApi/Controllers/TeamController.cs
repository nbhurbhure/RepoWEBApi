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
    public class TeamController : ApiController
    {

        // GET api/Team
        public HttpResponseMessage GetTeams()
        {
            DataTable dsResult = null;
            dsResult = TeamService.GetTeams();

            if (dsResult == null || dsResult.Rows.Count < 1)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, dsResult);
        }



        // GET api/Team
        public HttpResponseMessage GetTeamsById(int Id)
        {
            DataTable dsResult = null;
            dsResult = TeamService.GetTeamsById(Id);

            if (dsResult == null || dsResult.Rows.Count < 1)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, dsResult);
        }


        // PUT api/Team/5
        public IHttpActionResult PutTeam(int Id, Team objTeam)
        {
            TeamService.PutTeam(Id, objTeam);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Team
        [ResponseType(typeof(Team))]
        public IHttpActionResult PostTeam(Team objTeam)
        {
            TeamService.PostTeam(objTeam);
            return CreatedAtRoute("DefaultApi", new { id = objTeam.Id }, objTeam);
        }

        // DELETE api/Team/5
        [ResponseType(typeof(Team))]
        public IHttpActionResult DeleteTeam(int Id)
        {
            DataTable dsResult = null;
            dsResult = TeamService.GetTeams();
            DataRow retainDataRow=null;
            foreach (DataRow dr in dsResult.AsEnumerable())
            {
                if (Convert.ToInt32(dr[0]) == Id)
                {
                    retainDataRow = dr;
                }
            }

            TeamService.DeleteTeam(Id);
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
